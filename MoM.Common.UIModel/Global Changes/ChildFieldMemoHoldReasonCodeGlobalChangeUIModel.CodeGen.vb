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
''' Represents the UI model for the 'Child Field Memo Hold Reason Code Global Change' data form
''' </summary>

Partial Public Class [ChildFieldMemoHoldReasonCodeGlobalChangeUIModel]
	Inherits Global.Blackbaud.AppFx.UIModeling.Core.CustomUIModel

#Region "Extensibility methods"

    Partial Private Sub OnCreated()
    End Sub

#End Region

    Private WithEvents _idsetregisterid As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
    Private WithEvents _recordtypeid As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
    Private WithEvents _operation As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of String)
    Private WithEvents _addholdreasoncodevalue As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _overwriteexistingvalue As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _replaceholdreasoncodevalue As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _replaceholdreasoncodewithvalue As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _deleteholdreasoncodevalue As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _deleteallholdreasoncodevalues As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField

	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public Sub New()
        MyBase.New()

        _idsetregisterid = New Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
        _recordtypeid = New Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        _operation = New Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of String)
        _addholdreasoncodevalue = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _overwriteexistingvalue = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _replaceholdreasoncodevalue = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _replaceholdreasoncodewithvalue = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _deleteholdreasoncodevalue = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _deleteallholdreasoncodevalues = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField

		MyBase.UserInterfaceUrl = "browser/htmlforms/custom/ChildFieldMemoHoldReasonCodeGlobalChange.html"

        '
        '_idsetregisterid
        '
        _idsetregisterid.Name = "IDSETREGISTERID"
        _idsetregisterid.Caption = "Selection"
        _idsetregisterid.Required = True
        _idsetregisterid.SearchListID = New Guid("98d0070e-c4a7-495b-a438-2ac12da79068")
        _idsetregisterid.EnableQuickFind = True
        _idsetregisterid.SearchFieldOverrides.Add(New Global.Blackbaud.AppFx.UIModeling.Core.FieldOverride() With {.FieldId = "RECORDTYPEID", .Caption = "Record type", .ReadOnly = True, .DefaultValueText = "Fields!RECORDTYPEID"})
        _idsetregisterid.SystemSearchType = Global.Blackbaud.AppFx.UIModeling.Core.SystemSearchType.Selection
        Me.Fields.Add(_idsetregisterid)
        '
        '_recordtypeid
        '
        _recordtypeid.Name = "RECORDTYPEID"
        _recordtypeid.Caption = "RECORDTYPEID"
        _recordtypeid.Visible = False
        _recordtypeid.DBReadOnly = True
        Me.Fields.Add(_recordtypeid)
        '
        '_operation
        '
        _operation.Name = "OPERATION"
        _operation.Caption = "Operation"
		_operation.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of String) With {.Value = "1", .Translation = "Add"})
		_operation.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of String) With {.Value = "2", .Translation = "Replace"})
		_operation.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of String) With {.Value = "3", .Translation = "Delete"})
		Me.Fields.Add(_operation)
        '
        '_addholdreasoncodevalue
        '
        _addholdreasoncodevalue.Name = "ADDHOLDREASONCODEVALUE"
        _addholdreasoncodevalue.Caption = "Hold Reason code value to add"
        _addholdreasoncodevalue.CodeTableName = "USR_INTERACTIONEXTENSIONHOLDREASONCODE"
        Me.Fields.Add(_addholdreasoncodevalue)
        '
        '_overwriteexistingvalue
        '
        _overwriteexistingvalue.Name = "OVERWRITEEXISTINGVALUE"
        _overwriteexistingvalue.Caption = "Overwrite existing value"
        Me.Fields.Add(_overwriteexistingvalue)
        '
        '_replaceholdreasoncodevalue
        '
        _replaceholdreasoncodevalue.Name = "REPLACEHOLDREASONCODEVALUE"
        _replaceholdreasoncodevalue.Caption = "Replace Hold Reason code value of"
        _replaceholdreasoncodevalue.CodeTableName = "USR_INTERACTIONEXTENSIONHOLDREASONCODE"
        Me.Fields.Add(_replaceholdreasoncodevalue)
        '
        '_replaceholdreasoncodewithvalue
        '
        _replaceholdreasoncodewithvalue.Name = "REPLACEHOLDREASONCODEWITHVALUE"
        _replaceholdreasoncodewithvalue.Caption = "With"
        _replaceholdreasoncodewithvalue.CodeTableName = "USR_INTERACTIONEXTENSIONHOLDREASONCODE"
        Me.Fields.Add(_replaceholdreasoncodewithvalue)
        '
        '_deleteholdreasoncodevalue
        '
        _deleteholdreasoncodevalue.Name = "DELETEHOLDREASONCODEVALUE"
        _deleteholdreasoncodevalue.Caption = "Delete Hold Reason code value of"
        _deleteholdreasoncodevalue.CodeTableName = "USR_INTERACTIONEXTENSIONHOLDREASONCODE"
        Me.Fields.Add(_deleteholdreasoncodevalue)
        '
        '_deleteallholdreasoncodevalues
        '
        _deleteallholdreasoncodevalues.Name = "DELETEALLHOLDREASONCODEVALUES"
        _deleteallholdreasoncodevalues.Caption = "Delete all Hold Reason code values"
        Me.Fields.Add(_deleteallholdreasoncodevalues)

		OnCreated()

    End Sub
    
    ''' <summary>
    ''' Selection
    ''' </summary>
    <System.ComponentModel.Description("Selection")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [IDSETREGISTERID]() As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
        Get
            Return _idsetregisterid
        End Get
    End Property
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [RECORDTYPEID]() As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        Get
            Return _recordtypeid
        End Get
    End Property
    
    ''' <summary>
    ''' Operation
    ''' </summary>
    <System.ComponentModel.Description("Operation")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [OPERATION]() As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of String)
        Get
            Return _operation
        End Get
    End Property
    
    ''' <summary>
    ''' Hold Reason code value to add
    ''' </summary>
    <System.ComponentModel.Description("Hold Reason code value to add")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [ADDHOLDREASONCODEVALUE]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _addholdreasoncodevalue
        End Get
    End Property
    
    ''' <summary>
    ''' Overwrite existing value
    ''' </summary>
    <System.ComponentModel.Description("Overwrite existing value")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [OVERWRITEEXISTINGVALUE]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _overwriteexistingvalue
        End Get
    End Property
    
    ''' <summary>
    ''' Replace Hold Reason code value of
    ''' </summary>
    <System.ComponentModel.Description("Replace Hold Reason code value of")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [REPLACEHOLDREASONCODEVALUE]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _replaceholdreasoncodevalue
        End Get
    End Property
    
    ''' <summary>
    ''' With
    ''' </summary>
    <System.ComponentModel.Description("With")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [REPLACEHOLDREASONCODEWITHVALUE]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _replaceholdreasoncodewithvalue
        End Get
    End Property
    
    ''' <summary>
    ''' Delete Hold Reason code value of
    ''' </summary>
    <System.ComponentModel.Description("Delete Hold Reason code value of")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [DELETEHOLDREASONCODEVALUE]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _deleteholdreasoncodevalue
        End Get
    End Property
    
    ''' <summary>
    ''' Delete all Hold Reason code values
    ''' </summary>
    <System.ComponentModel.Description("Delete all Hold Reason code values")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [DELETEALLHOLDREASONCODEVALUES]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _deleteallholdreasoncodevalues
        End Get
    End Property
    
End Class
