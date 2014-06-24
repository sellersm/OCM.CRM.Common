Imports System.Data.SqlClient

Public Class CRMAnnualLetterScannerAddDataFormUIModel

    Private _sponsorLookupId As String
    Private _childLookupId As String
    Private _letterFullname As String
    Private _exceptionMessage As String
    Private _scanOutcome As String
    Private _scannerSession As String
    Private _scannerMessage As String
    Private _exceptionOccurred As Boolean
    Private _setPrintBlackoutLabel As Boolean
    Private _interactionSequenceId As Integer
    Private _childProjectLookupId As String
    Private _sponsorName As String
    Private _sponsorSalutation As String

    ' using these variables to make testing easier
    '************** CHANGE VALUES BACK AFTER TESTING! ***************
    ' barcode is something like this: 067776C120089IN02819249952
    Private _ISTESTING As Boolean = False
    Private _sponsorIdLength As Integer = 6
    Private _childIdLength As Integer = 7
    Private _projectIdLength As Integer = 5
    Private _interactionIdLength As Integer = 8  ' 8
    Private _barCodeLength As Integer = _sponsorIdLength + _childIdLength + _projectIdLength + _interactionIdLength

    Private Sub CRMChildLetterScannerAddDataFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
        Me.SUBMIT.Visible = False
        Me.SUBMIT.Value = False

        _scannerSession = GetScanSession()
        Me.SCANSESSION.Value = _scannerSession

    End Sub

    Private Sub CRMChildLetterScannerAddDataFormUIModel_Validate(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.BeginValidateEventArgs) Handles Me.BeginValidate
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
        '_interactionSequenceId = 0
        _childProjectLookupId = String.Empty
        _exceptionOccurred = False
        _setPrintBlackoutLabel = False
        _sponsorName = String.Empty
        _sponsorSalutation = String.Empty

		Dim element As CRMAnnualLetterScannerAddDataFormBARCODEELEMENTSUIModel = New CRMAnnualLetterScannerAddDataFormBARCODEELEMENTSUIModel()
        element.RESULTSOK.Enabled = False

        If _barcode.Value.ToString().Length = _barCodeLength Then
            ' call the parse sproc and show results:
            SetParseResults(_barcode.Value.ToString())

            'if the parsing was OK, then call the process sproc:
            If String.IsNullOrEmpty(_exceptionMessage) Then
                '***************************
                '*** BE SURE THE _ISTETSING FLAG IS SET TO FALSE WHEN DEPLOYING:
                If _ISTESTING Then
                    '_sponsorLookupId = "8-10000150"		'Lester t. Jester
                    '_childLookupId = "8-10000065"		'Andrea G. McKeehan
                    '_interactionSequenceId = 10000180
                    '_childProjectLookupId = "8-10000000"
                    '******** END OF TEST CODE:
                End If

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
                If element.LETTERSTACK.Value.ToString().Contains("Exception") Then
                    element.LETTERSTACK.ValueDisplayStyle = ValueDisplayStyle.BadTextOnly
                Else
                    element.LETTERSTACK.ValueDisplayStyle = ValueDisplayStyle.GoodTextOnly
                End If

                element.SCANMESSAGE.Value = _scannerMessage
                element.SPONSORLOOKUPID.Value = _sponsorLookupId
                element.CHILDLOOKUPID.Value = _childLookupId
                element.CHILDPROJECTLOOKUPID.Value = _childProjectLookupId
                element.SETPRINTBLACKOUTLABEL.Value = _setPrintBlackoutLabel
                element.SPONSORNAME.Value = _sponsorName
                element.SPONSORSALUTATION.Value = _sponsorSalutation

                'clear out the barcode field:
                Me.BARCODE.Value = String.Empty
                _barcode.Value = String.Empty
            Else
                element.SCANSTATUS.ValueDisplayStyle = Blackbaud.AppFx.UIModeling.Core.ValueDisplayStyle.WarningImageAndText
                element.RESULTSOK.Value = False
                'Make the Scan Status be: "Success" or "Unsuccessful"
                element.SCANSTATUS.Value = IIf(_scanOutcome.Contains("successful"), "Success!", "Unsuccessful") '  _scanOutcome
                'element.BARCODE.Value = _barcode.Value.ToString()
                element.SPONSORLOOKUPID.Value = _sponsorLookupId
                element.CHILDLOOKUPID.Value = _childLookupId
                element.EXCEPTION.ValueDisplayStyle = Blackbaud.AppFx.UIModeling.Core.ValueDisplayStyle.BadImageAndText
                element.EXCEPTION.Value = _exceptionMessage.ToString()
                element.CHILDPROJECTLOOKUPID.Value = _childProjectLookupId
                element.SPONSORNAME.Value = _sponsorName
                element.SPONSORSALUTATION.Value = _sponsorSalutation

                'figure out which Letter Stack this letter should go into:
                element.LETTERSTACK.Value = GetLetterStack(_scanOutcome)
                If element.LETTERSTACK.Value.ToString().ToLower().Contains("exception") Then
                    element.LETTERSTACK.ValueDisplayStyle = ValueDisplayStyle.BadTextOnly
                Else
                    element.LETTERSTACK.ValueDisplayStyle = ValueDisplayStyle.GoodTextOnly
                End If
            End If

        Else
            ' Bar code is not correctly formatted, do not parse the string but add original bar code value and invalid status into the gridview
            element.BARCODE.Value = _barcode.Value.ToString()
            element.SCANSTATUS.ValueDisplayStyle = Blackbaud.AppFx.UIModeling.Core.ValueDisplayStyle.WarningImageAndText
            element.SCANSTATUS.Value = "Unsuccessful"
            element.EXCEPTION.ValueDisplayStyle = Blackbaud.AppFx.UIModeling.Core.ValueDisplayStyle.BadImageAndText
            element.EXCEPTION.Value = String.Format("Bar Code must be {0} characters long.", _barCodeLength)
            element.RESULTSOK.Value = False
            'set the scan outcome to something so it's displayed below for the invalid reason:
            _scanOutcome = String.Format("Unable to read Bar Code: must be {0} characters long.", _barCodeLength)
        End If

        BARCODEELEMENTS.Value.Add(element)

        ' if SUBMIT checkbox is checked, we will actually safe the data and close the form (the validation status will be true in this case)
        e.Valid = SUBMIT.Value

        If Not e.Valid Then
            ' the user did not check the SUBMIT checkbox => we are not going to close the form yet
            ' so, we have to set e.InvalidReason to be a non-blank string
            e.InvalidReason = "Results: " & _scanOutcome & " " & _scannerMessage & " " & _exceptionMessage  '_sponsorLookupId & " " & _childLookupId & " " & _letterFullname & " " & _exceptionMessage
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

        If Not String.IsNullOrEmpty(sBarCode) Then
            'Sponsor should be 6 characters, child 7 characters, child project 6 characters, interaction sequence 10 digits
            _sponsorLookupId = sBarCode.Substring(0, _sponsorIdLength)
            If (Not _ISTESTING) AndAlso (Not IsNumeric(_sponsorLookupId)) Then
                errorMessage = errorMessage + "Sponsor Lookup Id isn't a number."
            End If

            _childLookupId = sBarCode.Substring(_sponsorIdLength, _childIdLength)
            If (Not _ISTESTING) AndAlso (Not IsNumeric(_childLookupId.Substring(1, _childIdLength - 1))) Then
                errorMessage = errorMessage + "Child Lookup Id isn't a number."
            End If

            _childProjectLookupId = sBarCode.Substring(_sponsorIdLength + _childIdLength, _projectIdLength)
            'If (Not _ISTESTING) AndAlso (Not IsNumeric(_childProjectLookupId)) Then
            '	errorMessage = errorMessage + "Child Proejct Lookup Id isn't a number."
            'End If

            If Not Integer.TryParse(sBarCode.Substring(_sponsorIdLength + _childIdLength + _projectIdLength, _interactionIdLength), _interactionSequenceId) Then
                'interaction sequence is actually an INT so it must be a number, even in testing.
                'If (Not IsNumeric(_interactionSequenceId)) Then
                errorMessage = errorMessage + "Interaction Sequence Id isn't a number."
            End If

            _scanOutcome = ""
        Else
            _exceptionMessage = "Bar code is empty!"
        End If

        If Not errorMessage.Equals(String.Empty) Then
            'we must have something wrong
            _exceptionMessage = "Bar code not formatted correct: " + errorMessage
        End If

    End Sub

    Private Sub ProcessBarCode()
        Dim sBarCode As String = _barcode.Value.ToString()
        'Dim sValidationStatus As String = ""

        'If there's an error, then theoretically:
        'scanoutcome will have this value if there was an exception: 'Place the letter on the exception stack.'
        '@ExceptionOccurred will have a value of 1

        Using conn As SqlClient.SqlConnection = Me.GetRequestContext().OpenAppDBConnection()
            Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand()
            cmd.Connection = conn
            cmd.CommandText = "dbo.USR_USP_CRM_ANNUAL_LETTER_SCANNER"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@SponsorLookupID", _sponsorLookupId)
            cmd.Parameters.AddWithValue("@ChildLookupID", _childLookupId)
            cmd.Parameters.AddWithValue("@ChildProjectLookupID", _childProjectLookupId)
            cmd.Parameters.AddWithValue("@InteractionSequenceId", _interactionSequenceId)
            cmd.Parameters.AddWithValue("@ScanSession", _scannerSession)
            cmd.Parameters.AddWithValue("@ChangeAgentID", DBNull.Value)

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

            Dim setPrintBlackoutLabel As SqlParameter = New SqlParameter("@setPrintBlackoutLabel", 0)
            setPrintBlackoutLabel.Direction = ParameterDirection.Output
            setPrintBlackoutLabel.SqlDbType = SqlDbType.Bit
            cmd.Parameters.Add(setPrintBlackoutLabel)

            Dim sponsorName As SqlParameter = New SqlParameter("@SponsorName", String.Empty)
            sponsorName.Direction = ParameterDirection.Output
            sponsorName.SqlDbType = SqlDbType.NVarChar
            sponsorName.Size = 154
            cmd.Parameters.Add(sponsorName)

            Dim sponsorSalutation As SqlParameter = New SqlParameter("@SponsorSalutation", String.Empty)
            sponsorSalutation.Direction = ParameterDirection.Output
            sponsorSalutation.SqlDbType = SqlDbType.NVarChar
            sponsorSalutation.Size = 700
            cmd.Parameters.Add(sponsorSalutation)


            cmd.ExecuteNonQuery()

            'assign output variable values here:
            _scannerMessage = cmd.Parameters("@ScannerMessage").Value.ToString()
            _scanOutcome = cmd.Parameters("@ScanOutcome").Value.ToString()
            _exceptionOccurred = CBool(cmd.Parameters("@ExceptionOccurred").Value)
            _setPrintBlackoutLabel = CBool(cmd.Parameters("@setPrintBlackoutLabel").Value)
            _sponsorName = cmd.Parameters("@SponsorName").Value.ToString()
            _sponsorSalutation = cmd.Parameters("@SponsorSalutation").Value.ToString()

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