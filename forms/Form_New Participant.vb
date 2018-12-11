
Option Compare Database
Dim strFilter As String ' search string entry

' Enforce minimal data input for new record entry. If false then MegBox. Prevents orphan records being created.
Private Sub Form_BeforeUpdate(Cancel As Integer)

     On Error GoTo ErrHandler

        If IsNull(first_name) Then
            MsgBox "Error when saving. Enter first name", vbCritical
            Cancel = True
            Exit Sub
        ElseIf IsNull(surname) Then
            MsgBox "Error when saving. Enter surname", vbCritical
            Cancel = True
            Exit Sub
        ElseIf IsNull(nhs_number) Then
            MsgBox "Error when saving. Enter NHS number", vbCritical
            Cancel = True
            Exit Sub
        ElseIf IsNull(dob) Then
            MsgBox "Error when saving. Enter DOB", vbCritical
            Cancel = True
            Exit Sub
        ElseIf IsNull(gender) Then
            MsgBox "Error when saving. Enter gender", vbCritical
            Cancel = True
            Exit Sub
        'ElseIf IsNull(status_consent_date) Then
            'MsgBox "Error when saving. Enter Consent date", vbCritical
            'Cancel = True
            'Exit Sub
        ElseIf IsNull(disease_type) Then
            MsgBox "Error when saving. Enter Disease Type", vbCritical
            Cancel = True
            Exit Sub
            
        End If
        
    Exit Sub
        

' Handle errors
ErrHandler:
   'Check for duplicate key error
   If Err.Number = 3022 Then
      MsgBox "Participant already in database. NHS number " & Me.nhs_number.Value & " found.", vbCritical
   Else
      ' Some info on any other errors found
      MsgBox "Error when saving (Error #" & Err.Number & "). " & _
      Err.Description, vbCritical
   End If

End Sub

' Save entry into main Participants form. Once core data entered prevent change to values.
Private Sub Save_Click()

    On Error GoTo ErrHandler
        ' Save record.
        DoCmd.RunCommand acCmdSaveRecord

        
        ' Passed validation of minimal data input code block
        ' Set form to locked fields
        Me.LockRadioButton.Value = 1
        fncLockUnlockControls Me, True, False, RGB(225, 225, 225) 'Locked
        fncLockUnlockControls Me!subCancerQueryAll.Form, True, False, RGB(225, 225, 225) 'Locked
    
        ' Refresh form and subforms
        Me.Refresh
        Me.subCancerQueryAll.Form.Requery
        Me.subHaemQueryAll.Form.Requery
        Me.subRDQueryAll.Form.Requery
    
        ' Enable filter textbox after new record input saved.
        Me.LabelTextSearch.Visible = True
        Me.TextSearch.Visible = True
        Me.ClearTextSearch.Visible = True
        
        MsgBox "Saved completed successfully.", vbInformation
        
    Exit Sub
    
' Handle errors
ErrHandler:
   'Check for duplicate key error
   If Err.Number = 3022 Then
      MsgBox "Participant already in database. NHS number " & Me.nhs_number.Value & " found.", vbCritical
   Else
      ' Some info on any other errors found
      MsgBox "Error when saving (Error #" & Err.Number & "). " & _
      Err.Description
   End If
    
End Sub


Private Sub Form_Activate()

    ' Set form to locked fields
    Me.LockRadioButton.Value = 1
    fncLockUnlockControls Me, True, False, RGB(225, 225, 225) 'Locked
    fncLockUnlockControls Me!subCancerQueryAll.Form, True, False, RGB(225, 225, 225) 'Locked
    fncLockUnlockControls Me!subHaemQueryAll.Form, True, False, RGB(225, 225, 225) 'Locked
    fncLockUnlockControls Me!subRDQueryAll.Form, True, False, RGB(225, 225, 225) 'Locked

End Sub



