Public Class InteractionExtensionViewFormUIModel

    Private Sub InteractionExtensionViewFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
		Dim myInteractionExtensionHelper = New InteractionExtensionHelper(Me, CRMHelper.FormMode.View)
		myInteractionExtensionHelper.InitializeCodeTableVars()
		myInteractionExtensionHelper.InitializeUIDisplay()
		myInteractionExtensionHelper.UpdateFieldsForSubcategory()

    End Sub

End Class