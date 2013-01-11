Public Class ChildExtensionDepartureFormReceivedDateGlobalChangeUIModel

    Private Sub ChildExtensionDepartureFormReceivedDateGlobalChangeUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
		'turn off the fields until user decides what they're doing
		Me.OVERWRITEEXISTINGVALUE.Visible = False
		Me.ADDDEPARTUREFORMRECEIVEDDATEVALUE.Visible = False
		Me.OVERWRITEEXISTINGVALUE.Visible = False
		Me.REPLACEDEPARTUREFORMRECEIVEDDATEVALUE.Visible = False
		Me.REPLACEDEPARTUREFORMRECEIVEDDATEWITHVALUE.Visible = False
		Me.DELETEDEPARTUREFORMRECEIVEDDATEVALUE.Visible = False
		Me.DELETEALLVALUES.Visible = False

		'turn on appropriate fields for user editing:
		SetFieldsVisible()
    End Sub

	Private Sub _operation_ValueChanged(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _operation.ValueChanged
		SetFieldsVisible()
	End Sub


	Private Sub _deleteallPROFILESTATUSvalues_ValueChanged(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _deleteallvalues.ValueChanged
		If Me.DELETEALLVALUES.Value Then
			Me.DELETEDEPARTUREFORMRECEIVEDDATEVALUE.Enabled = False
		Else
			Me.DELETEDEPARTUREFORMRECEIVEDDATEVALUE.Enabled = True
		End If

	End Sub

	Private Sub SetFieldsVisible()
		'turn on the appropriate field based on user input:
		If Me.OPERATION.HasValue() Then
			Me.ADDDEPARTUREFORMRECEIVEDDATEVALUE.Visible = (Me.OPERATION.Value = OPERATIONS.Add)
			Me.OVERWRITEEXISTINGVALUE.Visible = (Me.OPERATION.Value = OPERATIONS.Add)
			Me.REPLACEDEPARTUREFORMRECEIVEDDATEVALUE.Visible = (Me.OPERATION.Value = OPERATIONS.Replace)
			Me.REPLACEDEPARTUREFORMRECEIVEDDATEWITHVALUE.Visible = (Me.OPERATION.Value = OPERATIONS.Replace)
			Me.DELETEDEPARTUREFORMRECEIVEDDATEVALUE.Visible = (Me.OPERATION.Value = OPERATIONS.Delete)
			Me.DELETEALLVALUES.Visible = (Me.OPERATION.Value = OPERATIONS.Delete)
		End If

	End Sub

End Class