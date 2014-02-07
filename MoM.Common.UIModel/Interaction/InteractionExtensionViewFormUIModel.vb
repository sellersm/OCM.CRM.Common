Public Class InteractionExtensionViewFormUIModel
	' The codegen partial class of this uimodel form can be refreshed using Tools / Refresh UI Model
	' The only part that has code that will be overwritten is the codegen for the CHILDREN collection - InteractionExtensionViewFormCHILDRENUIModel.CodeGen.vb
	'
	' If not making any changes to the fields on the CHILDREN collection, the best thing to do is perform a Refresh UI Model and then use TortoiseHg to revert 
	' InteractionExtensionViewFormCHILDRENUIModel.CodeGen.vb back to what it was before running the Refresh UI Model.
	'
	' If you are making changes to fields on the CHILDREN collection, you will need to set the Enabled property on the fields to false.
	'	for example set these in the part of the code before adding the field to the fields collection - Me.Fields.Add(_sponsorshipopportunitychildid)
	'		_childlookupid.Enabled = False
	'		_sponsorshipopportunitychildid.Enabled = False

    Private Sub InteractionExtensionViewFormUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
		Dim myInteractionExtensionHelper = New InteractionExtensionHelper(Me, CRMHelper.FormMode.View)
		myInteractionExtensionHelper.InitializeCodeTableVars()
		myInteractionExtensionHelper.InitializeUIDisplay()
		myInteractionExtensionHelper.UpdateFieldsForSubcategory()

    End Sub

End Class