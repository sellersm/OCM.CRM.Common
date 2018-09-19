﻿Option Strict On
Option Explicit On
Option Infer On

'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by BBUIModelLibrary
'     Version:  4.0.170.0
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
''' <summary>
''' Represents the UI model for the 'Child Reservations Delete Global Change' data form
''' </summary>

Partial Public Class [ChildReservationsDeleteGlobalChangeUIModel]
	Inherits Global.Blackbaud.AppFx.UIModeling.Core.CustomUIModel

#Region "Enums"

    ''' <summary>
    ''' Enumerated values for use with the OPERATION property
    ''' </summary>
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.170.0")> _
    Public Enum OPERATIONS As Integer
        [Delete] = 3
    End Enum

#End Region

#Region "Extensibility methods"

    Partial Private Sub OnCreated()
    End Sub

#End Region

    Private WithEvents _idsetregisterid As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of System.Guid)
    Private WithEvents _recordtypeid As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
    Private WithEvents _operation As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of OPERATIONS))

	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.170.0")> _
    Public Sub New()
        MyBase.New()

        _idsetregisterid = New Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of System.Guid)
        _recordtypeid = New Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        _operation = New Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of OPERATIONS))

        MyBase.UserInterfaceUrl = "browser/htmlforms/custom/ChildReservationsDeleteGlobalChange.html"

        '
        '_idsetregisterid
        '
        _idsetregisterid.Name = "IDSETREGISTERID"
        _idsetregisterid.Caption = "Selection"
        _idsetregisterid.Required = True
        _idsetregisterid.SearchListId = New System.Guid("98d0070e-c4a7-495b-a438-2ac12da79068")
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
        _operation.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of Nullable(Of OPERATIONS)) With {.Value = OPERATIONS.[Delete], .Translation = "Delete"})
        Me.Fields.Add(_operation)

		OnCreated()

    End Sub
    
    ''' <summary>
    ''' Selection
    ''' </summary>
    <System.ComponentModel.Description("Selection")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.170.0")> _
    Public ReadOnly Property [IDSETREGISTERID]() As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of System.Guid)
        Get
            Return _idsetregisterid
        End Get
    End Property
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.170.0")> _
    Public ReadOnly Property [RECORDTYPEID]() As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        Get
            Return _recordtypeid
        End Get
    End Property
    
    ''' <summary>
    ''' Operation
    ''' </summary>
    <System.ComponentModel.Description("Operation")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.170.0")> _
    Public ReadOnly Property [OPERATION]() As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of OPERATIONS))
        Get
            Return _operation
        End Get
    End Property
    
End Class
