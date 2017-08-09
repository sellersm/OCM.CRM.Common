Public Class ArtistPartnerIDGlobalChangeUIModel
	Private Const ADDVALUETEXT As String = "Add"
	Private Const REPLACEVALUETEXT As String = "Replace"
	Private Const DELETEVALUETEXT As String = "Delete"

    Private Sub ArtistPartnerIDGlobalChangeUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
		'turn off the fields until user decides what they're doing
		Me.OVERWRITEEXISTINGVALUE.Visible = False
		Me.ADDVALUE.Visible = False
		Me.OVERWRITEEXISTINGVALUE.Visible = False
		Me.REPLACEVALUE.Visible = False
		Me.REPLACEWITHVALUE.Visible = False
		Me.DELETEVALUE.Visible = False
		Me.DELETEALLVALUES.Visible = False

		'turn on appropriate fields for user editing:
		SetFieldsVisible()

	End Sub

	Private Sub _operation_ValueChanged(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _operation.ValueChanged
		SetFieldsVisible()
	End Sub


	Private Sub _deleteallvalues_ValueChanged(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _deleteallvalues.ValueChanged
		If Me.DELETEALLVALUES.Value Then
			Me.DELETEVALUE.Enabled = False
		Else
			Me.DELETEVALUE.Enabled = True
		End If

	End Sub

	Private Sub SetFieldsVisible()
		'turn on the appropriate field based on user input:
		If Me.OPERATION.HasValue() Then
			'DisplayPrompt(OPERATION.Value.ToString())

			Me.ADDVALUE.Visible = Me.OPERATION.Value.ToString().Equals(ADDVALUETEXT)
			Me.OVERWRITEEXISTINGVALUE.Visible = Me.OPERATION.Value.ToString().Equals(ADDVALUETEXT)
			Me.REPLACEVALUE.Visible = Me.OPERATION.Value.ToString().Equals(REPLACEVALUETEXT)
			Me.REPLACEWITHVALUE.Visible = Me.OPERATION.Value.ToString().Equals(REPLACEVALUETEXT)
			Me.DELETEVALUE.Visible = Me.OPERATION.Value.ToString().Equals(DELETEVALUETEXT)
			Me.DELETEALLVALUES.Visible = Me.OPERATION.Value.ToString().Equals(DELETEVALUETEXT)
		End If

	End Sub

	Private Sub DisplayPrompt(ByVal message As String)
		Me.Prompts.Add(New UIPrompt() With { _
		  .Text = message, _
		  .ButtonStyle = UIPromptButtonStyle.Ok})
	End Sub

End Class