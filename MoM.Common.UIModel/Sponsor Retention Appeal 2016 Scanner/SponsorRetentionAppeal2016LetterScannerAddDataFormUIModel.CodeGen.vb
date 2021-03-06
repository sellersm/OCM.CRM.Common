﻿Option Strict On
Option Explicit On
Option Infer On

'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by BBUIModelLibrary
'     Version:  2.93.2034.0
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
''' <summary>
''' Represents the UI model for the 'Sponsor Retention Appeal 2016 Letter Scanner Add Data Form' data form
''' </summary>
<Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModelMetadata(Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Add, "56a13010-3564-4ccf-85a8-78293412f572", "2dcd98d0-4659-41e1-ba6d-c02911aee5ad", "Letterscanner")> _
Partial Public Class [SponsorRetentionAppeal2016LetterScannerAddDataFormUIModel]
	Inherits Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModel

#Region "Extensibility methods"

    Partial Private Sub OnCreated()
    End Sub

#End Region

	Private WithEvents _barcode As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	Private WithEvents _barcodeelements As Global.Blackbaud.AppFx.UIModeling.Core.CollectionField(Of SponsorRetentionAppeal2016LetterScannerAddDataFormBARCODEELEMENTSUIModel)
	Private WithEvents _submit As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
	Private WithEvents _itemsenclosedcodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
	Private WithEvents _scansession As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	Private WithEvents _sponsorLookupId As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	Private WithEvents _appealName As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	Private WithEvents _childLookupId As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	Private WithEvents _enterappeal As Global.Blackbaud.AppFx.UIModeling.Core.GenericUIAction

	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public Sub New()
        MyBase.New()

		_barcode = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_barcodeelements = New Global.Blackbaud.AppFx.UIModeling.Core.CollectionField(Of SponsorRetentionAppeal2016LetterScannerAddDataFormBARCODEELEMENTSUIModel)
		_submit = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
		_sponsorLookupId = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		'_appealid = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_childLookupId = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_itemsenclosedcodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
		_scansession = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_appealName = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_enterappeal = New Global.Blackbaud.AppFx.UIModeling.Core.GenericUIAction

        MyBase.Mode = Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Add
        MyBase.DataFormTemplateId = New Guid("56a13010-3564-4ccf-85a8-78293412f572")
        MyBase.DataFormInstanceId = New Guid("2dcd98d0-4659-41e1-ba6d-c02911aee5ad")
        MyBase.RecordType = "Letterscanner"
        MyBase.FORMHEADER.Value = "Scan Sponsor Retention Appeal 2016"
		MyBase.UserInterfaceUrl = "browser/htmlforms/custom/SponsorRetentionAppeal2016LetterScannerAddDataForm.html"

		'
		'_barcode
		'
		_barcode.Name = "BARCODE"
		_barcode.Caption = "Bar code"
		_barcode.MaxLength = 100
		Me.Fields.Add(_barcode)
		'
		'_barcodeelements
		'
		_barcodeelements.Name = "BARCODEELEMENTS"
		_barcodeelements.Caption = "Results"
		_barcodeelements.AllowDelete = False
		_barcodeelements.EnablePaging = True
		_barcodeelements.ItemsPerPage = 10
		Me.Fields.Add(_barcodeelements)
		'
		'_submit
		'
		_submit.Name = "SUBMIT"
		_submit.Caption = "Save results"
		Me.Fields.Add(_submit)

		'
		'_itemsenclosedcodeid
		'
		_itemsenclosedcodeid.Caption = "Items enclosed"
		_itemsenclosedcodeid.Name = "ITEMSENCLOSEDCODEID"
		_itemsenclosedcodeid.Required = False
		_itemsenclosedcodeid.CodeTableName = "USR_ITEMSENCLOSEDCODE"
		Me.Fields.Add(_itemsenclosedcodeid)

		'
		'_scansession
		'
		_scansession.Caption = "Scan session"
		_scansession.Name = "SCANSESSION"
		_scansession.MaxLength = 100
		Me.Fields.Add(_scansession)


		' NOTE: these next 3 fields are made visible by the UIAction button below
		'
		'_sponsorLookupId
		'
		_sponsorLookupId.Caption = "Sponsor Lookup ID"
		_sponsorLookupId.Name = "SPONSORLOOKUPID"
		_sponsorLookupId.MaxLength = 6
		_sponsorLookupId.Visible = False
		Me.Fields.Add(_sponsorLookupId)

		'
		'_appealId
		'
		_appealName.Caption = "Appeal Name"
		_appealName.Name = "APPEALNAME"
		_appealName.MaxLength = 10				' what is the MAX Length for the Appeal Number?
		_appealName.Visible = False
		Me.Fields.Add(_appealName)

		'
		'_childLookupId
		'
		_childLookupId.Caption = "Child Lookup ID"
		_childLookupId.Name = "CHILDLOOKUPID"
		_childLookupId.MaxLength = 7
		_childLookupId.Visible = False
		Me.Fields.Add(_childLookupId)

		' this button will display/hide the 3 fields above
		'
		'_enterappeal
		'
		_enterappeal.Name = "ENTERAPPEAL"
		_enterappeal.Caption = "Enter Appeal"
		Me.Actions.Add(_enterappeal)


		OnCreated()

    End Sub
    
	''' <summary>
	''' Bar code (9-character string)
	''' </summary>
	<System.ComponentModel.Description("Bar code (9-character string)")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [BARCODE]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
		Get
			Return _barcode
		End Get
	End Property

	''' <summary>
	''' Elements
	''' </summary>
	<System.ComponentModel.Description("Elements")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [BARCODEELEMENTS]() As Global.Blackbaud.AppFx.UIModeling.Core.CollectionField(Of SponsorRetentionAppeal2016LetterScannerAddDataFormBARCODEELEMENTSUIModel)
		Get
			Return _barcodeelements
		End Get
	End Property

	''' <summary>
	''' Save results
	''' </summary>
	<System.ComponentModel.Description("Save results")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [SUBMIT]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
		Get
			Return _submit
		End Get
	End Property

	''' <summary>
	''' Items enclosed
	''' </summary>
	<System.ComponentModel.Description("Items enclosed")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [ITEMSENCLOSEDCODEID]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
		Get
			Return _itemsenclosedcodeid
		End Get
	End Property

	''' <summary>
	''' Scan session
	''' </summary>
	<System.ComponentModel.Description("Scan session")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [SCANSESSION]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
		Get
			Return _scansession
		End Get
	End Property

	''' <summary>
	''' Sponsor Lookup ID
	''' </summary>
	<System.ComponentModel.Description("Sponsor Lookup ID")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [SPONSORLOOKUPID]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
		Get
			Return _sponsorLookupId
		End Get
	End Property

	''' <summary>
	''' Appeal Name
	''' </summary>
	<System.ComponentModel.Description("Appeal Name")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [APPEALNAME]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
		Get
			Return _appealName
		End Get
	End Property

	''' <summary>
	''' Child Lookup ID
	''' </summary>
	<System.ComponentModel.Description("Child Lookup ID")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [CHILDLOOKUPID]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
		Get
			Return _childLookupId
		End Get
	End Property

	''' <summary>
	''' ENTERAPPEAL
	''' </summary>
	<System.ComponentModel.Description("Enter Appeal")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [ENTERAPPEAL]() As Global.Blackbaud.AppFx.UIModeling.Core.GenericUIAction
		Get
			Return _enterappeal
		End Get
	End Property
    
End Class
