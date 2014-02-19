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
''' Represents the UI model for the 'Child Field Memo Sent Code Global Change' data form
''' </summary>

Partial Public Class [ChildFieldMemoSentCodeGlobalChangeUIModel]
	Inherits Global.Blackbaud.AppFx.UIModeling.Core.CustomUIModel

#Region "Extensibility methods"

    Partial Private Sub OnCreated()
    End Sub

#End Region

    Private WithEvents _idsetregisterid As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
    Private WithEvents _recordtypeid As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
    Private WithEvents _operation As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of String)
    Private WithEvents _addsentcodevalue As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _overwriteexistingvalue As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
    Private WithEvents _replacesentcodevalue As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _replacesentcodewithvalue As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _deletesentcodevalue As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _deleteallsentcodevalues As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField

	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public Sub New()
        MyBase.New()

        _idsetregisterid = New Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
        _recordtypeid = New Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        _operation = New Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of String)
        _addsentcodevalue = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _overwriteexistingvalue = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        _replacesentcodevalue = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _replacesentcodewithvalue = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _deletesentcodevalue = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _deleteallsentcodevalues = New Global.Blackbaud.AppFx.UIModeling.Core.BooleanField

		MyBase.UserInterfaceUrl = "browser/htmlforms/custom/ChildFieldMemoSentCodeGlobalChange.html"

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
        '_addsentcodevalue
        '
        _addsentcodevalue.Name = "ADDSENTCODEVALUE"
        _addsentcodevalue.Caption = "Sent code value to add"
        _addsentcodevalue.CodeTableName = "USR_INTERACTIONEXTENSIONFIELDMEMOSENTCODE"
        Me.Fields.Add(_addsentcodevalue)
        '
        '_overwriteexistingvalue
        '
        _overwriteexistingvalue.Name = "OVERWRITEEXISTINGVALUE"
        _overwriteexistingvalue.Caption = "Overwrite existing value"
        Me.Fields.Add(_overwriteexistingvalue)
        '
        '_replacesentcodevalue
        '
        _replacesentcodevalue.Name = "REPLACESENTCODEVALUE"
        _replacesentcodevalue.Caption = "Replace sent code value of"
        _replacesentcodevalue.CodeTableName = "USR_INTERACTIONEXTENSIONFIELDMEMOSENTCODE"
        Me.Fields.Add(_replacesentcodevalue)
        '
        '_replacesentcodewithvalue
        '
        _replacesentcodewithvalue.Name = "REPLACESENTCODEWITHVALUE"
        _replacesentcodewithvalue.Caption = "With"
        _replacesentcodewithvalue.CodeTableName = "USR_INTERACTIONEXTENSIONFIELDMEMOSENTCODE"
        Me.Fields.Add(_replacesentcodewithvalue)
        '
        '_deletesentcodevalue
        '
        _deletesentcodevalue.Name = "DELETESENTCODEVALUE"
        _deletesentcodevalue.Caption = "Delete sent code value of"
        _deletesentcodevalue.CodeTableName = "USR_INTERACTIONEXTENSIONFIELDMEMOSENTCODE"
        Me.Fields.Add(_deletesentcodevalue)
        '
        '_deleteallsentcodevalues
        '
        _deleteallsentcodevalues.Name = "DELETEALLSENTCODEVALUES"
        _deleteallsentcodevalues.Caption = "Delete all sent code values"
        Me.Fields.Add(_deleteallsentcodevalues)

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
    ''' Sent code value to add
    ''' </summary>
    <System.ComponentModel.Description("Sent code value to add")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [ADDSENTCODEVALUE]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _addsentcodevalue
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
    ''' Replace sent code value of
    ''' </summary>
    <System.ComponentModel.Description("Replace sent code value of")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [REPLACESENTCODEVALUE]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _replacesentcodevalue
        End Get
    End Property
    
    ''' <summary>
    ''' With
    ''' </summary>
    <System.ComponentModel.Description("With")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [REPLACESENTCODEWITHVALUE]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _replacesentcodewithvalue
        End Get
    End Property
    
    ''' <summary>
    ''' Delete sent code value of
    ''' </summary>
    <System.ComponentModel.Description("Delete sent code value of")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [DELETESENTCODEVALUE]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _deletesentcodevalue
        End Get
    End Property
    
    ''' <summary>
    ''' Delete all sent code values
    ''' </summary>
    <System.ComponentModel.Description("Delete all sent code values")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [DELETEALLSENTCODEVALUES]() As Global.Blackbaud.AppFx.UIModeling.Core.BooleanField
        Get
            Return _deleteallsentcodevalues
        End Get
    End Property
    
End Class