' Lock form fields from being modified using LockRadioButton
Private Sub LockRadioButton_AfterUpdate()

    If Me.LockRadioButton.Value = 1 Then
        fncLockUnlockControls Me, True, False, RGB(225, 225, 225) 'Locked
        fncLockUnlockControls Me!subCancerQueryAll.Form, True, False, RGB(225, 225, 225) 'Locked
        fncLockUnlockControls Me!subHaemQueryAll.Form, True, False, RGB(225, 225, 225) 'Locked
        fncLockUnlockControls Me!subRDQueryAll.Form, True, False, RGB(225, 225, 225) 'Locked
    ElseIf Me.LockRadioButton.Value = 2 Then
        fncLockUnlockControls Me, False, True, RGB(255, 255, 255) 'Unlocked
        fncLockUnlockControls Me!subCancerQueryAll.Form, False, True, RGB(255, 255, 255) 'Unlocked
        fncLockUnlockControls Me!subHaemQueryAll.Form, False, True, RGB(255, 255, 255) 'Unlocked
        fncLockUnlockControls Me!subRDQueryAll.Form, False, True, RGB(255, 255, 255) 'Unlocked
    End If
    
    ' Always override unlock function for nhs_number primary key to locked
    If IsEmpty(Me.nhs_number.Value) = False Then
        Me.nhs_number.enabled = False
        Me.nhs_number.Locked = True
        Me.nhs_number.BackColor = RGB(225, 225, 225)
    ElseIf IsEmpty(Me.nhs_number.Value) = False Then
       Me!subCancerQueryAll.nhs_number.enabled = False
       Me!subCancerQueryAll.nhs_number.Locked = True
       Me!subCancerQueryAll.nhs_number.BackColor = RGB(225, 225, 225)
    ElseIf IsEmpty(Me.nhs_number.Value) = False Then
       Me!subHaemQueryAll.nhs_number.enabled = False
       Me!subHaemQueryAll.nhs_number.Locked = True
       Me!subHaemQueryAll.nhs_number.BackColor = RGB(225, 225, 225)
    ElseIf IsEmpty(Me.nhs_number.Value) = False Then
       Me!RDQueryAll.nhs_number.enabled = False
       Me!RDHaemQueryAll.nhs_number.Locked = True
       Me!RDHaemQueryAll.nhs_number.BackColor = RGB(225, 225, 225)
 
    End If
    

End Sub

' Lock nhs_number if not null, maybe not needed now?
Private Sub Form_Current()

    ' Minimal entry fields on main participants Form locks.
    If IsEmpty(Me.nhs_number.Value) = False Then
        Me.nhs_number.enabled = False
        Me.nhs_number.Locked = True
        Me.nhs_number.BackColor = RGB(225, 225, 225)
 
    End If

End Sub

' Load form. Defaults to Cancer table join. Form locked.
Private Sub Form_Load()

    TabMain.Pages.Item(0).Visible = True
    TabMain.Pages.Item(1).Visible = False
    TabMain.Pages.Item(2).Visible = False

    ' Join Demographics and Cancer tables
    SQL = "SELECT * FROM CANCER INNER JOIN DEMOGRAPHICS ON CANCER.nhs_number = DEMOGRAPHICS.nhs_number ORDER BY CANCER.status_consent_date;"

    ' Change form and subform record source to disease_type. No parent-child relationship for subtable.
    Form.RecordSource = SQL
    subCancerQueryAll.Form.RecordSource = SQL
    
    ' Form defaults to Cancer, so populate combobox with disease specific values.
    disease_type.RowSource = "Breast, Ovarian, Prostate, Lung, Colorectal, Sarcoma, Renal," & _
                                    "Adult Glioma, Bladder, Endometrial, Testicular, GI, Pancreas"
                                    
    ' Lock all fields, opt value 1 on radio button.
    Me.LockRadioButton.Value = 1
    fncLockUnlockControls Me, True, False, RGB(225, 225, 225) 'Locked
    fncLockUnlockControls Me!subCancerQueryAll.Form, True, False, RGB(225, 225, 225) 'Locked
    fncLockUnlockControls Me!subHaemQueryAll.Form, True, False, RGB(225, 225, 225) 'Locked
    fncLockUnlockControls Me!subRDQueryAll.Form, True, False, RGB(225, 225, 225) 'Locked
    
    ' Enable filter textbox by default
    Me.LabelTextSearch.Visible = True
    Me.TextSearch.Visible = True
    Me.ClearTextSearch.Visible = True
    
    ' Hide sample number box, as filtering will reduce value - not useful.
    Me.TextBoxRecordCount.Visible = True
    
    
    

