Public Class ChildExtensionFulfillmentStatusGlobalChangeUIModel

    Private Sub ChildExtensionFulfillmentStatusGlobalChangeUIModel_Loaded(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs) Handles Me.Loaded
        Me.ADDFULFILLMENTSTATUSVALUE.Visible = False
        Me.DELETEFULFILLMENTSTATUSVALUE.Visible = False
        Me.REPLACEFULFILLMENTSTATUSVALUE.Visible = False
        Me.REPLACEFULFILLMENTSTATUSWITHVALUE.Visible = False
        Me.OVERWRITEEXISTINGVALUE.Visible = False
        Me.DELETEALLVALUES.Visible = False

        'turn on appropriate fields for user editing:
        SetFieldsVisible()
    End Sub

    Private Sub _operation_ValueChanged(ByVal sender As Object, ByVal e As Blackbaud.AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _operation.ValueChanged
        SetFieldsVisible()
    End Sub

    Private Sub SetFieldsVisible()
        'turn on the appropriate field based on user input:
        If Me.OPERATION.HasValue() Then
            Me.ADDFULFILLMENTSTATUSVALUE.Visible = (Me.OPERATION.Value = OPERATIONS.Add)
            Me.OVERWRITEEXISTINGVALUE.Visible = (Me.OPERATION.Value = OPERATIONS.Add)
            Me.REPLACEFULFILLMENTSTATUSVALUE.Visible = (Me.OPERATION.Value = OPERATIONS.Replace)
            Me.REPLACEFULFILLMENTSTATUSWITHVALUE.Visible = (Me.OPERATION.Value = OPERATIONS.Replace)
            Me.DELETEFULFILLMENTSTATUSVALUE.Visible = (Me.OPERATION.Value = OPERATIONS.Delete)
            Me.DELETEALLVALUES.Visible = (Me.OPERATION.Value = OPERATIONS.Delete)
        End If

    End Sub

    Private Sub _deletefulfillmentstatusvalue_ValueChanged(sender As Object, e As Blackbaud.AppFx.UIModeling.Core.ValueChangedEventArgs) Handles _deletefulfillmentstatusvalue.ValueChanged
        If Me.DELETEALLVALUES.Value Then
            Me.DELETEFULFILLMENTSTATUSVALUE.Enabled = False
        Else
            Me.DELETEFULFILLMENTSTATUSVALUE.Enabled = True
        End If
    End Sub


End Class