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

    ''' <summary>
    ''' Enumerated values for use with the COMPLETEDAFTERCANCELLATIONCODE property
    ''' </summary>
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public Enum COMPLETEDAFTERCANCELLATIONCODES As Integer
        [No] = 0
        [Yes] = 1
    End Enum

    ''' <summary>
    ''' Enumerated values for use with the PRINTBLACKOUTLABEL property
    ''' </summary>
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public Enum PRINTBLACKOUTLABELS As Integer
        [No] = 0
        [Yes] = 1
    End Enum

#End Region

#Region "Extensibility methods"

    Partial Private Sub OnCreated()
    End Sub

#End Region

    Private WithEvents _childcountletterversioncodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _lettertypecodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _fulfillmentstatuscodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _eftbrochurecode As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of EFTBROCHURECODES))
    Private WithEvents _resendcode As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of RESENDCODES))
    Private WithEvents _unavailablechildid As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
    Private WithEvents _transferchildid As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
    Private WithEvents _departedchildid As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
    Private WithEvents _departurereasoncodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _departurereasonotherdescription As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _doublesponsoredchildid As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
    Private WithEvents _previouschildprojectid As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
    Private WithEvents _transferchildprojectid As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
    Private WithEvents _previousbirthdate As Global.Blackbaud.AppFx.UIModeling.Core.DateField
    Private WithEvents _previousname As Global.Blackbaud.AppFx.UIModeling.Core.StringField
    Private WithEvents _sponsoredprojectid As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
    Private WithEvents _fieldmemodatesent As Global.Blackbaud.AppFx.UIModeling.Core.DateField
    Private WithEvents _fieldmemosentcodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _holdreasoncodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _unusablecodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
	Private WithEvents _sponsorid As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
	Private WithEvents _partnerid As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
    Private WithEvents _itemsenclosedcodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
    Private WithEvents _originallettersubcategoryid As Global.Blackbaud.AppFx.UIModeling.Core.SimpleDataListField(Of Guid)
	Private WithEvents _originallettersequenceid As Global.Blackbaud.AppFx.UIModeling.Core.IntegerField
	Private WithEvents _completedaftercancellationcode As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of COMPLETEDAFTERCANCELLATIONCODES))
	Private WithEvents _printblackoutlabel As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of PRINTBLACKOUTLABELS))
	Private WithEvents _reservationreqrepcode As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	Private WithEvents _reservationreqnumberofprofiles As Global.Blackbaud.AppFx.UIModeling.Core.SmallIntField
	Private WithEvents _reservationreqdisplayracks As Global.Blackbaud.AppFx.UIModeling.Core.SmallIntField
	Private WithEvents _reservationreqbrochures As Global.Blackbaud.AppFx.UIModeling.Core.SmallIntField
	Private WithEvents _reservationreqexpecteddatetypecodeid As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
	Private WithEvents _addressblock As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	Private WithEvents _city As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	Private WithEvents _stateid As Global.Blackbaud.AppFx.UIModeling.Core.SimpleDataListField(Of Guid)
	Private WithEvents _postcode As Global.Blackbaud.AppFx.UIModeling.Core.StringField
	Private WithEvents _children As Global.Blackbaud.AppFx.UIModeling.Core.CollectionField(Of InteractionExtensionEditFormCHILDRENUIModel)

	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public Sub New()
		MyBase.New()

		_childcountletterversioncodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
		_lettertypecodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
		_fulfillmentstatuscodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
		_eftbrochurecode = New Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of EFTBROCHURECODES))
		_resendcode = New Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of RESENDCODES))
		_unavailablechildid = New Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		_transferchildid = New Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		_departedchildid = New Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		_departurereasoncodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
		_departurereasonotherdescription = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_doublesponsoredchildid = New Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		_previouschildprojectid = New Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		_transferchildprojectid = New Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		_previousbirthdate = New Global.Blackbaud.AppFx.UIModeling.Core.DateField
		_previousname = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_sponsoredprojectid = New Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		_fieldmemodatesent = New Global.Blackbaud.AppFx.UIModeling.Core.DateField
		_fieldmemosentcodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
		_holdreasoncodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
		_unusablecodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
		_sponsorid = New Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		_partnerid = New Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		_itemsenclosedcodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
		_originallettersubcategoryid = New Global.Blackbaud.AppFx.UIModeling.Core.SimpleDataListField(Of Guid)
		_originallettersequenceid = New Global.Blackbaud.AppFx.UIModeling.Core.IntegerField
		_completedaftercancellationcode = New Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of COMPLETEDAFTERCANCELLATIONCODES))
		_printblackoutlabel = New Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of PRINTBLACKOUTLABELS))
		_reservationreqrepcode = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_reservationreqnumberofprofiles = New Global.Blackbaud.AppFx.UIModeling.Core.SmallIntField
		_reservationreqdisplayracks = New Global.Blackbaud.AppFx.UIModeling.Core.SmallIntField
		_reservationreqbrochures = New Global.Blackbaud.AppFx.UIModeling.Core.SmallIntField
		_reservationreqexpecteddatetypecodeid = New Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
		_addressblock = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_city = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_stateid = New Global.Blackbaud.AppFx.UIModeling.Core.SimpleDataListField(Of Guid)
		_postcode = New Global.Blackbaud.AppFx.UIModeling.Core.StringField
		_children = New Global.Blackbaud.AppFx.UIModeling.Core.CollectionField(Of InteractionExtensionEditFormCHILDRENUIModel)

		MyBase.Mode = Global.Blackbaud.AppFx.UIModeling.Core.DataFormMode.Edit
		MyBase.DataFormTemplateId = New Guid("55904df7-4e42-4792-ae34-5dcf5aa3db47")
		MyBase.DataFormInstanceId = New Guid("4843ed1c-5488-4fca-ad99-5d9e72ad2908")
		MyBase.RecordType = "Constituent Interaction"
		MyBase.FixedDialog = True
		MyBase.ExtensionTabCaption = "Additional Info"
		MyBase.UserInterfaceUrl = "browser/htmlforms/custom/InteractionExtension.EditForm.html"

		'
		'_childcountletterversioncodeid
		'
		_childcountletterversioncodeid.Name = "CHILDCOUNTLETTERVERSIONCODEID"
		_childcountletterversioncodeid.Caption = "Child count letter version"
		_childcountletterversioncodeid.CodeTableName = "USR_INTERACTIONEXTENSIONLETTERCHILDVERSIONCODE"
		Me.Fields.Add(_childcountletterversioncodeid)
		'
		'_lettertypecodeid
		'
		_lettertypecodeid.Name = "LETTERTYPECODEID"
		_lettertypecodeid.Caption = "Letter type"
		_lettertypecodeid.CodeTableName = "USR_INTERACTIONEXTENSIONLETTERTYPECODE"
		Me.Fields.Add(_lettertypecodeid)
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
		_unavailablechildid.SearchListID = New Guid("ab076868-114a-4696-afe9-8d590677708c")
		Me.Fields.Add(_unavailablechildid)
		'
		'_transferchildid
		'
		_transferchildid.Name = "TRANSFERCHILDID"
		_transferchildid.Caption = "Transfer child"
		_transferchildid.SearchListID = New Guid("ab076868-114a-4696-afe9-8d590677708c")
		Me.Fields.Add(_transferchildid)
		'
		'_departedchildid
		'
		_departedchildid.Name = "DEPARTEDCHILDID"
		_departedchildid.Caption = "Departed child"
		_departedchildid.SearchListID = New Guid("ab076868-114a-4696-afe9-8d590677708c")
		Me.Fields.Add(_departedchildid)
		'
		'_departurereasoncodeid
		'
		_departurereasoncodeid.Name = "DEPARTUREREASONCODEID"
		_departurereasoncodeid.Caption = "Departure reason"
		_departurereasoncodeid.CodeTableName = "USR_INTERACTIONEXTENSIONDEPARTUREREASONCODE"
		Me.Fields.Add(_departurereasoncodeid)
		'
		'_departurereasonotherdescription
		'
		_departurereasonotherdescription.Name = "DEPARTUREREASONOTHERDESCRIPTION"
		_departurereasonotherdescription.Caption = "Other reason"
		_departurereasonotherdescription.MaxLength = 250
		Me.Fields.Add(_departurereasonotherdescription)
		'
		'_doublesponsoredchildid
		'
		_doublesponsoredchildid.Name = "DOUBLESPONSOREDCHILDID"
		_doublesponsoredchildid.Caption = "Double sponsored child"
		_doublesponsoredchildid.SearchListID = New Guid("ab076868-114a-4696-afe9-8d590677708c")
		Me.Fields.Add(_doublesponsoredchildid)
		'
		'_previouschildprojectid
		'
		_previouschildprojectid.Name = "PREVIOUSCHILDPROJECTID"
		_previouschildprojectid.Caption = "Previous child project"
		_previouschildprojectid.SearchListID = New Guid("a62848b0-d378-4c5f-886d-aa791a59fe55")
		Me.Fields.Add(_previouschildprojectid)
		'
		'_transferchildprojectid
		'
		_transferchildprojectid.Name = "TRANSFERCHILDPROJECTID"
		_transferchildprojectid.Caption = "Transfer child project"
		_transferchildprojectid.SearchListID = New Guid("a62848b0-d378-4c5f-886d-aa791a59fe55")
		Me.Fields.Add(_transferchildprojectid)
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
		'_sponsoredprojectid
		'
		_sponsoredprojectid.Name = "SPONSOREDPROJECTID"
		_sponsoredprojectid.Caption = "Sponsored project"
		_sponsoredprojectid.SearchListID = New Guid("b095dc74-4c09-40c9-9c9d-e8ff55b584ce")
		Me.Fields.Add(_sponsoredprojectid)
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
		'_sponsorid
		'
		_sponsorid.Name = "SPONSORID"
		_sponsorid.Caption = "Sponsor"
		_sponsorid.SearchListID = New Guid("23c5c603-d7d8-4106-aecc-65392b563887")
		Me.Fields.Add(_sponsorid)
		'
		'_partnerid
		'
		_partnerid.Name = "PARTNERID"
		_partnerid.Caption = "Partner"
		'_partnerid.DBReadOnly = True
		_partnerid.SearchListId = New Guid("23c5c603-d7d8-4106-aecc-65392b563887")
		Me.Fields.Add(_partnerid)

		'
		'_itemsenclosedcodeid
		'
		_itemsenclosedcodeid.Name = "ITEMSENCLOSEDCODEID"
		_itemsenclosedcodeid.Caption = "Items enclosed"
		_itemsenclosedcodeid.CodeTableName = "USR_ITEMSENCLOSEDCODE"
		Me.Fields.Add(_itemsenclosedcodeid)
		'
		'_originallettersubcategoryid
		'
		_originallettersubcategoryid.Name = "ORIGINALLETTERSUBCATEGORYID"
		_originallettersubcategoryid.Caption = "Original Letter Subcategory"
		_originallettersubcategoryid.SimpleDataListID = New Guid("0eacc39b-07d1-4641-8774-e319559535a7")
		Me.Fields.Add(_originallettersubcategoryid)
		'
		'_originallettersequenceid
		'
		_originallettersequenceid.Name = "ORIGINALLETTERSEQUENCEID"
		_originallettersequenceid.Caption = "Original Letter Sequence ID"
		_originallettersequenceid.DoNotApplyFormat = True
		Me.Fields.Add(_originallettersequenceid)
		'
		'_completedaftercancellationcode
		'
		_completedaftercancellationcode.Name = "COMPLETEDAFTERCANCELLATIONCODE"
		_completedaftercancellationcode.Caption = "Completed after cancellation"
		_completedaftercancellationcode.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of Nullable(Of COMPLETEDAFTERCANCELLATIONCODES)) With {.Value = COMPLETEDAFTERCANCELLATIONCODES.[No], .Translation = "No"})
		_completedaftercancellationcode.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of Nullable(Of COMPLETEDAFTERCANCELLATIONCODES)) With {.Value = COMPLETEDAFTERCANCELLATIONCODES.[Yes], .Translation = "Yes"})
		Me.Fields.Add(_completedaftercancellationcode)
		'
		'_printblackoutlabel
		'
		_printblackoutlabel.Name = "PRINTBLACKOUTLABEL"
		_printblackoutlabel.Caption = "Print blackout label"
		_printblackoutlabel.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of Nullable(Of PRINTBLACKOUTLABELS)) With {.Value = PRINTBLACKOUTLABELS.[No], .Translation = "No"})
		_printblackoutlabel.DataSource.Add(New Global.Blackbaud.AppFx.UIModeling.Core.ValueListItem(Of Nullable(Of PRINTBLACKOUTLABELS)) With {.Value = PRINTBLACKOUTLABELS.[Yes], .Translation = "Yes"})
		Me.Fields.Add(_printblackoutlabel)
		'
		'_reservationreqrepcode
		'
		_reservationreqrepcode.Name = "RESERVATIONREQREPCODE"
		_reservationreqrepcode.Caption = "Rep code"
		_reservationreqrepcode.MaxLength = 100
		Me.Fields.Add(_reservationreqrepcode)
		'
		'_reservationreqnumberofprofiles
		'
		_reservationreqnumberofprofiles.Name = "RESERVATIONREQNUMBEROFPROFILES"
		_reservationreqnumberofprofiles.Caption = "Number of profiles"
		Me.Fields.Add(_reservationreqnumberofprofiles)
		'
		'_reservationreqdisplayracks
		'
		_reservationreqdisplayracks.Name = "RESERVATIONREQDISPLAYRACKS"
		_reservationreqdisplayracks.Caption = "Display racks"
		Me.Fields.Add(_reservationreqdisplayracks)
		'
		'_reservationreqbrochures
		'
		_reservationreqbrochures.Name = "RESERVATIONREQBROCHURES"
		_reservationreqbrochures.Caption = "Brochures"
		Me.Fields.Add(_reservationreqbrochures)
		'
		'_reservationreqexpecteddatetypecodeid
		'
		_reservationreqexpecteddatetypecodeid.Name = "RESERVATIONREQEXPECTEDDATETYPECODEID"
		_reservationreqexpecteddatetypecodeid.Caption = "Expected date type"
		_reservationreqexpecteddatetypecodeid.CodeTableName = "USR_INTERACTIONEXTENSIONEXPECTEDDATETYPECODE"
		Me.Fields.Add(_reservationreqexpecteddatetypecodeid)
		'
		'_addressblock
		'
		_addressblock.Name = "ADDRESSBLOCK"
		_addressblock.Caption = "Address"
		_addressblock.MaxLength = 150
		_addressblock.MultiLine = True
		Me.Fields.Add(_addressblock)
		'
		'_city
		'
		_city.Name = "CITY"
		_city.Caption = "City"
		_city.MaxLength = 50
		Me.Fields.Add(_city)
		'
		'_stateid
		'
		_stateid.Name = "STATEID"
		_stateid.Caption = "State"
		_stateid.SimpleDataListID = New Guid("b46d36d1-d3ed-4f6e-91da-89b6c88ca0c6")
		_stateid.ShowDescription = True
		Me.Fields.Add(_stateid)
		'
		'_postcode
		'
		_postcode.Name = "POSTCODE"
		_postcode.Caption = "ZIP"
		_postcode.MaxLength = 12
		Me.Fields.Add(_postcode)
		'
		'_children
		'
		_children.Name = "CHILDREN"
		_children.Caption = "Children"
		Me.Fields.Add(_children)

		OnCreated()

	End Sub

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
	Public ReadOnly Property [UNAVAILABLECHILDID]() As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		Get
			Return _unavailablechildid
		End Get
	End Property

	''' <summary>
	''' Transfer child
	''' </summary>
	<System.ComponentModel.Description("Transfer child")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [TRANSFERCHILDID]() As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		Get
			Return _transferchildid
		End Get
	End Property

	''' <summary>
	''' Departed child
	''' </summary>
	<System.ComponentModel.Description("Departed child")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [DEPARTEDCHILDID]() As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
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
	''' Other reason
	''' </summary>
	<System.ComponentModel.Description("Other reason")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [DEPARTUREREASONOTHERDESCRIPTION]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
		Get
			Return _departurereasonotherdescription
		End Get
	End Property

	''' <summary>
	''' Double sponsored child
	''' </summary>
	<System.ComponentModel.Description("Double sponsored child")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [DOUBLESPONSOREDCHILDID]() As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		Get
			Return _doublesponsoredchildid
		End Get
	End Property

	''' <summary>
	''' Previous child project
	''' </summary>
	<System.ComponentModel.Description("Previous child project")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [PREVIOUSCHILDPROJECTID]() As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		Get
			Return _previouschildprojectid
		End Get
	End Property

	''' <summary>
	''' Transfer child project
	''' </summary>
	<System.ComponentModel.Description("Transfer child project")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [TRANSFERCHILDPROJECTID]() As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		Get
			Return _transferchildprojectid
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
	''' Sponsored project
	''' </summary>
	<System.ComponentModel.Description("Sponsored project")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [SPONSOREDPROJECTID]() As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		Get
			Return _sponsoredprojectid
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
	''' Sponsor
	''' </summary>
	<System.ComponentModel.Description("Sponsor")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [SPONSORID]() As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		Get
			Return _sponsorid
		End Get
	End Property
	''' <summary>
	''' Partner
	''' </summary>
	<System.ComponentModel.Description("Partner")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [PARTNERID]() As Global.Blackbaud.AppFx.UIModeling.Core.SearchListField(Of Guid)
		Get
			Return _partnerid
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
	''' Original Letter Subcategory
	''' </summary>
	<System.ComponentModel.Description("Original Letter Subcategory")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [ORIGINALLETTERSUBCATEGORYID]() As Global.Blackbaud.AppFx.UIModeling.Core.SimpleDataListField(Of Guid)
		Get
			Return _originallettersubcategoryid
		End Get
	End Property

	''' <summary>
	''' Original Letter Sequence ID
	''' </summary>
	<System.ComponentModel.Description("Original Letter Sequence ID")> _
	<System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
	Public ReadOnly Property [ORIGINALLETTERSEQUENCEID]() As Global.Blackbaud.AppFx.UIModeling.Core.IntegerField
		Get
			Return _originallettersequenceid
		End Get
	End Property
    
    ''' <summary>
    ''' Completed after cancellation
    ''' </summary>
    <System.ComponentModel.Description("Completed after cancellation")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [COMPLETEDAFTERCANCELLATIONCODE]() As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of COMPLETEDAFTERCANCELLATIONCODES))
        Get
            Return _completedaftercancellationcode
        End Get
    End Property
    
    ''' <summary>
    ''' Print blackout label
    ''' </summary>
    <System.ComponentModel.Description("Print blackout label")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [PRINTBLACKOUTLABEL]() As Global.Blackbaud.AppFx.UIModeling.Core.ValueListField(Of Nullable(Of PRINTBLACKOUTLABELS))
        Get
            Return _printblackoutlabel
        End Get
    End Property
    
    ''' <summary>
    ''' Rep code
    ''' </summary>
    <System.ComponentModel.Description("Rep code")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [RESERVATIONREQREPCODE]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _reservationreqrepcode
        End Get
    End Property
    
    ''' <summary>
    ''' Number of profiles
    ''' </summary>
    <System.ComponentModel.Description("Number of profiles")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [RESERVATIONREQNUMBEROFPROFILES]() As Global.Blackbaud.AppFx.UIModeling.Core.SmallIntField
        Get
            Return _reservationreqnumberofprofiles
        End Get
    End Property
    
    ''' <summary>
    ''' Display racks
    ''' </summary>
    <System.ComponentModel.Description("Display racks")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [RESERVATIONREQDISPLAYRACKS]() As Global.Blackbaud.AppFx.UIModeling.Core.SmallIntField
        Get
            Return _reservationreqdisplayracks
        End Get
    End Property
    
    ''' <summary>
    ''' Brochures
    ''' </summary>
    <System.ComponentModel.Description("Brochures")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [RESERVATIONREQBROCHURES]() As Global.Blackbaud.AppFx.UIModeling.Core.SmallIntField
        Get
            Return _reservationreqbrochures
        End Get
    End Property
    
    ''' <summary>
    ''' Expected date type
    ''' </summary>
    <System.ComponentModel.Description("Expected date type")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [RESERVATIONREQEXPECTEDDATETYPECODEID]() As Global.Blackbaud.AppFx.UIModeling.Core.CodeTableField
        Get
            Return _reservationreqexpecteddatetypecodeid
        End Get
    End Property
    
    ''' <summary>
    ''' Address
    ''' </summary>
    <System.ComponentModel.Description("Address")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [ADDRESSBLOCK]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _addressblock
        End Get
    End Property
    
    ''' <summary>
    ''' City
    ''' </summary>
    <System.ComponentModel.Description("City")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [CITY]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _city
        End Get
    End Property
    
    ''' <summary>
    ''' State
    ''' </summary>
    <System.ComponentModel.Description("State")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [STATEID]() As Global.Blackbaud.AppFx.UIModeling.Core.SimpleDataListField(Of Guid)
        Get
            Return _stateid
        End Get
    End Property
    
    ''' <summary>
    ''' ZIP
    ''' </summary>
    <System.ComponentModel.Description("ZIP")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "2.93.2034.0")> _
    Public ReadOnly Property [POSTCODE]() As Global.Blackbaud.AppFx.UIModeling.Core.StringField
        Get
            Return _postcode
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
