Option Compare Database

Private Sub ChangeViewButton_Click()

        DoCmd.RunCommand acCmdDatasheetView
 
End Sub

Private Sub Form_Load()

    ' Check field lock status from main form.
    If Forms!Participants!LockRadioButton.Value = 1 Then
        fncLockUnlockControls Me, True, False, RGB(225, 225, 225) 'Locked
    ElseIf Forms!Participants!LockRadioButton.Value = 2 Then
        fncLockUnlockControls Me, False, True, RGB(255, 255, 255) 'Unlocked
    End If
    
End Sub

Private Sub Form_Current()

    ' Minimal entry fields on subform locks.
    If IsEmpty(Me.HAEM_nhs_number.Value) = False Then
        Me.HAEM_nhs_number.enabled = False
        Me.HAEM_nhs_number.Locked = True
        Me.HAEM_nhs_number.BackColor = RGB(225, 225, 225)
 
    End If
    
End Sub
