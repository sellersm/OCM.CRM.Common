Public Class InteractionExtensionEditFormUIModel
	' The codegen partial class of this uimodel form can be refreshed using Tools / Refresh UI Model
	' The only part that has code that will be overwritten is the codegen for the CHILDREN collection - InteractionExtensionEditFormCHILDRENUIModel.CodeGen.vb
	'
	' If not making any changes to the fields on the CHILDREN collection, the best thing to do is perform a Refresh UI Model and then use TortoiseHg to revert 
	' InteractionExtensionEditFormCHILDRENUIModel.CodeGen.vb back to what it was before running the Refresh UI Model.
	'
	' If you are making changes to fields on the CHILDREN collection, you will need to set the Enabled property on the CHILDLOOKUPID field to false 
	' in the part of the code before adding the field to the fields collection - Me.Fields.Add(_sponsorshipopportunitychildid)
	'		 _childlookupid.Enabled = False
	'		Me.Fields.Add(_childlookupid)


    Private Sub InteractionExtensionEditFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
        Dim myInteractionExtensionHelper = New InteractionExtensionHelper(Me, CRMHelper.FormMode.Edit)
        myInteractionExtensionHelper.InitializeCodeTableVars()
        myInteractionExtensionHelper.InitializeUIDisplay()
    End Sub

End Class