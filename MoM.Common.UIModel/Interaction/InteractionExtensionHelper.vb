Imports System.Data.SqlClient
Imports System.Linq
Imports Blackbaud.AppFx
Imports Blackbaud.AppFx.Constituent.UIModel.Interaction
Imports Blackbaud.AppFx.UIModeling.Core
Imports MoM.Common


Public Class InteractionExtensionFieldProperties
    Public Property isVisible As Boolean
    Public Property isRequired As Boolean
End Class

Public Class InteractionExtensionHelper

    Private Const errorTextCouldNotFindCategory = "Could not find category, subcategory - "
    Private Const errorTextcouldNotFindLetterChildVersion_OneChildLetter = "Cound not find 'One Child Letter' letter version code table value"
    Private Const errorTextcouldNotFindLetterChildVersion_TwoChildrenLetter = "Cound not find 'Two Children Letter' letter version code table value"
    Private Const errorTextcouldNotFindLetterChildVersion_MultipleChildrenLetter = "Cound not find 'Multiple Children Letter' letter version code table value"

    'Private Property model As UIModeling.Core.RootUIModel = Nothing
    Private Property model As RootUIModel
    Private Property modelAdd As InteractionExtensionAddFormUIModel
    Private Property modelEdit As InteractionExtensionEditFormUIModel
    Private Property parentModel As RootUIModel

    Property helperMode As CRMHelper.FormMode       'Used for specific behavior for view form vs edit form

    ' Code Table IDs
    Property letterChildVersion_OneChildLetterGUID As String = ""
    Property letterChildVersion_TwoChildrenLetterGUID As String = ""
    Property letterChildVersion_MultipleChildrenLetterGUID As String = ""


    Public Sub New(ByVal uiModel As UIModeling.Core.RootUIModel, ByVal mode As CRMHelper.FormMode)
        model = uiModel
        helperMode = mode

        Select Case helperMode
            Case CRMHelper.FormMode.Add
                modelAdd = DirectCast(model, InteractionExtensionAddFormUIModel)
            Case CRMHelper.FormMode.Edit
                modelEdit = DirectCast(model, InteractionExtensionEditFormUIModel)
        End Select

        parentModel = DirectCast(model.HostModel, RootUIModel)

        'Add all the handlers
        AddHandler model.HostModelChanged, AddressOf InteractionExtensionDataFormUIModel_HostModelChanged

        Select Case helperMode
            Case CRMHelper.FormMode.Add
                AddHandler modelAdd.CHILDREN.Value.ListChanged, AddressOf Children_ListChanged
            Case CRMHelper.FormMode.Edit
                AddHandler modelEdit.CHILDREN.Value.ListChanged, AddressOf Children_ListChanged
        End Select

        'AddHandler Me.CHILDREN.Value.RemovingItem, AddressOf ChildrenSelected_ListChanged

    End Sub

    ''' <summary>
    ''' 'Initialize Code Table IDs 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitializeCodeTableVars()
        'Initialize Code Table IDs 
        Using crmSQLConnection = model.GetRequestContext().OpenAppDBConnection()
            letterChildVersion_OneChildLetterGUID = CRMHelper.GetCodeTableItemID(crmSQLConnection, CodeTableFields.INTERACTIONEXTENSIONLETTERCHILDVERSION_ONECHILDLETTER, True, errorTextcouldNotFindLetterChildVersion_OneChildLetter)
            letterChildVersion_TwoChildrenLetterGUID = CRMHelper.GetCodeTableItemID(crmSQLConnection, CodeTableFields.INTERACTIONEXTENSIONLETTERCHILDVERSION_TWOCHILDRENLETTER, True, errorTextcouldNotFindLetterChildVersion_TwoChildrenLetter)
            letterChildVersion_MultipleChildrenLetterGUID = CRMHelper.GetCodeTableItemID(crmSQLConnection, CodeTableFields.INTERACTIONEXTENSIONLETTERCHILDVERSION_MULTIPLECHILDRENLETTER, True, errorTextcouldNotFindLetterChildVersion_MultipleChildrenLetter)
        End Using

    End Sub

    ''' <summary>
    ''' Initialize the UI objects based on the loaded form values
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitializeUIDisplay()
        Dim genericList As List(Of UIField) = _model.Fields.ToList()
        Dim fieldsList = (From f In genericList Where Not f.Name.Contains("FORMHEADER")
                          Select f)
        For Each field As UIField In fieldsList
            model.Fields(field.Name).Visible = False
        Next
        
    End Sub

    Private Function GetFieldProperties(ByRef crmDBConnection As SqlConnection, ByVal subcategoryID As Guid, ByVal fieldName As String) As InteractionExtensionFieldProperties
        Dim fieldProperties As New InteractionExtensionFieldProperties

        Const storedProcedureName = "USR_USP_INTERACTIONEXTENSION_UIMODELFIELDMANAGER_GETFIELDSTATUS"

        ' Validate crmDBConnection - sqlconnection passed in
        If crmDBConnection Is Nothing Then
            Throw New ArgumentNullException("crmDBConnection cannot be nothing.")
        ElseIf crmDBConnection.State <> ConnectionState.Open Then
            Throw New ArgumentException("crmDBConnection must be an open sql connection.")
        End If

        'Call stored procedure to get the guid for the code table entry speicified by vbConstant
        Using command As SqlCommand = crmDBConnection.CreateCommand()
            Try
                command.CommandText = storedProcedureName
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@interactionSubcategoryID", subcategoryID.ToString)
                command.Parameters.AddWithValue("@uiModelFieldDescription", fieldName)

                Dim sqlParm As New SqlParameter
                sqlParm.ParameterName = "@isVisible"
                sqlParm.DbType = DbType.Byte
                sqlParm.Direction = ParameterDirection.Output
                command.Parameters.Add(sqlParm)

                Dim sqlParm2 As New SqlParameter
                sqlParm2.ParameterName = "@isRequired"
                sqlParm2.DbType = DbType.Byte
                sqlParm2.Direction = ParameterDirection.Output
                command.Parameters.Add(sqlParm2)

                command.ExecuteNonQuery()

                If command.Parameters("@isVisible") Is Nothing Then
                    fieldProperties.isVisible = False
                Else
                    fieldProperties.isVisible = (command.Parameters("@isVisible").Value.ToString = "1")
                End If

                If command.Parameters("@isRequired") Is Nothing Then
                    fieldProperties.isRequired = False
                Else
                    fieldProperties.isRequired = (command.Parameters("@isRequired").Value.ToString = "1")
                End If


            Catch ex As ApplicationException
                Throw ex

            Catch ex As Exception
                Throw New Exception("Could not find settings for field " & fieldName & vbNewLine & vbNewLine & ex.Message)
            End Try
        End Using

        Return fieldProperties
    End Function
    Private Sub InteractionExtensionDataFormUIModel_HostModelChanged(sender As Object, e As Blackbaud.AppFx.UIModeling.Core.HostModelChangedEventArgs)
        If parentModel Is Nothing Then
            parentModel = DirectCast(model.HostModel, RootUIModel)
        End If

        If model.HostModel IsNot Nothing Then
            AddHandler parentModel.Fields(InteractionExtensionFields.INTERACTIONSUBCATEGORYID).ValueChanged, AddressOf SubcategoryID_ValueChanged
            UpdateFieldsForSubcategory()
        Else
            RemoveHandler parentModel.Fields(InteractionExtensionFields.INTERACTIONSUBCATEGORYID).ValueChanged, AddressOf SubcategoryID_ValueChanged
        End If

    End Sub

    Private Sub SubcategoryID_ValueChanged(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.ValueChangedEventArgs)
        UpdateFieldsForSubcategory()        
    End Sub

    Private Sub UpdateFieldsForSubcategory()
        Dim fieldProperties As InteractionExtensionFieldProperties = Nothing
        Dim interactionSubcategoryID As Guid = Nothing
        
        If parentModel.Fields(InteractionExtensionFields.INTERACTIONSUBCATEGORYID).ValueObject IsNot Nothing AndAlso _
           parentModel.Fields(InteractionExtensionFields.INTERACTIONSUBCATEGORYID).ValueObject.ToString <> "00000000-0000-0000-0000-000000000000" Then

            interactionSubcategoryID = New Guid(parentModel.Fields(InteractionExtensionFields.INTERACTIONSUBCATEGORYID).ValueObject.ToString)

            Using crmSQLConnection = model.GetRequestContext().OpenAppDBConnection()
                Dim genericList As List(Of UIField) = _model.Fields.ToList()
                Dim fieldsList = (From f In genericList Where Not f.Name.Contains("FORMHEADER")
                                  Select f)
                For Each field As UIField In fieldsList
                    fieldProperties = GetFieldProperties(crmSQLConnection, interactionSubcategoryID, field.Name)
                    If (Not fieldProperties.isVisible) AndAlso model.Fields(field.Name).Visible Then
                        Select Case field.FieldType
                            Case UIFieldType.Binary
                                model.Fields(field.Name).ValueObject = 0
                            Case UIFieldType.Boolean
                                model.Fields(field.Name).ValueObject = False
                            Case UIFieldType.CodeTable, UIFieldType.Date, UIFieldType.Guid
                                model.Fields(field.Name).ValueObject = Nothing
                            Case UIFieldType.ValueList
                                model.Fields(field.Name).ValueObject = 0
                            Case UIFieldType.String
                                model.Fields(field.Name).ValueObject = ""
                            Case UIFieldType.Collection
                                If field.Name = "CHILDREN" Then
                                    Select helperMode
                                        Case CRMHelper.FormMode.Edit
                                            If modelEdit.CHILDREN.Value.Count > 0 Then
                                                modelEdit.CHILDREN.SelectAllItems()
                                                modelEdit.CHILDREN.Selection.Delete()
                                            End If
                                        Case CRMHelper.FormMode.Add
                                            If modelAdd.CHILDREN.Value.Count > 0 Then
                                                modelAdd.CHILDREN.SelectAllItems()
                                                modelAdd.CHILDREN.Selection.Delete()
                                            End If
                                    End Select
                                End If
                        End Select
                    End If

                    model.Fields(field.Name).Visible = fieldProperties.isVisible
                    model.Fields(field.Name).Required = fieldProperties.isRequired
                Next
            End Using

        End If

    End Sub

    Private Sub Children_ListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs)

        Dim childCount As Integer
        Select Case helperMode
            Case CRMHelper.FormMode.Add
                childCount = modelAdd.CHILDREN.Value.Count
            Case CRMHelper.FormMode.Edit
                childCount = modelEdit.CHILDREN.Value.Count
        End Select

        Select Case childCount
            Case 0
                model.Fields(InteractionExtensionFields.CHILDCOUNTLETTERVERSIONCODEID).ValueObject = Nothing
            Case 1
                model.Fields(InteractionExtensionFields.CHILDCOUNTLETTERVERSIONCODEID).ValueObject = New Guid(letterChildVersion_OneChildLetterGUID)
            Case 2
                model.Fields(InteractionExtensionFields.CHILDCOUNTLETTERVERSIONCODEID).ValueObject = New Guid(letterChildVersion_TwoChildrenLetterGUID)
            Case Is > 2
                model.Fields(InteractionExtensionFields.CHILDCOUNTLETTERVERSIONCODEID).ValueObject = New Guid(letterChildVersion_MultipleChildrenLetterGUID)
        End Select
        If e.NewIndex >= 0 And e.NewIndex < childCount Then
            Select Case helperMode
                Case CRMHelper.FormMode.Add
                    modelAdd.CHILDREN.Value.ElementAt(e.NewIndex).CHILDLOOKUPID.Value = GetChildLookupID(modelAdd.CHILDREN.Value.ElementAt(e.NewIndex).SPONSORSHIPOPPORTUNITYCHILDID.Value)
                Case CRMHelper.FormMode.Edit
                    modelEdit.CHILDREN.Value.ElementAt(e.NewIndex).CHILDLOOKUPID.Value = GetChildLookupID(modelEdit.CHILDREN.Value.ElementAt(e.NewIndex).SPONSORSHIPOPPORTUNITYCHILDID.Value)
            End Select
        End If
    End Sub

    Private Function GetChildLookupID(ByRef sponsorshipOpportunityChildID As Guid) As String
        Dim childLookupID As String = ""

        If sponsorshipOpportunityChildID.ToString <> "00000000-0000-0000-0000-000000000000" Then
            Using crmSQLConnection = model.GetRequestContext().OpenAppDBConnection()
                'Execute function to get the child's lookup id
                Using command As SqlCommand = crmSQLConnection.CreateCommand()
                    Try
                        command.CommandText = "select dbo.USR_UFN_CHILD_GETCHILDLOOKUPID (@sponsorshipOpportunityChildID, 1)"  '1 specifies to include the Project's lookup id

                        command.CommandType = CommandType.Text
                        command.Parameters.AddWithValue("@sponsorshipOpportunityChildID", sponsorshipOpportunityChildID.ToString)

                        childLookupID = command.ExecuteScalar()

                    Catch ex As ApplicationException
                        Throw ex

                    Catch ex As Exception
                        Throw New Exception("Could not find lookup id for sponsorshipOpportuntiyChild - " & sponsorshipOpportunityChildID.ToString & vbNewLine & vbNewLine & ex.Message)
                    End Try
                End Using

            End Using

        End If

        Return childLookupID
    End Function
End Class
