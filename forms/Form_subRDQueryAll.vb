Option Compare Database

Private Sub Form_Load()

    ' Check field lock status from main form.
    If Forms!Participants!LockFields.Value = "Locked" Then
        fncLockUnlockControls Me, True, False, RGB(225, 225, 225) 'Locked
    ElseIf Forms!Participants!LockFields.Value = "Unlocked" Then
        fncLockUnlockControls Me, False, True, RGB(255, 255, 255) 'Unlocked
    End If
    
End Sub

Private Sub Form_Current()

    ' Minimal entry fields on subform locks.
    If IsEmpty(Me.RD_nhs_number.Value) = False Then
        Me.RD_nhs_number.enabled = False
        Me.RD_nhs_number.Locked = True
        Me.RD_nhs_number.BackColor = RGB(225, 225, 225)
 
    End If
    
End Sub
