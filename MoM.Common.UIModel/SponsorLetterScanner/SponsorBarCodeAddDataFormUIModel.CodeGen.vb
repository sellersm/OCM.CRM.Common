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
''' Represents the UI model for the 'Bar code add data form' data form
''' </summary>
<Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModelMetadata(Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Add, "147fce52-6c63-46f9-894e-181df34c65a0", "bef3a82d-f674-4c1c-8699-ba8cc13139c4", "Sponsor Letter Bar Code Scanner")> _
Partial Public Class [SponsorBarCodeAddDataFormUIModel]
	Inherits Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModel

#Region "Extensibility methods"

	Partial Private Sub OnCreated()
	End Sub

#End Region

	Private WithEvents _barcode As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	Private WithEvents _barcodeelements As Global.Blackbaud.AppFx.UIModeling.Core.CollectionField(Of SponsorBarCodeAddDataFormBARCODEELEMENTSUIModel)
	Private WithEvents _submit As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
	Private WithEvents _itemsenclosedcodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
	Private WithEvents _scansession As Global.Blackbaud.AppFx.UIModeling.Core.StringField

	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public Sub New()
		MyBase.New()

		_barcode = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_barcodeelements = New Global.Blackbaud.AppFx.UIModeling.Core.CollectionField(Of SponsorBarCodeAddDataFormBARCODEELEMENTSUIModel)
		_submit = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
		_itemsenclosedcodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
		_scansession = New Global.Blackbaud.AppFx.UIModeling.Core.StringField

		MyBase.Mode = Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Add
		MyBase.DataFormTemplateId = New Guid("147fce52-6c63-46f9-894e-181df34c65a0")
		MyBase.DataFormInstanceId = New Guid("bef3a82d-f674-4c1c-8699-ba8cc13139c4")
		MyBase.RecordType = "Bar Code"
		MyBase.FixedDialog = False
		MyBase.UserInterfaceUrl = "browser/htmlforms/custom/SponsorBarCodeAddDataForm.html"

		'
		'_barcode
		'
		_barcode.Name = "BARCODE"
		_barcode.Caption = "Bar code"
		_barcode.MaxLength = 20
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
	Public ReadOnly Property [BARCODEELEMENTS]() As Global.Blackbaud.AppFx.UIModeling.Core.CollectionField(Of SponsorBarCodeAddDataFormBARCODEELEMENTSUIModel)
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

End Class
