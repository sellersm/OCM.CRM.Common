Public Class InteractionExtensionAddFormUIModel


    Private Sub InteractionExtensionAddFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
        Dim myInteractionExtensionHelper As New InteractionExtensionHelper(Me, CRMHelper.FormMode.Add)
        myInteractionExtensionHelper.InitializeCodeTableVars()
        'myInteractionExtensionHelper.InitializeUIDisplay()
    End Sub

End Class