
Option Compare Database

' Select database for record source of main form and subform. Defaults to cancer table, hide all other disease TabMain pages.
Private Sub ComboDiseaseType_Click()

    If ComboDiseaseType.Value = "Cancer" Then
        TabMain.Pages.Item(0).Visible = True
        TabMain.Pages.Item(1).Visible = False
        TabMain.Pages.Item(2).Visible = False
        
        ' Join demographics and cancer tables
        SQL = "SELECT * FROM CANCER INNER JOIN DEMOGRAPHICS ON CANCER.nhs_number = DEMOGRAPHICS.nhs_number;"

        ' Change main form and subform to disease specific records
        Form.RecordSource = SQL
        subCancerQueryAll.Form.RecordSource = SQL
        
        ' Change main form to new record input
        DoCmd.GoToRecord , , acNewRec
        
        ' Change disease_type combobox to cancer specific values
        disease_type.RowSource = "Breast, Ovarian, Prostate, Lung, Colorectal, Sarcoma, Renal," & _
                                    "Brain, Bladder, Endometrial, Testicular, GI, Pancreas"
        
    ElseIf ComboDiseaseType.Value = "Haem Oncology" Then
        
        TabMain.Pages.Item(0).Visible = False
        TabMain.Pages.Item(1).Visible = True
        TabMain.Pages.Item(2).Visible = False
        
        SQL = "SELECT * FROM HAEM INNER JOIN DEMOGRAPHICS ON HAEM.nhs_number = DEMOGRAPHICS.nhs_number;"

        ' Change main form and subform to disease specific records
        Form.RecordSource = SQL
        subHaemQueryAll.Form.RecordSource = SQL
        
        DoCmd.GoToRecord , , acNewRec
        
        ' Change disease_type combobox to cancer specific values
        disease_type.RowSource = "AML, ALL, CML, CLL, Other"
                
    ElseIf ComboDiseaseType.Value = "Rare Disease" Then
        
        TabMain.Pages.Item(0).Visible = False
        TabMain.Pages.Item(1).Visible = False
        TabMain.Pages.Item(2).Visible = True
        
        SQL = "SELECT * FROM RD INNER JOIN DEMOGRAPHICS ON RD.nhs_number = DEMOGRAPHICS.nhs_number;"
        
        ' Change main form and subform to disease specific records
        Form.RecordSource = SQL
        subRDQueryAll.Form.RecordSource = SQL
        
        DoCmd.GoToRecord , , acNewRec
        
        ' Change disease_type combobox to RD specific values
        disease_type.RowSource = "Cardiovascular disorders, Dermatological disorders," & _
                                    "Dysmorphic & congenital abnormality syn, Endocrine," & _
                                    "Growth disorders, Haematological disorders, Hearing & ear disorders," & _
                                    "Metabolic, Neurology & neurodevelopmental," & _
                                    "Ophthalmological, Renal and urinary tract, Respiratory disorders," & _
                                    "Skeletal, Rheumatological and connective tissue, Tumour predisposition syn, Ultrarare," & _
                                    "Unknown at sample receipt"
                                    
    End If
    
End Sub


' New record. Main form defaults to cancer table join
Private Sub NewRecord_Click()

    ' Me!subCancerQueryAll.SetFocus
    DoCmd.GoToRecord , , acNewRec
    
    ' When new participant is being entered, hide subform filter box until record is saved
    Me.BoxSearch.Visible = False
    Me.LabelTextSearch.Visible = False
    Me.TextSearch.Visible = False
    Me.ClearTextSearch.Visible = False

End Sub


' Open Cancer using SubFormButton, filter using logic from TextSearch values.
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


' Open HaemOnc using SubFormButton, filter using logic from TextSearch values.
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


' Open RD using SubFormButton, filter using logic from TextSearch values.
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


' Save record input button
Private Sub Save_Click()

    ' Enforce required inputs are entered, if false then oppup box msg. Else continue the save form process.
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
       ' Save record
        DoCmd.RunCommand acCmdSaveRecord

        ' Refresh all tables
        Me.Refresh
        subCancerQueryAll.Form.Refresh

        ' Enable filter textbox after new record input saved
        Me.BoxSearch.Visible = True
        Me.LabelTextSearch.Visible = True
        Me.TextSearch.Visible = True
        Me.ClearTextSearch.Visible = True
    End If
    
End Sub



' Search box for the main form, searches form and subform based on database selected
Private Sub TextSearch_Change()
    
    Dim strFilter As String
    Me.Refresh
    Me.TextBoxRecordCount.Visible = False
    
    ' 2 conditions - gene_id_ & surname
    strFilter = "[genie_id] LIKE '*" & Me.TextSearch & "*' OR [surname] LIKE '*" & Me.TextSearch & "*' "
    
    If ComboDiseaseType.Value = "Cancer" Then
    
        subCancerQueryAll.Form.filter = strFilter
        subCancerQueryAll.Form.FilterOn = True
        
        Form.filter = strFilter
        Form.FilterOn = True
        
        Me.TextSearch.SelStart = Nz(Len(Me.TextSearch), 0)
        
    ElseIf ComboDiseaseType.Value = "Haem Oncology" Then
        
        subHaemQueryAll.Form.filter = strFilter
        subHaemQueryAll.Form.FilterOn = True
        
        Form.filter = strFilter
        Form.FilterOn = True
        
        Me.TextSearch.SelStart = Nz(Len(Me.TextSearch), 0)
        
    ElseIf ComboDiseaseType.Value = "Rare Disease" Then
        
        subRDQueryAll.Form.filter = strFilter
        subRDQueryAll.Form.FilterOn = True
        
        Form.filter = strFilter
        Form.FilterOn = True
        
        Me.TextSearch.SelStart = Nz(Len(Me.TextSearch), 0)
        
    End If

End Sub


' Clear TextSearch value, remove filter, make sample count box visible
Private Sub ClearTextSearch_Click()

    Me.TextSearch.Value = ""
    Form.FilterOn = False
    Me.TextBoxRecordCount.Visible = True

End Sub



