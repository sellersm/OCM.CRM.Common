Public Class UpdateChildInteractionsGlobalChangeUIModel

	Private Sub UpdateChildInteractionsGlobalChangeUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded

	End Sub


	Private Sub _replacestatuscodewithvalue_ValueChanged(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _replacestatuscodewithvalue.ValueChanged
		If (Me.REPLACESTATUSCODEWITHVALUE.Value.ToString.Equals("2") Or Me.REPLACESTATUSCODEWITHVALUE.Value.ToString.Equals("Completed")) Then
			'if the user selects Completed, then make actual date required
			Me.ACTUALDATE.Required = True
		Else
			Me.ACTUALDATE.Required = False
		End If
	End Sub


	Private Sub UpdateChildInteractionsGlobalChangeUIModel_Validating(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.ValidatingEventArgs) Handles Me.Validating
		'check the actualdate if new status is Completed
		If Me.REPLACESTATUSCODEWITHVALUE.HasValue Then
			If (Me.REPLACESTATUSCODEWITHVALUE.Value.ToString.Equals("2") Or Me.REPLACESTATUSCODEWITHVALUE.Value.ToString.Equals("Completed")) Then
				Me.ACTUALDATE.Required = True
				If Me.ACTUALDATE.HasValue = False Then
					'e.InvalidFieldName = ACTUALDATE.ToString()
					e.InvalidReason = "Actual Date is required if Status is Completed!"
					e.Valid = False
				End If
			Else
				Me.ACTUALDATE.Required = False
			End If
		End If
	End Sub
End Class