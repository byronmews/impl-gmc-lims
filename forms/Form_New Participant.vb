
Option Compare Database

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
    SQL = "SELECT * FROM CANCER INNER JOIN DEMOGRAPHICS ON CANCER.nhs_number = DEMOGRAPHICS.nhs_number;"

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
        DoCmd.OpenForm "subCancerQueryAll", , , " [genie_id] LIKE '*" & Me.TextSearch & "*' OR [surname] LIKE '*" & Me.TextSearch.Value & "*'"
        
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
        DoCmd.OpenForm "subHaemQueryAll", , , " [genie_id] LIKE '*" & Me.TextSearch & "*' OR [surname] LIKE '*" & Me.TextSearch.Value & "*'"
    
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
        DoCmd.OpenForm "subRDQueryAll", , , " [genie_id] LIKE '*" & Me.TextSearch & "*' OR [surname] LIKE '*" & Me.TextSearch.Value & "*'"
    
    End If
    
End Sub

' Save entry into main Particiapnts form. Once core data entered prevent change to values.
Private Sub Save_Click()

    ' Enforce minimal data input for new record. If false then popup box msg.
    If IsNull(first_name) Then
        MsgBox "Enter first_name"
        Cancel = True
    ElseIf IsNull(surname) Then
        MsgBox "Enter surname"
        Cancel = True
    ElseIf IsNull(nhs_number) Then
        MsgBox "Enter NHS number"
        Cancel = True
    ElseIf IsNull(dob) Then
        MsgBox "Enter dob"
        Cancel = True
    ElseIf IsNull(gender) Then
        MsgBox "Enter gender"
        Cancel = True
    ElseIf IsNull(status_consent_date) Then
        MsgBox "Enter status_consent_date"
        Cancel = True
    ElseIf IsNull(disease_type) Then
        MsgBox "Enter Disease Type"
        Cancel = True
    Else
    
        On Error GoTo ErrHandler
        
           ' Save record. Catch duplicate nhs_number error
           DoCmd.RunCommand acCmdSaveRecord
           
            ' Set form to locked fields
            Me.LockRadioButton.Value = 1
            fncLockUnlockControls Me, True, False, RGB(225, 225, 225) 'Locked
            fncLockUnlockControls Me!subCancerQueryAll.Form, True, False, RGB(225, 225, 225) 'Locked

            ' Refresh table
            Me.Refresh
    
            ' Enable filter textbox after new record input saved.
            Me.LabelTextSearch.Visible = True
            Me.TextSearch.Visible = True
            Me.ClearTextSearch.Visible = True
            
        End If
        
    Exit Sub
    
ErrHandler:
   'Check for duplicate key error
   If Err.Number = 3022 Then
      MsgBox "Participant already in database."
      'Resume
   Else
      'Eser some info on other errors found
      MsgBox "Error when saving (Error #" & Err.Number & "). " & _
      Err.Description
   End If
    
End Sub



' Search box for the Participant form. Searches form and subforms based on tables selected from SQL combobox.
Private Sub TextSearch_Change()
    
    Dim strFilter As String
    Me.Refresh
    
    ' Hide sample number box, as filtering will reduce value - not useful.
    Me.TextBoxRecordCount.Visible = False
    
    ' 3 conditions - gene_id, surname, nhs_number
    strFilter = "[genie_id] LIKE '*" & Me.TextSearch & "*' OR [surname] LIKE '" & Me.TextSearch & "*' OR [demographics.nhs_number] LIKE '*" & Me.TextSearch & "*'  "

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


