Option Compare Database


' Select database for record source of form. Defaults to Cancer table with all other TabMain pages not visible.
Private Sub ComboDiseaseType_Click()

    If ComboDiseaseType.Value = "Cancer" Then
        TabMain.Pages.Item(0).Visible = True
        TabMain.Pages.Item(1).Visible = False
        TabMain.Pages.Item(2).Visible = False
        
        SQL = "SELECT * FROM CANCER INNER JOIN DEMOGRAPHICS ON CANCER.nhs_number = DEMOGRAPHICS.nhs_number;"

        Form.RecordSource = SQL
        subCancerQueryAll.Form.RecordSource = SQL
        
        DoCmd.GoToRecord , , acNewRec
        
        
    ElseIf ComboDiseaseType.Value = "Haem Oncology" Then
        
        TabMain.Pages.Item(0).Visible = False
        TabMain.Pages.Item(1).Visible = True
        TabMain.Pages.Item(2).Visible = False
        
        SQL = "SELECT * FROM HAEM INNER JOIN DEMOGRAPHICS ON HAEM.nhs_number = DEMOGRAPHICS.nhs_number;"

        Form.RecordSource = SQL
        subHaemQueryAll.Form.RecordSource = SQL
        
        DoCmd.GoToRecord , , acNewRec
        
                
    ElseIf ComboDiseaseType.Value = "Rare Disease" Then
        
        TabMain.Pages.Item(0).Visible = False
        TabMain.Pages.Item(1).Visible = False
        TabMain.Pages.Item(2).Visible = True
        
        SQL = "SELECT * FROM RD INNER JOIN DEMOGRAPHICS ON RD.nhs_number = DEMOGRAPHICS.nhs_number;"
        
        Form.RecordSource = SQL
        subRDQueryAll.Form.RecordSource = SQL
        
        DoCmd.GoToRecord , , acNewRec
        
    End If
        
End Sub

' New record. Form defaults to Cancer table, select if new cancer record needed.
Private Sub NewRecord_Click()

    ' Me!subCancerQueryAll.SetFocus
    DoCmd.GoToRecord , , acNewRec
    
    Me.BoxSearch.Visible = False
    Me.LabelTextSearch.Visible = False
    Me.TextSearch.Visible = False

End Sub

' Save record input
Private Sub Save_Click()

    DoCmd.RunCommand acCmdSaveRecord

    ' Refresh all tables
    Me.Refresh
    subCancerQueryAll.Form.Refresh

    ' Enable search box again after new record input saved
    Me.BoxSearch.Visible = True
    Me.LabelTextSearch.Visible = True
    Me.TextSearch.Visible = True

End Sub


' Search box for the main form, searches form and subform based on database selected
Private Sub TextSearch_Change()
    
    Dim strFilter As String
    
    Me.Refresh
    
    ' Number of conditions
    'strFilter = "[surname] LIKE '*" & Me.TextSearch & "*'"
    strFilter = "[genie_id] LIKE '*" & Me.TextSearch & "*' OR [surname] LIKE '*" & Me.TextSearch & "*' "
    
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


' Clear TextSearch value and remove filter
Private Sub ClearTextSearch_Click()

    Me.TextSearch.Value = ""
    Form.FilterOn = False

End Sub
