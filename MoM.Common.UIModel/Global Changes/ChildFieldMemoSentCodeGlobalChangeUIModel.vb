Public Class ChildFieldMemoSentCodeGlobalChangeUIModel
	Private Const ADDVALUETEXT As String = "1" ' "Add"
	Private Const REPLACEVALUETEXT As String = "2" ' "Replace"
	Private Const DELETEVALUETEXT As String = "3" ' "Delete"

    Private Sub ChildFieldMemoSentCodeGlobalChangeUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
		'turn off the fields until user decides what they're doing
		Me.OVERWRITEEXISTINGVALUE.Visible = False
		Me.ADDSENTCODEVALUE.Visible = False
		Me.OVERWRITEEXISTINGVALUE.Visible = False
		Me.REPLACESENTCODEVALUE.Visible = False
		Me.REPLACESENTCODEWITHVALUE.Visible = False
		Me.DELETESENTCODEVALUE.Visible = False
		Me.DELETEALLSENTCODEVALUES.Visible = False

		'turn on the appropriate fields if user is editing the form:
		SetFieldsVisible()

    End Sub

	Private Sub _operation_ValueChanged(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _operation.ValueChanged
		SetFieldsVisible()
	End Sub


	Private Sub _deleteallsentcodevalues_ValueChanged(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _deleteallsentcodevalues.ValueChanged
		If Me.DELETEALLSENTCODEVALUES.Value Then
			Me.DELETESENTCODEVALUE.Enabled = False
		Else
			Me.DELETESENTCODEVALUE.Enabled = True
		End If

	End Sub

	Private Sub SetFieldsVisible()
		'turn on the appropriate field based on user input:
		If Me.OPERATION.HasValue() Then
			Me.ADDSENTCODEVALUE.Visible = Me.OPERATION.Value.ToString().Equals(ADDVALUETEXT)
			Me.OVERWRITEEXISTINGVALUE.Visible = Me.OPERATION.Value.ToString().Equals(ADDVALUETEXT)
			Me.REPLACESENTCODEVALUE.Visible = Me.OPERATION.Value.ToString().Equals(REPLACEVALUETEXT)
			Me.REPLACESENTCODEWITHVALUE.Visible = Me.OPERATION.Value.ToString().Equals(REPLACEVALUETEXT)
			Me.DELETESENTCODEVALUE.Visible = Me.OPERATION.Value.ToString().Equals(DELETEVALUETEXT)
			Me.DELETEALLSENTCODEVALUES.Visible = Me.OPERATION.Value.ToString().Equals(DELETEVALUETEXT)
		End If
	End Sub


End Class