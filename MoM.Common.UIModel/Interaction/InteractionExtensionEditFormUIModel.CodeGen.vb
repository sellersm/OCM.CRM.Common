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
''' Represents the UI model for the 'Interaction Extension Edit Form' data form
''' </summary>
<Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModelMetadata(Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Edit, "55904df7-4e42-4792-ae34-5dcf5aa3db47", "4843ed1c-5488-4fca-ad99-5d9e72ad2908", "Constituent Interaction")> _
Partial Public Class [InteractionExtensionEditFormUIModel]
	Inherits Global.Blackbaud.AppFx.UIModeling.Core.DataFormUIModel

#Region "Enums"

    ''' <summary>
    ''' Enumerated values for use with the EFTBROCHURECODE property
    ''' </summary>
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public Enum EFTBROCHURECODES As Integer
        [No] = 0
        [Yes] = 1
    End Enum

    ''' <summary>
    ''' Enumerated values for use with the RESENDCODE property
    ''' </summary>
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public Enum RESENDCODES As Integer
        [No] = 0
        [Yes] = 1
    End Enum

#End Region

#Region "Extensibility methods"

    Partial Private Sub OnCreated()
    End Sub

#End Region

    Private WithEvents _lettertypecodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _childcountletterversioncodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _fulfillmentstatuscodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _eftbrochurecode As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of EFTBROCHURECODES))
    Private WithEvents _resendcode As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of RESENDCODES))
    Private WithEvents _unavailablechildid As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
    Private WithEvents _transferchildid As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
    Private WithEvents _departedchildid As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
    Private WithEvents _departurereasoncodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _doublesponsoredchildid As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
    Private WithEvents _previouschildprojectid As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
    Private WithEvents _previousbirthdate As Global.Blackbaud.AppFx.UIModeling.Core.DateField
    Private WithEvents _previousname As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _fieldmemodatesent As Global.Blackbaud.AppFx.UIModeling.Core.DateField
    Private WithEvents _fieldmemosentcodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _holdreasoncodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _unusablecodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _children As Global.Blackbaud.AppFx.UIModeling.Core.CollectionField(Of InteractionExtensionEditFormCHILDRENUIModel)

	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public Sub New()
        MyBase.New()

        _lettertypecodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _childcountletterversioncodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _fulfillmentstatuscodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _eftbrochurecode = New Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of EFTBROCHURECODES))
        _resendcode = New Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of RESENDCODES))
        _unavailablechildid = New Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        _transferchildid = New Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        _departedchildid = New Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        _departurereasoncodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _doublesponsoredchildid = New Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        _previouschildprojectid = New Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        _previousbirthdate = New Global.Blackbaud.AppFx.UIModeling.Core.DateField
        _previousname = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
        _fieldmemodatesent = New Global.Blackbaud.AppFx.UIModeling.Core.DateField
        _fieldmemosentcodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _holdreasoncodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _unusablecodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        _children = New Global.Blackbaud.AppFx.UIModeling.Core.CollectionField(Of InteractionExtensionEditFormCHILDRENUIModel)

        MyBase.Mode = Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Edit
        MyBase.DataFormTemplateId = New Guid("55904df7-4e42-4792-ae34-5dcf5aa3db47")
        MyBase.DataFormInstanceId = New Guid("4843ed1c-5488-4fca-ad99-5d9e72ad2908")
        MyBase.RecordType = "Constituent Interaction"
        MyBase.FixedDialog = True
        MyBase.ExtensionTabCaption = "Additional Info"
        MyBase.UserInterfaceUrl = "browser/htmlforms/Interactions/InteractionExtension.EditForm.html"

        '
        '_lettertypecodeid
        '
        _lettertypecodeid.Name = "LETTERTYPECODEID"
        _lettertypecodeid.Caption = "Letter type"
        _lettertypecodeid.CodeTableName = "USR_INTERACTIONEXTENSIONLETTERTYPECODE"
        Me.Fields.Add(_lettertypecodeid)
        '
        '_childcountletterversioncodeid
        '
        _childcountletterversioncodeid.Name = "CHILDCOUNTLETTERVERSIONCODEID"
        _childcountletterversioncodeid.Caption = "Child count letter version"
        _childcountletterversioncodeid.CodeTableName = "USR_INTERACTIONEXTENSIONLETTERCHILDVERSIONCODE"
        Me.Fields.Add(_childcountletterversioncodeid)
        '
        '_fulfillmentstatuscodeid
        '
        _fulfillmentstatuscodeid.Name = "FULFILLMENTSTATUSCODEID"
        _fulfillmentstatuscodeid.Caption = "Fulfillment status"
        _fulfillmentstatuscodeid.CodeTableName = "USR_INTERACTIONEXTENSIONFULFILLMENTSTATUSCODE"
        Me.Fields.Add(_fulfillmentstatuscodeid)
        '
        '_eftbrochurecode
        '
        _eftbrochurecode.Name = "EFTBROCHURECODE"
        _eftbrochurecode.Caption = "EFT brochure"
        _eftbrochurecode.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of Nullable(Of EFTBROCHURECODES)) With {.Value = EFTBROCHURECODES.[No], .Translation = "No"})
        _eftbrochurecode.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of Nullable(Of EFTBROCHURECODES)) With {.Value = EFTBROCHURECODES.[Yes], .Translation = "Yes"})
        Me.Fields.Add(_eftbrochurecode)
        '
        '_resendcode
        '
        _resendcode.Name = "RESENDCODE"
        _resendcode.Caption = "Resend?"
        _resendcode.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of Nullable(Of RESENDCODES)) With {.Value = RESENDCODES.[No], .Translation = "No"})
        _resendcode.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of Nullable(Of RESENDCODES)) With {.Value = RESENDCODES.[Yes], .Translation = "Yes"})
        Me.Fields.Add(_resendcode)
        '
        '_unavailablechildid
        '
        _unavailablechildid.Name = "UNAVAILABLECHILDID"
        _unavailablechildid.Caption = "Unavailable child"
        Me.Fields.Add(_unavailablechildid)
        '
        '_transferchildid
        '
        _transferchildid.Name = "TRANSFERCHILDID"
        _transferchildid.Caption = "Transfer child"
        Me.Fields.Add(_transferchildid)
        '
        '_departedchildid
        '
        _departedchildid.Name = "DEPARTEDCHILDID"
        _departedchildid.Caption = "Departed child"
        Me.Fields.Add(_departedchildid)
        '
        '_departurereasoncodeid
        '
        _departurereasoncodeid.Name = "DEPARTUREREASONCODEID"
        _departurereasoncodeid.Caption = "Departure reason"
        _departurereasoncodeid.CodeTableName = "USR_INTERACTIONEXTENSIONDEPARTUREREASONCODE"
        Me.Fields.Add(_departurereasoncodeid)
        '
        '_doublesponsoredchildid
        '
        _doublesponsoredchildid.Name = "DOUBLESPONSOREDCHILDID"
        _doublesponsoredchildid.Caption = "Double sponsored child"
        Me.Fields.Add(_doublesponsoredchildid)
        '
        '_previouschildprojectid
        '
        _previouschildprojectid.Name = "PREVIOUSCHILDPROJECTID"
        _previouschildprojectid.Caption = "Previous child project"
        Me.Fields.Add(_previouschildprojectid)
        '
        '_previousbirthdate
        '
        _previousbirthdate.Name = "PREVIOUSBIRTHDATE"
        _previousbirthdate.Caption = "Previous birthdate"
        Me.Fields.Add(_previousbirthdate)
        '
        '_previousname
        '
        _previousname.Name = "PREVIOUSNAME"
        _previousname.Caption = "Previous name"
        _previousname.MaxLength = 150
        Me.Fields.Add(_previousname)
        '
        '_fieldmemodatesent
        '
        _fieldmemodatesent.Name = "FIELDMEMODATESENT"
        _fieldmemodatesent.Caption = "Field memo date sent"
        Me.Fields.Add(_fieldmemodatesent)
        '
        '_fieldmemosentcodeid
        '
        _fieldmemosentcodeid.Name = "FIELDMEMOSENTCODEID"
        _fieldmemosentcodeid.Caption = "Field memo sent"
        _fieldmemosentcodeid.CodeTableName = "USR_INTERACTIONEXTENSIONFIELDMEMOSENTCODE"
        Me.Fields.Add(_fieldmemosentcodeid)
        '
        '_holdreasoncodeid
        '
        _holdreasoncodeid.Name = "HOLDREASONCODEID"
        _holdreasoncodeid.Caption = "Hold reason"
        _holdreasoncodeid.CodeTableName = "USR_INTERACTIONEXTENSIONHOLDREASONCODE"
        Me.Fields.Add(_holdreasoncodeid)
        '
        '_unusablecodeid
        '
        _unusablecodeid.Name = "UNUSABLECODEID"
        _unusablecodeid.Caption = "Unusable item"
        _unusablecodeid.CodeTableName = "USR_INTERACTIONEXTENSIONUNUSABLEITEMCODE"
        Me.Fields.Add(_unusablecodeid)
        '
        '_children
        '
        _children.Name = "CHILDREN"
        _children.Caption = "Children"
        Me.Fields.Add(_children)

		OnCreated()

    End Sub
    
    ''' <summary>
    ''' Letter type
    ''' </summary>
    <System.ComponentModel.Description("Letter type")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [LETTERTYPECODEID]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _lettertypecodeid
        End Get
    End Property
    
    ''' <summary>
    ''' Child count letter version
    ''' </summary>
    <System.ComponentModel.Description("Child count letter version")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [CHILDCOUNTLETTERVERSIONCODEID]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _childcountletterversioncodeid
        End Get
    End Property
    
    ''' <summary>
    ''' Fulfillment status
    ''' </summary>
    <System.ComponentModel.Description("Fulfillment status")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [FULFILLMENTSTATUSCODEID]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _fulfillmentstatuscodeid
        End Get
    End Property
    
    ''' <summary>
    ''' EFT brochure
    ''' </summary>
    <System.ComponentModel.Description("EFT brochure")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [EFTBROCHURECODE]() As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of EFTBROCHURECODES))
        Get
            Return _eftbrochurecode
        End Get
    End Property
    
    ''' <summary>
    ''' Resend?
    ''' </summary>
    <System.ComponentModel.Description("Resend?")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [RESENDCODE]() As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of RESENDCODES))
        Get
            Return _resendcode
        End Get
    End Property
    
    ''' <summary>
    ''' Unavailable child
    ''' </summary>
    <System.ComponentModel.Description("Unavailable child")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [UNAVAILABLECHILDID]() As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        Get
            Return _unavailablechildid
        End Get
    End Property
    
    ''' <summary>
    ''' Transfer child
    ''' </summary>
    <System.ComponentModel.Description("Transfer child")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [TRANSFERCHILDID]() As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        Get
            Return _transferchildid
        End Get
    End Property
    
    ''' <summary>
    ''' Departed child
    ''' </summary>
    <System.ComponentModel.Description("Departed child")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [DEPARTEDCHILDID]() As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        Get
            Return _departedchildid
        End Get
    End Property
    
    ''' <summary>
    ''' Departure reason
    ''' </summary>
    <System.ComponentModel.Description("Departure reason")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [DEPARTUREREASONCODEID]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _departurereasoncodeid
        End Get
    End Property
    
    ''' <summary>
    ''' Double sponsored child
    ''' </summary>
    <System.ComponentModel.Description("Double sponsored child")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [DOUBLESPONSOREDCHILDID]() As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        Get
            Return _doublesponsoredchildid
        End Get
    End Property
    
    ''' <summary>
    ''' Previous child project
    ''' </summary>
    <System.ComponentModel.Description("Previous child project")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [PREVIOUSCHILDPROJECTID]() As Global.Blackbaud.AppFx.UIModeling.Core.GuidField
        Get
            Return _previouschildprojectid
        End Get
    End Property
    
    ''' <summary>
    ''' Previous birthdate
    ''' </summary>
    <System.ComponentModel.Description("Previous birthdate")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [PREVIOUSBIRTHDATE]() As Global.Blackbaud.AppFx.UIModeling.Core.DateField
        Get
            Return _previousbirthdate
        End Get
    End Property
    
    ''' <summary>
    ''' Previous name
    ''' </summary>
    <System.ComponentModel.Description("Previous name")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [PREVIOUSNAME]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _previousname
        End Get
    End Property
    
    ''' <summary>
    ''' Field memo date sent
    ''' </summary>
    <System.ComponentModel.Description("Field memo date sent")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [FIELDMEMODATESENT]() As Global.Blackbaud.AppFx.UIModeling.Core.DateField
        Get
            Return _fieldmemodatesent
        End Get
    End Property
    
    ''' <summary>
    ''' Field memo sent
    ''' </summary>
    <System.ComponentModel.Description("Field memo sent")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [FIELDMEMOSENTCODEID]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _fieldmemosentcodeid
        End Get
    End Property
    
    ''' <summary>
    ''' Hold reason
    ''' </summary>
    <System.ComponentModel.Description("Hold reason")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [HOLDREASONCODEID]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _holdreasoncodeid
        End Get
    End Property
    
    ''' <summary>
    ''' Unusable item
    ''' </summary>
    <System.ComponentModel.Description("Unusable item")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [UNUSABLECODEID]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _unusablecodeid
        End Get
    End Property
    
    ''' <summary>
    ''' Children
    ''' </summary>
    <System.ComponentModel.Description("Children")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [CHILDREN]() As Global.Blackbaud.AppFx.UIModeling.Core.CollectionField(Of InteractionExtensionEditFormCHILDRENUIModel)
        Get
            Return _children
        End Get
    End Property
    
End Class