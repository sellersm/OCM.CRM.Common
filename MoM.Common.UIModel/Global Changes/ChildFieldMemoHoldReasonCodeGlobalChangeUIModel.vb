Public Class ChildFieldMemoHoldReasonCodeGlobalChangeUIModel
	Private Const ADDVALUETEXT As String = "1" ' "Add"
	Private Const REPLACEVALUETEXT As String = "2" ' "Replace"
	Private Const DELETEVALUETEXT As String = "3" ' "Delete"

    Private Sub ChildFieldMemoHoldReasonCodeGlobalChangeUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
		'turn off the fields until user decides what they're doing
		Me.OVERWRITEEXISTINGVALUE.Visible = False
		Me.ADDHOLDREASONCODEVALUE.Visible = False
		Me.OVERWRITEEXISTINGVALUE.Visible = False
		Me.REPLACEHOLDREASONCODEVALUE.Visible = False
		Me.REPLACEHOLDREASONCODEWITHVALUE.Visible = False
		Me.DELETEHOLDREASONCODEVALUE.Visible = False
		Me.DELETEALLHOLDREASONCODEVALUES.Visible = False

		'turn on appropriate fields for user editing:
		SetFieldsVisible()

    End Sub

	Private Sub _operation_ValueChanged(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _operation.ValueChanged
		SetFieldsVisible()
	End Sub


	Private Sub _deleteallholdreasoncodevalues_ValueChanged(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _deleteallholdreasoncodevalues.ValueChanged
		If Me.DELETEALLHOLDREASONCODEVALUES.Value Then
			Me.DELETEHOLDREASONCODEVALUE.Enabled = False
		Else
			Me.DELETEHOLDREASONCODEVALUE.Enabled = True
		End If

	End Sub

	Private Sub SetFieldsVisible()
		'turn on the appropriate field based on user input:
		If Me.OPERATION.HasValue() Then
			Me.ADDHOLDREASONCODEVALUE.Visible = Me.OPERATION.Value.ToString().Equals(ADDVALUETEXT)
			Me.OVERWRITEEXISTINGVALUE.Visible = Me.OPERATION.Value.ToString().Equals(ADDVALUETEXT)
			Me.REPLACEHOLDREASONCODEVALUE.Visible = Me.OPERATION.Value.ToString().Equals(REPLACEVALUETEXT)
			Me.REPLACEHOLDREASONCODEWITHVALUE.Visible = Me.OPERATION.Value.ToString().Equals(REPLACEVALUETEXT)
			Me.DELETEHOLDREASONCODEVALUE.Visible = Me.OPERATION.Value.ToString().Equals(DELETEVALUETEXT)
			Me.DELETEALLHOLDREASONCODEVALUES.Visible = Me.OPERATION.Value.ToString().Equals(DELETEVALUETEXT)
		End If

	End Sub

End Class