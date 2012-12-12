Public Class InteractionExtensionEditFormUIModel

    Private Sub InteractionExtensionEditFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
        Dim myInteractionExtensionHelper = New InteractionExtensionHelper(Me, CRMHelper.FormMode.Edit)
        myInteractionExtensionHelper.InitializeCodeTableVars()
        myInteractionExtensionHelper.InitializeUIDisplay()
    End Sub

End Class