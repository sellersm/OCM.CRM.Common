Imports System.Text
Imports System.Data.SqlClient

Public Class RunOurSqlCommandsEditDataFormUIModel

	Private Sub RunOurSqlCommandsEditDataFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
		Me.FORMHEADER.Value = "Run our SQL"
		Me.FixedDialog = False
		If UserHasAdminPermissions() = False Then
			Me.RESULTS.Value = "You do not have permission to use this form.  Sorry..."
			Me.Cancel()
		End If
	End Sub

	Private Sub _executesql_InvokeAction(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.InvokeActionEventArgs) Handles _executesql.InvokeAction
		Dim isValid As Boolean = True
		Dim isUpdate As Boolean = False

		' check for any delete statements in the SQL, those aren't allowed!
		If Me.COMMAND.HasValue Then
			If Me.COMMAND.Value.ToString().ToLower().Contains("delete") Then
				Me.RESULTS.Value = "You are not allowed to run a Delete statement!  Shame on you for trying..."
				isValid = False
			ElseIf Me.COMMAND.Value.ToString().ToLower().Contains("update") Then
				isUpdate = True
			End If

			If isValid Then
				'check for any alter tables, inserts:
				If Me.COMMAND.Value.ToString().ToLower().Contains("insert") Then
					Me.RESULTS.Value = "You are not allowed to run an Insert statement!  Shame on you for trying..."
					isValid = False
				ElseIf Me.COMMAND.Value.ToString().ToLower().Contains("alter") Then
					Me.RESULTS.Value = "You are not allowed to run any form of an Alter statement!  Shame on you for trying..."
					isValid = False
				End If
			End If
		End If

		'run the SQL command here:
		If isValid = True Then

			Using conn As SqlClient.SqlConnection = Me.GetRequestContext().OpenAppDBConnection()
				Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand()
				cmd.Connection = conn
				cmd.CommandText = Me.COMMAND.Value
				cmd.CommandType = CommandType.Text

				'get the column list:
                Dim columns As New List(Of String)
				Dim columnName As String
				If Me.COLUMNLIST.HasValue Then
                    columns = Me.COLUMNLIST.Value.Split(New Char() {","c}).ToList()
				Else
					If isUpdate = False Then
						' don't need output columns for an update
						Me.RESULTS.Value = "You must have at least one output column in the query!"
						isValid = False
					End If
				End If


				Try
					If (Not isUpdate) AndAlso (isValid = True) Then
						Dim dr As SqlDataReader = cmd.ExecuteReader()
						Dim output As StringBuilder = New StringBuilder()
						If dr.HasRows Then
							While dr.Read()
								' Use For Each loop over words and display them
								For Each columnName In columns
									If dr(columnName) <> Nothing Then
										output.AppendLine(dr(columnName).ToString())
									End If
								Next
							End While
							Me.RESULTS.Value = output.ToString()
						Else
							Me.RESULTS.Value = "No results returned from query..."
						End If
					Else
						If isValid = True Then
							cmd.ExecuteNonQuery()
							Me.RESULTS.Value = "The statement completed successfully."
						End If
					End If

				Catch ex As Exception
					Me.RESULTS.Value = ex.Message
				End Try

			End Using
		End If

	End Sub

	Private Function UserHasAdminPermissions() As Boolean
		Dim isAdmin As Boolean = False

		'check permissions for the user, they must be a sys admin to run SQL:
		'call this ufn to check: dbo.UFN_APPUSER_ISSYSADMIN(@CURRENTAPPUSERID) = 1
		' the app user id is different from changeagent, so need a way to get the AppUser
		' display this value & see if it matches the app user:
		' GetRequestContext.AppUserInfo.AppUserDBId
		'Me.RESULTS.Value = GetRequestContext.AppUserInfo.AppUserDBId.ToString()

		Using conn As SqlClient.SqlConnection = Me.GetRequestContext().OpenAppDBConnection()
			Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand()
			cmd.Connection = conn
			cmd.CommandText = "select dbo.UFN_APPUSER_ISSYSADMIN('" + GetRequestContext.AppUserInfo.AppUserDBId.ToString() + "') as ISADMIN"
			cmd.CommandType = CommandType.Text

			Try
				Dim dr As SqlDataReader = cmd.ExecuteReader()
				Dim output As StringBuilder = New StringBuilder()
				If dr.HasRows Then
					While dr.Read()
						' Use For Each loop over words and display them
						If dr("ISADMIN").ToString().Equals("True") Then
							isAdmin = True
						End If
					End While
					Me.RESULTS.Value = "You have permissions, enter your SQL statement above."
				Else
					Me.RESULTS.Value = "Unable to check your permissions..."
				End If

			Catch ex As Exception
				Me.RESULTS.Value = ex.Message
			End Try

			Return isAdmin

		End Using

	End Function

End Class