Option Compare Database

' Select database for record source of form. Defaults to Cancer table.
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

End Sub

' Dave record input
Private Sub Save_Click()

' subCancerQueryAll.SetFocus

DoCmd.RunCommand acCmdSaveRecord

Me.Refresh
subCancerQueryAll.Form.Refresh

End Sub

' Search box for the main form, searches form and subform based on database selected
Private Sub TextSearch_Change()
    
    Dim strFilter As String
    
    Me.Refresh
    
    strFilter = "surname LIKE '*" & Me.TextSearch & "*'"
    
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