End Sub



' Select table for record source of main form (demographics) and subform (disease_type).
' Defaults to Cancer table. Hide all other disease_type pages in TabMain.
Private Sub ComboDiseaseType_Click()

    If ComboDiseaseType.Value = "Cancer" Then
        TabMain.Pages.Item(0).Visible = True
        TabMain.Pages.Item(1).Visible = False
        TabMain.Pages.Item(2).Visible = False
        
        ' Join Demographics and Cancer tables
        SQL = "SELECT * FROM CANCER INNER JOIN DEMOGRAPHICS ON CANCER.nhs_number = DEMOGRAPHICS.nhs_number;"

        ' Change form and subform record source to disease_type. No parent-child relationship for subtable.
        Form.RecordSource = SQL
        subCancerQueryAll.Form.RecordSource = SQL
        
        ' Change form to new record input by default
        'DoCmd.GoToRecord , , acNewRec
        
        ' Populate disease_type combobox to Cancer specific disease values
        disease_type.RowSource = "Breast, Ovarian, Prostate, Lung, Colorectal, Sarcoma, Renal," & _
                                    "Brain, Bladder, Endometrial, Testicular, GI, Pancreas"
                                    
        
    ElseIf ComboDiseaseType.Value = "Haem Oncology" Then
        
        TabMain.Pages.Item(0).Visible = False
        TabMain.Pages.Item(1).Visible = True
        TabMain.Pages.Item(2).Visible = False
        
        SQL = "SELECT * FROM HAEM INNER JOIN DEMOGRAPHICS ON HAEM.nhs_number = DEMOGRAPHICS.nhs_number;"

        ' Change form and subform record source to disease_type. No parent-child relationship for subtable.
        Form.RecordSource = SQL
        subHaemQueryAll.Form.RecordSource = SQL
        
        'DoCmd.GoToRecord , , acNewRec
        
        ' Change disease_type combobox to HaemOnc specific values
        disease_type.RowSource = "AML, ALL, CML, CLL, Other"
                
    ElseIf ComboDiseaseType.Value = "Rare Disease" Then
        
        TabMain.Pages.Item(0).Visible = False
        TabMain.Pages.Item(1).Visible = False
        TabMain.Pages.Item(2).Visible = True
        
        SQL = "SELECT * FROM RD INNER JOIN DEMOGRAPHICS ON RD.nhs_number = DEMOGRAPHICS.nhs_number;"
        
        ' Change form and subform record source to disease_type. No parent-child relationship for subtable.
        Form.RecordSource = SQL
        subRDQueryAll.Form.RecordSource = SQL
        
        'DoCmd.GoToRecord , , acNewRec
        
        ' Change disease_type combobox to Rare Disease specific values
        disease_type.RowSource = "Cardiovascular disorders, Dermatological disorders," & _
                                    "Dysmorphic & congenital abnormality syn, Endocrine," & _
                                    "Growth disorders, Haematological disorders, Hearing & ear disorders," & _
                                    "Metabolic, Neurology & neurodevelopmental," & _
                                    "Ophthalmological, Renal and urinary tract, Respiratory disorders," & _
                                    "Skeletal, Rheumatological and connective tissue, Tumour predisposition syn, Ultrarare," & _
                                    "Unknown at sample receipt"
                                    
    End If
    
End Sub

' New record button.
Private Sub NewRecord_Click()

    DoCmd.GoToRecord , , acNewRec
    
    ' Set form to unlocked fields
    Me.LockRadioButton.Value = 2
    fncLockUnlockControls Me, False, True, RGB(255, 255, 255) 'Unlocked
    
    ' Hide search box
    Me.LabelTextSearch.Visible = False
    Me.TextSearch.Visible = False
    Me.ClearTextSearch.Visible = False
   
    
End Sub


