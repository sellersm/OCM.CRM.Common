Public Class ChildFieldMemoDateSentGlobalChangeUIModel

	Private Const ADDVALUETEXT As String = "1" ' "Add"
	Private Const REPLACEVALUETEXT As String = "2" ' "Replace"
	Private Const DELETEVALUETEXT As String = "3" ' "Delete"


	Private Sub ChildFieldMemoDateSentGlobalChangeUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
		'turn off the fields until user decides what they're doing
		Me.ADDDATESENTVALUE.Visible = False
		Me.OVERWRITEEXISTINGVALUE.Visible = False
		Me.REPLACEDATESENTVALUE.Visible = False
		Me.REPLACEDATESENTWITHVALUE.Visible = False
		Me.DELETEDATESENTVALUE.Visible = False
		Me.DELETEALLDATESENTVALUES.Visible = False

		'turn on appropriate fields for user editing:
		SetFieldsVisible()
	End Sub

	Private Sub _operation_ValueChanged(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _operation.ValueChanged
		SetFieldsVisible()
	End Sub


	Private Sub _deletealldatesentvalues_ValueChanged(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _deletealldatesentvalues.ValueChanged
		If Me.DELETEALLDATESENTVALUES.Value Then
			Me.DELETEDATESENTVALUE.Enabled = False
		Else
			Me.DELETEDATESENTVALUE.Enabled = True
		End If
	End Sub

	Private Sub SetFieldsVisible()
		'turn on the appropriate field based on user input:
		If Me.OPERATION.HasValue() Then
			Me.ADDDATESENTVALUE.Visible = Me.OPERATION.Value.ToString().Equals(ADDVALUETEXT)
			Me.OVERWRITEEXISTINGVALUE.Visible = Me.OPERATION.Value.ToString().Equals(ADDVALUETEXT)
			Me.REPLACEDATESENTVALUE.Visible = Me.OPERATION.Value.ToString().Equals(REPLACEVALUETEXT)
			Me.REPLACEDATESENTWITHVALUE.Visible = Me.OPERATION.Value.ToString().Equals(REPLACEVALUETEXT)
			Me.DELETEDATESENTVALUE.Visible = Me.OPERATION.Value.ToString().Equals(DELETEVALUETEXT)
			Me.DELETEALLDATESENTVALUES.Visible = Me.OPERATION.Value.ToString().Equals(DELETEVALUETEXT)
		End If

	End Sub
End Class