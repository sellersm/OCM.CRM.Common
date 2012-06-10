Imports System.Data.SqlClient
Imports Blackbaud.AppFx
Imports Blackbaud.AppFx.UIModeling.Core

''' <summary>
''' Helper Class used by CRM customizations
''' </summary>
''' <remarks></remarks>
Public Class CRMHelper

    ''' <summary>
    ''' Used to determine the type of form (View or Edit) utilizing a model helper class
    ''' </summary>
    ''' <remarks></remarks>
    ''' <history>
    ''' Date            Modified By     Comments
    ''' 21-Apr-2012     CMayeda         Initial Version
    ''' 27-Apr-2012     CMayeda         Added "Add"
    '''</history>
    Enum FormMode As Byte
        View
        Edit
        Add
    End Enum

    ''' <summary>
    ''' Method to get a code table entry guid through the code table manager
    ''' </summary>
    ''' <param name="crmDBConnection">An opened SQLConnection created through the CRM model</param>
    ''' <param name="vbConstant">VBCONSTANT value in the code table manager to retrieve</param>
    ''' <param name="descriptionModifiedValid">Specifies whether a code table entry whose description has been modified should be considered valid
    '''                                        True - "description modified in code table" Status is considered valid
    '''                                        False - "description modified in code table" Status is NOT considered valid</param>
    ''' <param name="errorMessage">The error message to use for exceptions thrown - used in both sql exceptions and in the case that vbConstant is not found)</param>
    ''' <returns>The GUID of the code table entry if it is valid (taking "descriptionModifiedValid" into account)</returns>
    ''' <remarks>Most of the functionality is actually in the sproc created through an SP spec - USR_USP_GETCODETABLEITEMID</remarks>
    ''' <history>
    ''' Date            Modified By     Comments
    ''' 21-Apr-2012     CMayeda         Initial Version
    ''' 23-Apr-2012     CMayeda         Changed SUSPECTOK parm to DESCRIPTIONMODIFIEDVALID    
    '''                                 Changed crmDBConnection to expect an open sqlconnection, management of the connection is the reponsiblity of the caller
    '''</history>
    Public Shared Function GetCodeTableItemID(ByRef crmDBConnection As SqlConnection, ByVal vbConstant As String, ByVal descriptionModifiedValid As Boolean, ByVal errorMessage As String) As String
        Const storedProcedureName = "USR_USP_GETCODETABLEITEMID"

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
                command.Parameters.AddWithValue("@VBCONSTANT", vbConstant)
                command.Parameters.AddWithValue("@DESCRIPTIONMODIFIEDVALID", descriptionModifiedValid)

                Dim sqlParm As New SqlParameter
                sqlParm.ParameterName = "@CODETABLEITEMID"
                sqlParm.DbType = DbType.Guid
                sqlParm.Direction = ParameterDirection.Output
                command.Parameters.Add(sqlParm)

                command.ExecuteNonQuery()

                If command.Parameters("@CODETABLEITEMID") IsNot Nothing Then
                    GetCodeTableItemID = command.Parameters("@CODETABLEITEMID").Value.ToString
                Else
                    ' If no guid was found in the code table manager for vbConstant, throw an exception
                    Throw New ApplicationException(errorMessage & vbNewLine & vbNewLine & "Code table value was not returned from " & storedProcedureName)
                End If

            Catch ex As ApplicationException
                Throw ex

            Catch ex As Exception
                Throw New Exception(errorMessage & vbNewLine & vbNewLine & ex.Message)
            End Try
        End Using


    End Function


    Public Shared Sub ShowMessage(ByVal message As String, ByVal buttonStyle As UIPromptButtonStyle, ByVal imageStyle As UIPromptImageStyle, ByRef model As UIModeling.Core.RootUIModel)
        Dim prompt As New UIPrompt
        prompt.Text = message
        prompt.ImageStyle = imageStyle
        prompt.ButtonStyle = buttonStyle
        model.Prompts.Add(prompt)
    End Sub

End Class
