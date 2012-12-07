Imports System.Data.SqlClient

Public Class BarCodeAddDataFormUIModel

	Dim _sponsorLookupId As String
	Dim _childLookupId As String
	Dim _letterFullname As String
	Dim _exceptionMessage As String
	Dim _scanOutcome As String
	Dim _scannerSession As String
	Dim _scannerMessage As String
	Dim _exceptionOccurred As Boolean


	Private Sub BarCodeAddDataFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
		Me.SUBMIT.Visible = False
		Me.SUBMIT.Value = False

		_scannerSession = GetScanSession()
		Me.SCANSESSION.Value = _scannerSession

	End Sub

	Private Sub BarCodeAddDataFormUIModel_Validate(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.BeginValidateEventArgs) Handles Me.BeginValidate
		' this function performs form field validation and update
		If IsNothing(_barcode.Value) Then
			_barcode.Value = ""
		End If

		'clear out the variables so they don't stack up:
		_sponsorLookupId = String.Empty
		_childLookupId = String.Empty
		_letterFullname = String.Empty
		_exceptionMessage = String.Empty
		_scanOutcome = String.Empty
		_scannerMessage = String.Empty

		Dim element As BarCodeAddDataFormBARCODEELEMENTSUIModel = New BarCodeAddDataFormBARCODEELEMENTSUIModel()
		element.RESULTSOK.Enabled = False

		If _barcode.Value.ToString().Length = 15 Then
			' call the parse sproc and show results:
			SetParseResults(_barcode.Value.ToString())

			'if the parsing was OK, then call the process sproc:
			If String.IsNullOrEmpty(_exceptionMessage) Then
				'***************************
				'***    FOR TESTING ONLY ***
				'***   Hardcoding these values:
				'*** COMMENT THESE LINES WHEN DONE TESTING:
				'_sponsorLookupId = "8-10000010"	 'Jonny Tester
				'_childLookupId = "8-10000105"	 'Andrew G. asfdasdf
				'_letterFullname = "Child Acknowledgement Letter"
				'
				'******** END OF TEST CODE:

				ProcessBarCode()

				' rename scanstatus to outcome field and add a message field

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

				element.SCANMESSAGE.Value = _scannerMessage
				element.SPONSORLOOKUPID.Value = _sponsorLookupId
				element.CHILDLOOKUPID.Value = _childLookupId
				element.LETTERNAME.Value = _letterFullname
			Else
				element.SCANSTATUS.ValueDisplayStyle = Blackbaud.AppFx.UIModeling.Core.ValueDisplayStyle.WarningImageAndText
				element.RESULTSOK.Value = False
				'Make the Scan Status be: "Success" or "Unsuccessful"
				element.SCANSTATUS.Value = IIf(_scanOutcome.Contains("successful"), "Success!", "Unsuccessful")	'  _scanOutcome
				'element.BARCODE.Value = _barcode.Value.ToString()
				element.SPONSORLOOKUPID.Value = _sponsorLookupId
				element.CHILDLOOKUPID.Value = _childLookupId
				element.EXCEPTION.ValueDisplayStyle = Blackbaud.AppFx.UIModeling.Core.ValueDisplayStyle.BadImageAndText
				element.EXCEPTION.Value = _exceptionMessage.ToString()
				element.LETTERNAME.Value = _letterFullname
			End If

			'clear out the barcode field:
			Me.BARCODE.Value = String.Empty
			_barcode.Value = String.Empty

		Else
			' Bar code is not correctly formatted, do not parse the string but add original bar code value and invalid status into the gridview
			element.BARCODE.Value = _barcode.Value.ToString()
			element.SCANSTATUS.ValueDisplayStyle = Blackbaud.AppFx.UIModeling.Core.ValueDisplayStyle.WarningImageAndText
			element.SCANSTATUS.Value = "Unsuccessful"
			element.EXCEPTION.ValueDisplayStyle = Blackbaud.AppFx.UIModeling.Core.ValueDisplayStyle.BadImageAndText
			element.EXCEPTION.Value = "Bar Code must be 15 characters long."
			element.RESULTSOK.Value = False
			'set the scan outcome to something so it's displayed below for the invalid reason:
			_scanOutcome = "Unable to read Bar Code: must be 15 characters long."
		End If

		BARCODEELEMENTS.Value.Add(element)

		' if SUBMIT checkbox is checked, we will actually safe the data and close the form (the validation status will be true in this case)
		e.Valid = SUBMIT.Value

		If Not e.Valid Then
			' the user did not check the SUBMIT checkbox => we are not going to close the form yet
			' so, we have to set e.InvalidReason to be a non-blank string
			e.InvalidReason = "Results: " & _scanOutcome & " " & _scannerMessage & " " & _exceptionMessage	'_sponsorLookupId & " " & _childLookupId & " " & _letterFullname & " " & _exceptionMessage
		End If

	End Sub

	Private Sub SetParseResults(ByVal barCode As String)
		Dim sBarCode As String = _barcode.Value.ToString()
		Dim sValidationStatus As String = ""

		Using conn As SqlClient.SqlConnection = Me.GetRequestContext().OpenAppDBConnection()
			Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand()
			cmd.Connection = conn
			cmd.CommandText = "dbo.USR_USP_PARSERAISERSEDGEBARCODE"
			cmd.CommandType = CommandType.StoredProcedure

			cmd.Parameters.AddWithValue("@BarcodeString", barCode)

			Dim sponsorLookupId As SqlParameter = New SqlParameter("@SponsorLookupID", String.Empty)
			sponsorLookupId.Direction = ParameterDirection.Output
			sponsorLookupId.SqlDbType = SqlDbType.NVarChar
			sponsorLookupId.Size = 6
			cmd.Parameters.Add(sponsorLookupId)

			Dim childLookupId As SqlParameter = New SqlParameter("@ChildLookupID", String.Empty)
			childLookupId.Direction = ParameterDirection.Output
			childLookupId.SqlDbType = SqlDbType.NVarChar
			childLookupId.Size = 7
			cmd.Parameters.Add(childLookupId)

			Dim letterFullname As SqlParameter = New SqlParameter("@LetterFullname", String.Empty)
			letterFullname.Direction = ParameterDirection.Output
			letterFullname.SqlDbType = SqlDbType.NVarChar
			letterFullname.Size = 100
			cmd.Parameters.Add(letterFullname)

			Dim exceptionMessage As SqlParameter = New SqlParameter("@ExceptionMessage", String.Empty)
			exceptionMessage.Direction = ParameterDirection.Output
			exceptionMessage.SqlDbType = SqlDbType.NVarChar
			exceptionMessage.Size = 1000
			cmd.Parameters.Add(exceptionMessage)

			'ScanOutcome
			Dim scanOutcome As SqlParameter = New SqlParameter("@ScanOutcome", String.Empty)
			scanOutcome.Direction = ParameterDirection.Output
			scanOutcome.SqlDbType = SqlDbType.NVarChar
			scanOutcome.Size = 100
			cmd.Parameters.Add(scanOutcome)

			cmd.ExecuteNonQuery()

			'assign output variable values here:
			_sponsorLookupId = cmd.Parameters("@SponsorLookupID").Value.ToString()
			_childLookupId = cmd.Parameters("@ChildLookupID").Value.ToString()
			_letterFullname = cmd.Parameters("@LetterFullname").Value.ToString()
			_exceptionMessage = cmd.Parameters("@ExceptionMessage").Value.ToString()
			_scanOutcome = cmd.Parameters("@ScanOutcome").Value.ToString()

		End Using

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
			cmd.CommandText = "dbo.USR_USP_RE_CRM_CHILDLETTERSCANNER"
			cmd.CommandType = CommandType.StoredProcedure

			cmd.Parameters.AddWithValue("@SponsorLookupID", _sponsorLookupId)
			cmd.Parameters.AddWithValue("@ChildLookupID", _childLookupId)
			cmd.Parameters.AddWithValue("@LetterFullname", _letterFullname)
			cmd.Parameters.AddWithValue("@ChangeAgentID", DBNull.Value)
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
			scanOutcome.Size = 100
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

End Class