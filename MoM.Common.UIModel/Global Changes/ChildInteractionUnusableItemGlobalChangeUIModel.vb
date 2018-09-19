Public Class ChildInteractionUnusableItemGlobalChangeUIModel
    Private Const ADDVALUETEXT As String = "1" ' "Add"
    Private Const REPLACEVALUETEXT As String = "2" ' "Replace"
    Private Const DELETEVALUETEXT As String = "3" ' "Delete"

    Private Sub ChildInteractionUnusableItemGlobalChangeUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
        'turn off the fields until user decides what they're doing
        Me.OVERWRITEEXISTINGVALUE.Visible = False
        Me.ADD_UNUSABLE_ITEMCODE_VALUE.Visible = False
        Me.REPLACE_UNUSABLE_ITEMCODE_VALUE.Visible = False
        Me.REPLACE_UNUSABLE_ITEMCODE_WITHVALUE.Visible = False
        Me.DELETE_UNUSABLE_ITEMCODE_VALUE.Visible = False
        Me.DELETEALL_UNUSABLE_ITEMCODE_VALUES.Visible = False

        'turn on appropriate fields for user editing:
        SetFieldsVisible()

    End Sub

    Private Sub _operation_ValueChanged(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _operation.ValueChanged
        SetFieldsVisible()
    End Sub


    Private Sub _deleteallunusableitemcodevalues_ValueChanged(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _deleteallunusableitemcodevalues.ValueChanged
        If Me.DELETEALL_UNUSABLE_ITEMCODE_VALUES.Value Then
            Me.DELETE_UNUSABLE_ITEMCODE_VALUE.Enabled = False
        Else
            Me.DELETE_UNUSABLE_ITEMCODE_VALUE.Enabled = True
        End If

    End Sub

    Private Sub SetFieldsVisible()
        'turn on the appropriate field based on user input:
        If Me.OPERATION.HasValue() Then
            Me.ADD_UNUSABLE_ITEMCODE_VALUE.Visible = Me.OPERATION.Value.ToString().Equals(ADDVALUETEXT)
            Me.OVERWRITEEXISTINGVALUE.Visible = Me.OPERATION.Value.ToString().Equals(ADDVALUETEXT)
            Me.REPLACE_UNUSABLE_ITEMCODE_VALUE.Visible = Me.OPERATION.Value.ToString().Equals(REPLACEVALUETEXT)
            Me.REPLACE_UNUSABLE_ITEMCODE_WITHVALUE.Visible = Me.OPERATION.Value.ToString().Equals(REPLACEVALUETEXT)
            Me.DELETE_UNUSABLE_ITEMCODE_VALUE.Visible = Me.OPERATION.Value.ToString().Equals(DELETEVALUETEXT)
            Me.DELETEALL_UNUSABLE_ITEMCODE_VALUES.Visible = Me.OPERATION.Value.ToString().Equals(DELETEVALUETEXT)
        End If

    End Sub
End Class