' SubFormButton for Cancer. Filter using logic from TextSearch values. Opens on filter.
' Use no filter if null value. Filter search can be genie_id or surname.
Private Sub openSubCancerFormButton_Click()

    ' Filter subform using hardset variable, debug only
    'Dim person As String
    'person = "SPEI"
    'DoCmd.OpenForm "subCancerQueryAll", , , "surname LIKE '*" & person & "*'"
    
    If IsNull(Me.TextSearch.Value) Then
    
        ' Open subform as unfiltered
        Me.subCancerQueryAll.Form.FilterOn = False
        DoCmd.OpenForm "subCancerQueryAll"
        
    Else
        ' Filter subform using string entered into search box (can be genie_id or surname)
        'DoCmd.OpenForm "subCancerQueryAll", , , " [genie_id] LIKE '*" & Me.TextSearch & "*' OR [surname] LIKE '*" & Me.TextSearch.Value & "*' OR [demographics.nhs_number] LIKE '*" & Me.TextSearch & "*' "
        DoCmd.OpenForm "subCancerQueryAll", , , strFilter
        
    End If
    
End Sub


' SubFormButton for HameOnc. Filter using logic from TextSearch values.
' Use no filter if null value. Filter search can be genie_id or surname.
Private Sub openSubHaemFormButton_Click()
    
    If IsNull(Me.TextSearch.Value) Then
    
        ' Open subform as unfiltered
        Me.subHaemQueryAll.Form.FilterOn = False
        DoCmd.OpenForm "subHaemQueryAll"
        
    Else
    
        ' Filter subform using string entered into search box (can be genie_id or surname)
        DoCmd.OpenForm "subHaemQueryAll", , , strFilter
        
    End If
    
End Sub


' SubFormButton for RD. Filter using logic from TextSearch values.
' Use no filter if null value. Filter search can be genie_id or surname.
Private Sub openRDFormButton_Click()

    If IsNull(Me.TextSearch.Value) Then
    
        ' Open subform as unfiltered
        Me.subRDQueryAll.Form.FilterOn = False
        DoCmd.OpenForm "subRDQueryAll"
        
    Else
        
        ' Filter subform using string entered into search box (can be genie_id or surname)
        DoCmd.OpenForm "subRDQueryAll", , , strFilter
        
    End If
    
End Sub




' Search box for the Participant form. Searches form and subforms based on tables selected from SQL combobox.
Private Sub TextSearch_Change()
    
    'Dim strFilter As String
    Me.Refresh
    
    ' Hide sample number box, as filtering will reduce value - not useful.
    Me.TextBoxRecordCount.Visible = False
        
    ' 3 conditions - gene_id, surname, nhs_number. Replace string single quotes (') to doubles ('') to escape syntax error.
    strFilter = " [genie_id] LIKE '*" & Replace(Me.TextSearch, "'", "''") & "*' OR " & _
    "[surname] LIKE '*" & Replace(Me.TextSearch, "'", "''") & "*' OR " & _
    "[demographics.nhs_number] LIKE '*" & Replace(Me.TextSearch, "'", "''") & "*'  "
   
    If ComboDiseaseType.Value = "Cancer" Then
    
        subCancerQueryAll.Form.Filter = strFilter
        subCancerQueryAll.Form.FilterOn = True
        
        Form.Filter = strFilter
        Form.FilterOn = True
        
        Me.TextSearch.SelStart = Nz(Len(Me.TextSearch), 0)
        
    ElseIf ComboDiseaseType.Value = "Haem Oncology" Then
        
        subHaemQueryAll.Form.Filter = strFilter
        subHaemQueryAll.Form.FilterOn = True
        
        Form.Filter = strFilter
        Form.FilterOn = True
        
        Me.TextSearch.SelStart = Nz(Len(Me.TextSearch), 0)
        
    ElseIf ComboDiseaseType.Value = "Rare Disease" Then
        
        subRDQueryAll.Form.Filter = strFilter
        subRDQueryAll.Form.FilterOn = True
        
        Form.Filter = strFilter
        Form.FilterOn = True
        
        Me.TextSearch.SelStart = Nz(Len(Me.TextSearch), 0)
        
    End If

End Sub


' Clear TextSearch value, remove filter, make sample count box visible again.
Private Sub ClearTextSearch_Click()

    Me.TextSearch.Value = ""
    Form.FilterOn = False
    Me.TextBoxRecordCount.Visible = True

End Sub

