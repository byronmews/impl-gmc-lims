Option Compare Database

Public Function fncLockUnlockControls(frm As Form, lockIt As Boolean, enabled As Boolean, colourFields As String)

    ' Lock or unlock all data-bound controls on form,
    ' Depending on the values of : True = lock; False = unlock, and other passed vars
    ' Posted in the Newsgroups by Dirk Goldgar Access MVP 2005. Modified.

    On Error GoTo Err_fncLockUnlockControls
    Const conERR_NO_PROPERTY = 438

    Dim ctl As Control
    
    Dim excludeArray As Variant
    Dim field As Variant
    
    'excludeArray = "dob"
    'Dim i As String

    For Each ctl In frm.Controls
       
       'If Not ctl = "genie_id" Then
       
            With ctl
                If Left(.ControlSource & "=", 1) <> "=" Then
                    .Locked = lockIt
                    .enabled = enabled
                    .BackColor = colourFields
                End If
            End With
        'End If
        
Skip_Control:     ' Come here from error if no .ControlSource property
    Next ctl
    
Exit_fncLockUnlockControls:
     Exit Function

Err_fncLockUnlockControls:
     If Err.Number = conERR_NO_PROPERTY Then
         Resume Skip_Control
     Else
         MsgBox "Error " & Err.Number & ": " & Err.Description
         Resume Exit_fncLockUnlockControls
End If

End Function

