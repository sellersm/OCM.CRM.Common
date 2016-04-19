Imports System.Data.SqlClient
Public Class SponsorRetentionAppeal2016LetterScannerAddDataFormUIModel
	Private _sponsorId As String
	Private _childId As String
	Private _exceptionMessage As String
	Private _scanOutcome As String
	Private _scannerSession As String
	Private _scannerMessage As String
	Private _exceptionOccurred As Boolean
	Private _finderNumber As Integer
	Private _isValidBarCode As Boolean
	Private _invalidEntryReason As String

	' using these variables to make testing easier
	'************** CHANGE VALUES BACK AFTER TESTING! ***************
	Private _ISTESTING As Boolean = False
	Private _sponsorIdLength As Integer = 6
	Private _childIdLength As Integer = 7
	Private _appealCodeLength As Integer = 5
	Private Sub SponsorRetentionAppeal2016LetterScannerAddDataFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
		Me.SUBMIT.Visible = False
		Me.SUBMIT.Value = False

		_scannerSession = GetScanSession()
		Me.SCANSESSION.Value = _scannerSession

		SetExtraFieldsVisibility(False)

	End Sub

	Private Sub SponsorRetentionAppeal2016LetterScannerAddDataFormUIModel_BeginValidate(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.BeginValidateEventArgs) Handles Me.BeginValidate
		' this function performs form field validation and update
		If IsNothing(_barcode.Value) Then
			_barcode.Value = ""
		End If

		'clear out the variables so they don't stack up:
		_sponsorId = String.Empty
		_childId = String.Empty
		'_letterFullname = String.Empty
		_exceptionMessage = String.Empty
		_scanOutcome = String.Empty
		_scannerMessage = String.Empty
		_finderNumber = -1
		_isValidBarCode = False
		_invalidEntryReason = String.Empty


		Dim element As SponsorRetentionAppeal2016LetterScannerAddDataFormBARCODEELEMENTSUIModel = New SponsorRetentionAppeal2016LetterScannerAddDataFormBARCODEELEMENTSUIModel()
		element.RESULTSOK.Enabled = False

		_isValidBarCode = ValidateUserFields()

		If _isValidBarCode Then
			' call the parse sproc and show results:
			SetParseResults(_barcode.Value.ToString())

			'if the parsing was OK, then call the process sproc:
			If String.IsNullOrEmpty(_exceptionMessage) Then
				ProcessBarCode()

				' Bar code is correctly formatted, parse the string and add original bar code value and parse status into the gridview
				element.RESULTSOK.Value = Not _exceptionOccurred 'String.IsNullOrEmpty(_exceptionMessage)
				'element.BARCODE.Value = _barcode.Value.ToString()

				'Make the Scan Status be: "Success" or "Unsuccessful"
				If (_scanOutcome.Contains("successful") Or (_scanOutcome.Contains("Extra"))) Then
					element.SCANSTATUS.Value = "Success!"
					element.SCANSTATUS.ValueDisplayStyle = Blackbaud.AppFx.UIModeling.Core.ValueDisplayStyle.GoodImageAndText
				Else
					element.SCANSTATUS.Value = "Unsuccessful"
					element.SCANSTATUS.ValueDisplayStyle = Blackbaud.AppFx.UIModeling.Core.ValueDisplayStyle.WarningImageAndText
				End If
				'element.SCANSTATUS.Value = IIf((_scanOutcome.Contains("successful") Or _scanOutcome.Contains("Extra")), "Success!", "")	'  _scanOutcome

				'figure out which Letter Stack this letter should go into:
				element.LETTERSTACK.Value = GetLetterStack(_scanOutcome)
				If element.LETTERSTACK.Value.ToString().Contains("Exception") Then
					element.LETTERSTACK.ValueDisplayStyle = ValueDisplayStyle.BadTextOnly
				Else
					element.LETTERSTACK.ValueDisplayStyle = ValueDisplayStyle.GoodTextOnly
				End If

				element.SCANMESSAGE.Value = _scannerMessage
				element.SPONSORLOOKUPID.Value = _sponsorId
				element.CHILDLOOKUPID.Value = _childId
				element.FINDERNUMBER.Value = _finderNumber

				'clear out the barcode field:
				Me.BARCODE.Value = String.Empty
				_barcode.Value = String.Empty
			Else
				element.SCANSTATUS.ValueDisplayStyle = Blackbaud.AppFx.UIModeling.Core.ValueDisplayStyle.WarningImageAndText
				element.RESULTSOK.Value = False

				'figure out which Letter Stack this letter should go into:
				element.LETTERSTACK.Value = GetLetterStack(_scanOutcome)
				If element.LETTERSTACK.Value.ToString().ToLower().Contains("exception") Then
					element.LETTERSTACK.ValueDisplayStyle = ValueDisplayStyle.BadTextOnly
				Else
					element.LETTERSTACK.ValueDisplayStyle = ValueDisplayStyle.GoodTextOnly
				End If

				'Make the Scan Status be: "Success" or "Unsuccessful"
				element.SCANSTATUS.Value = IIf(_scanOutcome.Contains("successful"), "Success!", "Unsuccessful")	'  _scanOutcome
				'element.BARCODE.Value = _barcode.Value.ToString()
				element.SPONSORLOOKUPID.Value = _sponsorId
				element.CHILDLOOKUPID.Value = _childId
				element.EXCEPTION.ValueDisplayStyle = Blackbaud.AppFx.UIModeling.Core.ValueDisplayStyle.BadImageAndText
				element.EXCEPTION.Value = _exceptionMessage.ToString()
				element.FINDERNUMBER.Value = _finderNumber
			End If

		Else
			' Bar code is not correctly formatted, do not parse the string but add original bar code value and invalid status into the gridview
			element.BARCODE.Value = _barcode.Value.ToString()
			element.SCANSTATUS.ValueDisplayStyle = Blackbaud.AppFx.UIModeling.Core.ValueDisplayStyle.WarningImageAndText
			element.SCANSTATUS.Value = "Unsuccessful"
			element.EXCEPTION.ValueDisplayStyle = Blackbaud.AppFx.UIModeling.Core.ValueDisplayStyle.BadImageAndText
			element.EXCEPTION.Value = _invalidEntryReason
			element.RESULTSOK.Value = False
			'set the scan outcome to something so it's displayed below for the invalid reason:
			_scanOutcome = _invalidEntryReason 'String.Format("Bar Code must be at least {0} characters long. Try entering the scan values manually.", _sponsorIdLength)
		End If

		BARCODEELEMENTS.Value.Add(element)

		SetExtraFieldsVisibility(False)

		' if SUBMIT checkbox is checked, we will actually save the data and close the form (the validation status will be true in this case)
		e.Valid = SUBMIT.Value

		If Not e.Valid Then
			' the user did not check the SUBMIT checkbox => we are not going to close the form yet
			' so, we have to set e.InvalidReason to be a non-blank string
			e.InvalidReason = "Results: " & _scanOutcome & " " & _scannerMessage & " " & _exceptionMessage	'_sponsorId & " " & _childId & " " & _letterFullname & " " & _exceptionMessage
		End If
	End Sub

	Private Sub SetParseResults(ByVal barCode As String)
		Dim sBarCode As String = _barcode.Value.ToString()
		Dim errorMessage As String = String.Empty
		_exceptionMessage = String.Empty

		' Memphis 12/10/12 - no real need for a SQL call just to parse a string value, so removed all the sql/sproc stuff & 
		'                    replaced it with the following vb code:
		'
		'assign output variable values here:

		' Memphis 4/12/13 - Bar code has changed to be just Sponsor Lookup ID + Child Lookup ID + “SL”, i.e.;  4156922C226009SL


		If Not String.IsNullOrEmpty(sBarCode) Then
			_sponsorId = sBarCode.Substring(0, _sponsorIdLength)
			If (Not _ISTESTING) AndAlso (Not IsNumeric(_sponsorId)) Then
				errorMessage = errorMessage + "Sponsor Lookup Id isn't a number."
			End If

			' New for 2015, the bar code value is:
			'	10409110572115034555C228263
			'	SponsorId, AppealCode, FinderNumber, ChildId [can be blank]
			' Findernumber is between sponsor id and child id, which begins with "C":
			' 100416585 is a sample findernumber, it's a BigInt in the DB
			'
			Dim resultString As String = String.Empty
			Dim finderLength As Integer = -1
			Dim childStartsAt As Integer = -1

			'The Child Id may not be present so check for it:
			If sBarCode.Contains("C") Then
				'If the ChildID is present then look for it this way:
				'find the length of the start of the finder number:
				childStartsAt = sBarCode.IndexOf("C")
				finderLength = childStartsAt - (_sponsorIdLength + _appealCodeLength)
				resultString = sBarCode.Substring((_sponsorIdLength + _appealCodeLength), finderLength)

				'check the child lookup id since we should have one
				'check if there's a child lookupid value at all:
				If childStartsAt > -1 Then
					'need to check if all of the characters are present:
					If sBarCode.Length < childStartsAt + _childIdLength Then
						'we are missing something:
						errorMessage = errorMessage + "The barcode isn't the correct length. Please check it."
					Else
						_childId = sBarCode.Substring(childStartsAt, _childIdLength)
						If (Not _ISTESTING) AndAlso (Not IsNumeric(_childId.Substring(1, _childIdLength - 1))) Then
							errorMessage = errorMessage + "Child Lookup Id isn't a number."
						End If
					End If
				End If
			Else
				'no child id means we must just start looking at the end of the sponsorid value:
				resultString = sBarCode.Substring((_sponsorIdLength + _appealCodeLength))
			End If

			If Not resultString.Equals(String.Empty) Then
				_finderNumber = Convert.ToInt32(resultString)
			Else
				errorMessage = errorMessage + "Unable to determine the Finder Number from the given bar code."
			End If

			_scanOutcome = ""
		Else
			' check if user manually entered the values in the other fields:
			If (_sponsorLookupId.HasValue = False AndAlso _appealName.HasValue = False AndAlso _childLookupId.Value = False) Then
				_exceptionMessage = "Bar code is empty and No values have been entered by the user!"
			Else
				If ((_sponsorLookupId.HasValue = True AndAlso Not _sponsorLookupId.Value.Equals(String.Empty)) AndAlso (_appealName.HasValue = True AndAlso Not _appealName.Value.Equals(String.Empty))) Then
					'use these values to pass into the sproc
					_sponsorId = _sponsorLookupId.Value.ToString()
					'child lookup id is optional, so see if it has a value or not:
					If _childLookupId.HasValue Then
						_childId = _childLookupId.Value.ToString()
					Else
						_childId = String.Empty
					End If
					_finderNumber = -1	'force the sproc to use the appeal name value
				End If
			End If
		End If

		If Not errorMessage.Equals(String.Empty) Then
			'we must have something wrong
			_exceptionMessage = "Bar code not formatted correctly: " + errorMessage
		End If

	End Sub

	Private Sub ProcessBarCode()
		Dim sBarCode As String = _barcode.Value.ToString()
		Dim sValidationStatus As String = ""

		'If there's an error, then theoretically:
		'scanoutcome will have this value if there was an exception: 'Place the letter on the exception stack.'
		'@ExceptionOccurred will have a value of 1


		Using conn As SqlClient.SqlConnection = Me.GetRequestContext().OpenAppDBConnection()
			Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand()
			cmd.Connection = conn
			cmd.CommandText = "dbo.USR_USP_SPONSORRETENTION_APPEAL_2016_LETTERSCANNER"
			cmd.CommandType = CommandType.StoredProcedure

			cmd.Parameters.AddWithValue("@SponsorLookupID", _sponsorId)
			If _appealName.HasValue Then
				cmd.Parameters.AddWithValue("@AppealName", _appealName.Value.ToString())
			Else
				cmd.Parameters.AddWithValue("@AppealName", "10586")	'DBNull.Value)
			End If
			cmd.Parameters.AddWithValue("@FinderNumber", _finderNumber)
			cmd.Parameters.AddWithValue("@ChangeAgentID", DBNull.Value)
			cmd.Parameters.AddWithValue("@ChildLookupID", _childId)
			cmd.Parameters.AddWithValue("@ScanSession", _scannerSession)


			Dim scannerMessage As SqlParameter = New SqlParameter("@ScannerMessage", String.Empty)
			scannerMessage.Direction = ParameterDirection.Output
			scannerMessage.SqlDbType = SqlDbType.NVarChar
			scannerMessage.Size = 1000
			cmd.Parameters.Add(scannerMessage)

			'ScanOutcome
			Dim scanOutcome As SqlParameter = New SqlParameter("@ScanOutcome", String.Empty)
			scanOutcome.Direction = ParameterDirection.Output
			scanOutcome.SqlDbType = SqlDbType.NVarChar
			scanOutcome.Size = 1000
			cmd.Parameters.Add(scanOutcome)

			Dim exceptionOccurred As SqlParameter = New SqlParameter("@ExceptionOccurred", 0)
			exceptionOccurred.Direction = ParameterDirection.Output
			exceptionOccurred.SqlDbType = SqlDbType.Bit
			cmd.Parameters.Add(exceptionOccurred)

			cmd.ExecuteNonQuery()

			'assign output variable values here:
			_scannerMessage = cmd.Parameters("@ScannerMessage").Value.ToString()
			_scanOutcome = cmd.Parameters("@ScanOutcome").Value.ToString()
			_exceptionOccurred = CBool(cmd.Parameters("@ExceptionOccurred").Value)

		End Using

	End Sub

	Private Function GetScanSession() As String
		'return the unique identifier of this user and scanning session
		Return GetRequestContext().AppUserInfo.AppUserName.ToString() & Date.Now.ToShortDateString() & Date.Now.ToShortTimeString()
	End Function

	Private Function GetLetterStack(ByVal scanOutcome As String) As String
		'determines which letter stack this letter should be placed in
		'extra letter = scanOutcome contains 'Place letter in the Extra Letter stack'
		'exception = Place letter in exception stack
		'success = Place letter on successful scan stack
		Dim letterStack As String = String.Empty
		If scanOutcome.ToLower().Contains("extra") Then
			letterStack = "Extra Letter"
		End If

		If scanOutcome.ToLower().Contains("exception") Then
			letterStack = "Exception"
		End If

		If scanOutcome.ToLower().Contains("successful") Then
			letterStack = "Success"
		End If

		Return letterStack

	End Function

	Private Sub _enterappeal_InvokeAction(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.InvokeActionEventArgs) Handles _enterappeal.InvokeAction
		'turn on/off the extra input fields:
		SetExtraFieldsVisibility(True)
		Me.BARCODE.Value = Nothing
	End Sub

	Private Sub SetExtraFieldsVisibility(ByVal isVisible As Boolean)
		Me.SPONSORLOOKUPID.Visible = isVisible
		Me.APPEALNAME.Visible = isVisible
		Me.CHILDLOOKUPID.Visible = isVisible
		Me.BARCODE.Enabled = Not isVisible
		Me.ENTERAPPEAL.Enabled = Not isVisible
		'If isVisible = True Then
		'	Me.ENTERAPPEAL.Enabled = False
		'Else
		'	Me.ENTERAPPEAL.Enabled = True
		'End If
	End Sub

	Private Function ValidateUserFields() As Boolean
		'the barcode must contain at least a Sponsor Lookup ID, so check for a length at least equal to that
		'  but only if the user is entering into the barcode, otherwise we don't care.
		'String.Format("Bar Code must be at least {0} characters long.", _sponsorIdLength)

		Dim isValid As Boolean = False

		' if the barcode is being used, check its minimum length:
		If _barcode.HasValue Then
			If Not String.IsNullOrEmpty(_barcode.Value.ToString()) Then
				isValid = (_barcode.Value.ToString().Length >= _sponsorIdLength)
				If isValid = False Then
					_invalidEntryReason = String.Format("Bar Code must be at least {0} characters long.", _sponsorIdLength)
				End If
			End If
		End If

		If isValid = False Then
			'if the other fields are visible, then the sponsor & appeal are required, child is optional:
			If (Me.SPONSORLOOKUPID.Visible = True AndAlso Me.SPONSORLOOKUPID.HasValue) AndAlso (Me.APPEALNAME.Visible = True AndAlso Me.APPEALNAME.HasValue) Then
				isValid = True
			End If
			If isValid = False AndAlso _invalidEntryReason.Equals(String.Empty) Then
				_invalidEntryReason = "The Sponsor Lookup ID and the Appeal Name are required if not using the bar code."
			End If
		End If

		Return isValid

	End Function

End Class