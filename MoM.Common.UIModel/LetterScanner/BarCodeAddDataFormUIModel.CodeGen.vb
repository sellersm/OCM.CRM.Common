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
<Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModelMetadata(Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Add, "8e7c2281-2538-4d91-a20d-223b0e1cbf93", "7262ae36-fccf-4e16-92d8-6c87bfbf5568", "Bar Code")> _
Partial Public Class [BarCodeAddDataFormUIModel]
	Inherits Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModel

#Region "Extensibility methods"

    Partial Private Sub OnCreated()
    End Sub

#End Region

    Private WithEvents _barcode As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _barcodeelements As Global.Blackbaud.AppFx.UIModeling.Core.CollectionField(Of BarCodeAddDataFormBARCODEELEMENTSUIModel)
    Private WithEvents _submit As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField

	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public Sub New()
        MyBase.New()

        _barcode = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _barcodeelements = New Global.Blackbaud.AppFx.UIModeling.Core.CollectionField(Of BarCodeAddDataFormBARCODEELEMENTSUIModel)
        _submit = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField

        MyBase.Mode = Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Add
        MyBase.DataFormTemplateId = New Guid("8e7c2281-2538-4d91-a20d-223b0e1cbf93")
        MyBase.DataFormInstanceId = New Guid("7262ae36-fccf-4e16-92d8-6c87bfbf5568")
        MyBase.RecordType = "Bar Code"
		MyBase.FixedDialog = False
		MyBase.UserInterfaceUrl = "browser/htmlforms/custom/BarCodeAddDataForm.html"

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
    Public ReadOnly Property [BARCODEELEMENTS]() As Global.Blackbaud.AppFx.UIModeling.Core.CollectionField(Of BarCodeAddDataFormBARCODEELEMENTSUIModel)
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
    
End Class
