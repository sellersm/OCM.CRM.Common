Imports System.Data.SqlClient
Imports System.Threading
'Imports System.Windows.Forms
Imports System.Reflection
Imports Blackbaud.AppFx.XmlTypes.DataForms
Imports System.IO
Imports System.Xml
Imports System.Text
Imports Blackbaud.AppFx.XmlTypes
Imports System.Runtime.CompilerServices

Public Class RateChangeResponseScannerFormUIModel
	Private _sponsorId As String
	Private _childId As String
	Private _letterFullname As String
	Private _exceptionMessage As String
	Private _scanOutcome As String
	Private _scannerSession As String
	Private _scannerMessage As String
	Private _exceptionOccurred As Boolean
	Private _interactionSequenceId As Integer
	Private _letterType As String
	Private _finderNumber As Integer

	'  Needed for the GUI updating:
	Private _commitStarted As Boolean
	Private WithEvents backgroundWorker1 As BackgroundWorker
	Private _dataLoaded As Boolean = False

	Private Const LETTERTYPEVALUE As String = "SL"

	'used for Xml Serialization:
	Private _dataFormItemFieldValueSerializer As Xml.Serialization.XmlSerializer

	' using these variables to make testing easier
	'************** CHANGE VALUES BACK AFTER TESTING! ***************
	Private _ISTESTING As Boolean = False
	Private _sponsorIdLength As Integer = 6
	'Private _childIdLength As Integer = 7
	'Private _letterTypeLength As Integer = 2
	Private _barCodeLength As Integer = _sponsorIdLength '+ _childIdLength + _letterTypeLength ' + _interactionIdLength

	Private Sub RateChangeResponseScannerFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
		Me.SUBMIT.Visible = False
		Me.SUBMIT.Value = False
		_commitStarted = False
		_dataLoaded = False
	End Sub

	Private Sub RateChangeResponseScannerFormUIModel_BeginValidate(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.BeginValidateEventArgs) Handles Me.BeginValidate
		' this function performs form field validation and update
		If IsNothing(_barcode.Value) Then
			_barcode.Value = ""
		End If

		'clear out the variables so they don't stack up:
		_sponsorId = _barcode.Value

		'reset the collection/datagrid:
		Me.BARCODEELEMENTS.Value.Clear()

		If _barcode.Value.ToString().Length = _barCodeLength Then
			' call the parse sproc and show results:
			'SetParseResults(_barcode.Value.ToString())

			'if the parsing was OK, then call the process sproc:
			If String.IsNullOrEmpty(_exceptionMessage) Then
				ProcessBarCode()

				If _dataLoaded = True Then
					Me.COMMITCHANGESBUTTON.Enabled = True
				End If

				Me.SPONSORLOOKUPID.Value = _sponsorId

				'clear out the barcode field:
				Me.BARCODE.Value = String.Empty
				_barcode.Value = String.Empty
			Else
				Me.SCANSTATUS.ValueDisplayStyle = Blackbaud.AppFx.UIModeling.Core.ValueDisplayStyle.WarningImageAndText

				'Make the Scan Status be: "Success" or "Unsuccessful"
				Me.SCANSTATUS.Value = IIf(_scanOutcome.Contains("successful"), "Success!", "Unsuccessful")	'  _scanOutcome
				'element.BARCODE.Value = _barcode.Value.ToString()
				Me.SPONSORLOOKUPID.Value = _sponsorId
				'element.CHILDLOOKUPID.Value = _childId
			End If

		Else
			'set the scan outcome to something so it's displayed below for the invalid reason:
			_scanOutcome = String.Format("Unable to read Bar Code: must be {0} characters long.", _barCodeLength)
		End If

		' if SUBMIT checkbox is checked, we will actually safe the data and close the form (the validation status will be true in this case)
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

		'assign output variable values here:
		' Bar code is only the Sponsor Lookup Id:

		If Not String.IsNullOrEmpty(sBarCode) Then
			_sponsorId = sBarCode
			If (Not IsNumeric(_sponsorId)) Then
				errorMessage = errorMessage + "Sponsor Lookup Id isn't a number."
			End If
			_scanOutcome = ""
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
			cmd.CommandText = "dbo.USR_USP_RATECHANGE_RESPONSE_SCANNER"
			cmd.CommandType = CommandType.StoredProcedure

			cmd.Parameters.AddWithValue("@LOOKUPID", _sponsorId)

			Dim rateChangeSponsorships As DataTable = New DataTable
			rateChangeSponsorships.Load(cmd.ExecuteReader)

			Dim rateChangeRow As RateChangeResponseScannerFormBARCODEELEMENTSUIModel = New RateChangeResponseScannerFormBARCODEELEMENTSUIModel()

			Dim increaseRate As Boolean = False	   'flag is set based on the segment category of this sponsor's appeal

			For Each row As DataRow In rateChangeSponsorships.Rows
				rateChangeRow = New RateChangeResponseScannerFormBARCODEELEMENTSUIModel()
				Me.SPONSORNAME.Value = row(0)						'conSponsor.[NAME]
				rateChangeRow.CHILDNAME.Value = row(1)				'soc.[NAME]
				rateChangeRow.SPONSORSHIPCOMMITMENTID.Value = row(2)   'sc.LOOKUPID
				rateChangeRow.CHILDLOOKUPID.Value = row(3)			'so.LOOKUPID
				rateChangeRow.REVENUELOOKUPID.Value = row(4)		'r.LOOKUPID
				rateChangeRow.CURRENTRGAMOUNT.Value = row(5)		'r.AMOUNT
				rateChangeRow.RGFREQUENCY.Value = row(6)			'dbo.REVENUESCHEDULE.FREQUENCY
				rateChangeRow.SPONSORLOOKUPID.Value = _sponsorId
				rateChangeRow.SPONSORSHIPID.Value = row(7)			's.ID which is sponsorship id
				rateChangeRow.SPONSORID.Value = row(8)				'SponsorId guid
				rateChangeRow.SEGMENTCATEGORY.Value = row(9)		' SEGMENTCATEGORY
				rateChangeRow.CONSTITUENTAPPEALID.Value = row(10)	' CONSTITUENTAPPEALID
				'  *** TODO:  Need to figure out the new rate based on RG frequency and IncreaseRate boolean bit flag:
				Select Case rateChangeRow.SEGMENTCATEGORY.Value.ToLower()
					Case "rate increase - opt in"
						increaseRate = True

					Case "rate increase - opt out"
						increaseRate = False

					Case "rate increase - no increase letter"
						increaseRate = True

					Case Else
						increaseRate = False
				End Select

				rateChangeRow.RATEINCREASE.Value = increaseRate

				If increaseRate = True Then
					Select Case rateChangeRow.RGFREQUENCY.Value.ToLower()
						Case "monthly"
							rateChangeRow.NEWRGAMOUNT.Value = 39.0

						Case "annually"
							rateChangeRow.NEWRGAMOUNT.Value = (39.0 * 12)

						Case "quarterly"
							rateChangeRow.NEWRGAMOUNT.Value = (39.0 * 4)

						Case "semi-annually"
							rateChangeRow.NEWRGAMOUNT.Value = (39.0 * 6)

						Case "semi-monthly"
							rateChangeRow.NEWRGAMOUNT.Value = (39.0 / 2)

						Case "bimonthly"
							rateChangeRow.NEWRGAMOUNT.Value = (39 * 2)

						Case Else
							rateChangeRow.NEWRGAMOUNT.Value = 39.0

					End Select
				Else
					rateChangeRow.NEWRGAMOUNT.Value = rateChangeRow.CURRENTRGAMOUNT.Value
				End If

				BARCODEELEMENTS.Value.Add(rateChangeRow)
			Next
			_dataLoaded = True
		End Using

	End Sub


	'Private Function GetScanSession() As String
	'	'return the unique identifier of this user and scanning session
	'	Return GetRequestContext().AppUserInfo.AppUserName.ToString() & Date.Now.ToShortDateString() & Date.Now.ToShortTimeString()
	'End Function

	'Private Function GetLetterStack(ByVal scanOutcome As String) As String
	'	'determines which letter stack this letter should be placed in
	'	'extra letter = scanOutcome contains 'Place letter in the Extra Letter stack'
	'	'exception = Place letter in exception stack
	'	'success = Place letter on successful scan stack
	'	Dim letterStack As String = String.Empty
	'	If scanOutcome.ToLower().Contains("extra") Then
	'		letterStack = "Extra Letter"
	'	End If

	'	If scanOutcome.ToLower().Contains("exception") Then
	'		letterStack = "Exception"
	'	End If

	'	If scanOutcome.ToLower().Contains("successful") Then
	'		letterStack = "Success"
	'	End If

	'	Return letterStack

	'End Function


	Private Sub _commitchangesbutton_InvokeAction(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.InvokeActionEventArgs) Handles _commitchangesbutton.InvokeAction
		'DisplayPrompt("Inside of Button Click!")
		_commitStarted = True

		'Me.backgroundWorker1 = New BackgroundWorker
		'backgroundWorker1.WorkerReportsProgress = True
		'backgroundWorker1.WorkerSupportsCancellation = True
		'AddHandler backgroundWorker1.RunWorkerCompleted, New RunWorkerCompletedEventHandler(AddressOf backgroundWorker1_RunWorkerCompleted)
		'AddHandler backgroundWorker1.DoWork, New DoWorkEventHandler(AddressOf backgroundWorker1_DoWork)

		'this should turn off save button, save the user changes, reset everything and turn back on the save button:
		Me.SaveButtonCaption = "Disabled"
		EnableSaveButton(False)

		Me.COMMITCHANGESBUTTON.Enabled = False

		SaveRateIncreaseResponses()

		'clear out fields, reset for next scan:
		Me.SPONSORNAME.Value = String.Empty
		Me.SPONSORLOOKUPID.Value = String.Empty
		Me.BARCODEELEMENTS.Value.Clear()

	End Sub

	Private Sub SaveRateIncreaseResponses()
		'add the code that gets the handle from the UI Thread to change the value:
		If _commitStarted = True Then
			'save the data
			Dim val As DataFormItemArrayValue
			val = Me.BARCODEELEMENTS.ToDataFormItemArrayValue(True)

			Dim output As New StringBuilder()
			Dim xmlWriter__1 As XmlWriter = XmlWriter.Create(output)
			WriteRateIncreaseCollectionXml(xmlWriter__1, "RATECHANGE", val)
			xmlWriter__1.Close()
			Dim xmlString As String = output.ToString()

			_commitStarted = False

			Using conn As SqlClient.SqlConnection = Me.GetRequestContext().OpenAppDBConnection()
				Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand()
				cmd.Connection = conn
				cmd.CommandText = "dbo.USR_USP_RATEINCREASE_RESPONSES_ADDFROMXML"
				cmd.CommandType = CommandType.StoredProcedure

				' @SPONSORLOOKUPID nvarchar(100),
				' @XML xml,
				' @CHANGEAGENTID uniqueidentifier = null,
				' @DATEADDED datetime = null,
				' @CHANGEYEAR dbo.UDT_YEAR = null,
				' @RESPONSEDATE datetime = null,
				' @RESPONDAFTERRATECHANGEUPDATED bit = 0,
				' @RESPONSEIFAFTERRATECHANGEIMPLEMENTEDCODEID uniqueidentifier = null
				cmd.Parameters.AddWithValue("@SPONSORLOOKUPID", _sponsorId)
				cmd.Parameters.AddWithValue("@XML", xmlString)
				cmd.Parameters.AddWithValue("@CHANGEAGENTID", DBNull.Value)
				cmd.Parameters.AddWithValue("@DATEADDED", DateTime.Now)
				cmd.Parameters.AddWithValue("@CHANGEYEAR", 2014)
				cmd.Parameters.AddWithValue("@RESPONSEDATE", DateTime.Now)
				cmd.Parameters.AddWithValue("@RESPONDAFTERRATECHANGEUPDATED", False)
				cmd.Parameters.AddWithValue("@RESPONSEIFAFTERRATECHANGEIMPLEMENTEDCODEID", DBNull.Value)

				cmd.ExecuteNonQuery()

				DisplayPrompt("Data saved...")

				Me.COMMITCHANGESBUTTON.Enabled = False
				Me.SaveButtonCaption = "Save"
				EnableSaveButton(True)

			End Using

		End If

	End Sub

	'not using Backgroundworker right now:
	'Private Sub backgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles backgroundWorker1.DoWork
	'	DisplayPrompt("Inside of DoWork!")

	'	If _commitStarted = True Then
	'		'add the code that gets the handle from the UI Thread to change the value:
	'		Me.COMMITCHANGESBUTTON.Enabled = False
	'		EnableSaveButton(False)

	'		'save the data
	'		' this is just a test to determine if we can get the rows in the collection and its data:
	'		'Me.BARCODEELEMENTS.SelectAllItems()

	'		Dim val As DataFormItemArrayValue
	'		val = Me.BARCODEELEMENTS.ToDataFormItemArrayValue(True)

	'		Dim output As New StringBuilder()
	'		Dim xmlWriter__1 As XmlWriter = XmlWriter.Create(output)
	'		WriteRateIncreaseCollectionXml(xmlWriter__1, "RATECHANGE", val)
	'		xmlWriter__1.Close()
	'		Dim xmlString As String = output.ToString()

	'		'DisplayPrompt(xmlString)

	'		'Dim fs As New FileStream("C:\Backups\RateIncrease.xml", FileMode.Create)
	'		Dim mydocpath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
	'		Using outfile As New StreamWriter("C:\Backups\RateChange.xml")
	'			outfile.Write(xmlString)
	'			outfile.Close()
	'		End Using
	'		_commitStarted = False
	'		'_dataLoaded = True
	'		DisplayPrompt("File created...")
	'	End If


	'End Sub

	Private Sub DisplayPrompt(ByVal message As String)
		Me.Prompts.Add(New UIPrompt() With { _
		 .Text = message, _
		 .ButtonStyle = UIPromptButtonStyle.Ok})
	End Sub

	' declare an implementation with matching signature
	Private Sub EnableSaveButton(ByVal buttonValue As Boolean)
		Me.SaveButtonEnabled = buttonValue
	End Sub

	'don't need this right now, not using bgworker:
	'Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
	'	If e.Error IsNot Nothing Then
	'		DisplayPrompt(e.Error.Message)
	'	End If

	'	If e.Cancelled = True Then
	'		EnableSaveButton(True)
	'	ElseIf e.Error IsNot Nothing Then
	'		EnableSaveButton(True)
	'	Else
	'		EnableSaveButton(True)
	'	End If

	'	'_dataLoaded = True
	'	_commitStarted = False

	'	'DisplayPrompt("RunWorkerCompleted!")

	'End Sub


	'Private Delegate Sub SetControlValueCallback(ByVal oControl As Control, ByVal propName As String, ByVal propValue As Object)
	'Private Sub SetControlPropertyValue(ByVal oControl As Control, ByVal propName As String, ByVal propValue As Object)
	'	If oControl.InvokeRequired Then
	'		Dim d As New SetControlValueCallback(AddressOf SetControlPropertyValue)
	'		oControl.Invoke(d, New Object() {oControl, propName, propValue})
	'	Else
	'		Dim t As Type = oControl.[GetType]()
	'		Dim props As PropertyInfo() = t.GetProperties()
	'		For Each p As PropertyInfo In props
	'			If p.Name.ToUpper() = propName.ToUpper() Then
	'				p.SetValue(oControl, propValue, Nothing)
	'			End If
	'		Next
	'	End If
	'End Sub

	Private ReadOnly Property XmlSerializerForDataFormItemFieldValues() As Xml.Serialization.XmlSerializer
		Get
			If _dataFormItemFieldValueSerializer Is Nothing Then
				_dataFormItemFieldValueSerializer = XmlTypes.DataForms.DataFormFieldValue.CreateDataFormFieldValueXmlSerializer
			End If
			Return _dataFormItemFieldValueSerializer
		End Get
	End Property

	' this is from the blackbaud UIModel core class:
	'Private Shared Sub WriteDataFormItemsXml(ByVal xmlWriter As XmlWriter, ByVal fieldName As String, ByVal itemArray As DataFormItemArrayValue, ByVal descriptor As CollectionFieldDescriptor)
	'	xmlWriter.WriteStartElement(fieldName.ToUpper())
	'	Dim items As DataFormItem() = Nothing
	'	If itemArray IsNot Nothing Then
	'		items = itemArray.Items
	'	End If
	'	If items IsNot Nothing Then
	'		For Each item As DataFormItem In items
	'			xmlWriter.WriteStartElement("ITEM")
	'			If descriptor IsNot Nothing Then
	'				For Each field As FormField In descriptor.Fields
	'					Dim value2 As DataFormFieldValue = Nothing
	'					item.Values.TryGetValue(field.FieldID, value2)
	'					If (value2 IsNot Nothing) AndAlso (value2.Value IsNot Nothing) Then
	'						If field.DataType = FormFieldDataType.[Date] Then
	'							xmlWriter.WriteElementString(value2.ID, XmlConvert.ToString(DirectCast(value2.Value, DateTime), XmlDateTimeSerializationMode.Unspecified))
	'						ElseIf field.IsCollectionField Then
	'							WriteDataFormItemsXml(xmlWriter, field.FieldID, DirectCast(value2.Value, DataFormItemArrayValue), field.CollectionDescriptor)
	'						Else
	'							Dim objectValue As Object = RuntimeHelpers.GetObjectValue(value2.Value)
	'							Dim str As String = String.Empty
	'							If TypeOf objectValue Is Decimal Then
	'								str = XmlConvert.ToString(CDec(objectValue))
	'							ElseIf TypeOf objectValue Is Double Then
	'								str = XmlConvert.ToString(CDbl(objectValue))
	'							ElseIf TypeOf objectValue Is Single Then
	'								str = XmlConvert.ToString(CSng(objectValue))
	'							Else
	'								str = objectValue.ToString()
	'							End If
	'							xmlWriter.WriteElementString(value2.ID, str)
	'						End If
	'					End If
	'				Next
	'			End If
	'			xmlWriter.WriteEndElement()
	'		Next
	'	End If
	'	xmlWriter.WriteEndElement()
	'End Sub


	Private Shared Sub WriteRateIncreaseCollectionXml(ByVal xmlWriter As XmlWriter, ByVal fieldName As String, ByVal itemArray As DataFormItemArrayValue)
		xmlWriter.WriteProcessingInstruction("xml", "version=""1.0""")
		xmlWriter.WriteStartElement(fieldName.ToUpper())
		Dim items As DataFormItem() = Nothing
		If itemArray IsNot Nothing Then
			items = itemArray.Items
		End If
		If items IsNot Nothing Then
			For Each item As DataFormItem In items
				xmlWriter.WriteStartElement("ITEM")

				For Each fieldValue As DataFormFieldValue In item.Values
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(fieldValue.Value)
					Dim str As String = String.Empty
					If TypeOf objectValue Is Decimal Then
						str = XmlConvert.ToString(CDec(objectValue))
					ElseIf TypeOf objectValue Is Double Then
						str = XmlConvert.ToString(CDbl(objectValue))
					ElseIf TypeOf objectValue Is Single Then
						str = XmlConvert.ToString(CSng(objectValue))
					Else
						str = objectValue.ToString()
					End If
					xmlWriter.WriteElementString(fieldValue.ID, str)
				Next

				xmlWriter.WriteEndElement()
			Next
		End If
		xmlWriter.WriteEndElement()

	End Sub


End Class