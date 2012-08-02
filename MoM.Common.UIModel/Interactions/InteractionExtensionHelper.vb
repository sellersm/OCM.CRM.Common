Imports Blackbaud.AppFx
Imports Blackbaud.AppFx.Constituent.UIModel.Interaction
Imports Blackbaud.AppFx.UIModeling.Core
Imports MoM.Common
Imports System.Linq

Public Class InteractionExtensionHelper
    Private Const errorTextCouldNotFindCategory = "Could not find category, subcategory - "

    Private Property model As UIModeling.Core.RootUIModel = Nothing
    Private Property parentModel As InteractionAddForm2UIModel

    Property helperMode As CRMHelper.FormMode       'Used for specific behavior for view form vs edit form

    ' Code Table IDs
    Property sponsorWelcomeWelcomePacketguid As String = ""


    Private Const quotaTypeCountryEnum = 1


    ' Code Table IDs
    ' none

    Public Sub New(ByVal uiModel As UIModeling.Core.RootUIModel, ByVal mode As CRMHelper.FormMode)
        model = uiModel
        helperMode = mode

        'Add all the handlers
        AddHandler model.HostModelChanged, AddressOf InteractionExtensionAddFormUIModel_HostModelChanged

    End Sub

    ''' <summary>
    ''' 'Initialize Code Table IDs 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitializeCodeTableVars()
        'Initialize Code Table IDs 
        Using crmSQLConnection = model.GetRequestContext().OpenAppDBConnection()
            ' sponsorWelcomeWelcomePacketguid = CRMHelper.GetCodeTableItemID(crmSQLConnection, CodeTableFields.INTERACTIONCATEGORY_SPONSORWELCOME_WELCOMEPACKET, True, errorTextCouldNotFindCategory & CodeTableFields.INTERACTIONCATEGORY_SPONSORWELCOME_WELCOMEPACKET)
        End Using

    End Sub

    ''' <summary>
    ''' Initialize the UI objects based on the loaded form values
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitializeUIDisplay()

    End Sub

    Private Sub InteractionExtensionAddFormUIModel_HostModelChanged(sender As Object, e As Blackbaud.AppFx.UIModeling.Core.HostModelChangedEventArgs)
        If parentModel Is Nothing Then
            parentModel = DirectCast(model.HostModel, InteractionAddForm2UIModel)
        End If

        If model.HostModel IsNot Nothing Then
            AddHandler parentModel.INTERACTIONSUBCATEGORYID.ValueChanged, AddressOf SubcategoryID_ValueChanged
        Else
            RemoveHandler parentModel.INTERACTIONSUBCATEGORYID.ValueChanged, AddressOf SubcategoryID_ValueChanged

        End If

    End Sub

    Private Sub SubcategoryID_ValueChanged(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.ValueChangedEventArgs)
        parentModel.COMMENT.Value = sponsorWelcomeWelcomePacketguid

        If parentModel.INTERACTIONSUBCATEGORYID.Value.ToString = sponsorWelcomeWelcomePacketguid Then
            'parentModel.COMMENT.Value = parentModel.COMMENT.Value + " - found"
            model.Fields(InteractionExtensionFields.CHILDREN).Visible = True
            model.Fields(InteractionExtensionFields.EFTBROCHURE).Visible = True
            model.Fields(InteractionExtensionFields.LETTERCHILDVERSIONCODEID).Visible = True
            model.Fields(InteractionExtensionFields.LETTERTYPECODEID).Visible = True

            model.Fields(InteractionExtensionFields.DEPARTEDCHILDID).Visible = False
            model.Fields(InteractionExtensionFields.DOUBLESPONSOREDCHILDID).Visible = False
            model.Fields(InteractionExtensionFields.UNAVILABLECHILDID).Visible = False
            model.Fields(InteractionExtensionFields.TRANSFERCHILDID).Visible = False
            model.Fields(InteractionExtensionFields.PREVIOUSBIRTHDATE).Visible = False
            model.Fields(InteractionExtensionFields.PREVIOUSCHILDPROJECTID).Visible = False
            model.Fields(InteractionExtensionFields.PREVIOUSNAME).Visible = False

        Else
            'parentModel.COMMENT.Value = parentModel.COMMENT.Value + " - not found"
            model.Fields(InteractionExtensionFields.CHILDREN).Visible = True
            model.Fields(InteractionExtensionFields.DEPARTEDCHILDID).Visible = True
            model.Fields(InteractionExtensionFields.DOUBLESPONSOREDCHILDID).Visible = True
            model.Fields(InteractionExtensionFields.UNAVILABLECHILDID).Visible = True
            model.Fields(InteractionExtensionFields.TRANSFERCHILDID).Visible = True
            model.Fields(InteractionExtensionFields.PREVIOUSBIRTHDATE).Visible = True
            model.Fields(InteractionExtensionFields.PREVIOUSCHILDPROJECTID).Visible = True
            model.Fields(InteractionExtensionFields.PREVIOUSNAME).Visible = True

            model.Fields(InteractionExtensionFields.EFTBROCHURE).Visible = True
            model.Fields(InteractionExtensionFields.LETTERCHILDVERSIONCODEID).Visible = True
            model.Fields(InteractionExtensionFields.LETTERTYPECODEID).Visible = True
        End If

    End Sub
    ''' <summary>
    ''' Toggle the quota fields based on the type of quota
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Toggle_ApprovedQuotaFields()
        Dim projectQuota As Boolean = False     ' Used to determine if we are hiding/disabling the fields

        model.Fields(InteractionExtensionFields.PREVIOUSBIRTHDATE).Visible = Not model.Fields(InteractionExtensionFields.PREVIOUSBIRTHDATE).Visible

        '' This includes blank and project quota - basically not Country quota
        'projectQuota = (model.Fields(ChildProjectFields.QUOTATYPECODE).ValueObject Is Nothing OrElse
        '               CInt(model.Fields(ChildProjectFields.QUOTATYPECODE).ValueObject) <> quotaTypeCountryEnum)


        '' Hide or show all the APPROVEDQUOTA... fields
        'Dim genericList As List(Of UIField) = _model.Fields.ToList()
        'Dim fieldsList = (From f In genericList Where f.Name.Contains("APPROVEDQUOTA")
        '                  Select f)
        'For Each field As UIField In fieldsList
        '    Select Case helperMode
        '        Case CRMHelper.FormMode.Edit, CRMHelper.FormMode.Add
        '            field.Enabled = projectQuota
        '            If Not projectQuota Then
        '                field.ValueObject = Nothing
        '            End If
        '        Case CRMHelper.FormMode.View
        '            field.Visible = projectQuota
        '    End Select
        'Next

        '' These computed columns are only on the view form and should be visible only if the quota type is project.
        'If helperMode = CRMHelper.FormMode.View Then
        '    model.Fields(ChildProjectFields.CURRENTQUOTA).Visible = projectQuota
        '    model.Fields(ChildProjectFields.DECREASEDQUOTA).Visible = projectQuota
        '    model.Fields(ChildProjectFields.GROWTHQUOTA).Visible = projectQuota
        'End If

    End Sub



End Class
