﻿Option Compare Database

Private Sub ComboDiseaseType_Click()
    If ComboDiseaseType.Value = "Cancer" Then
        TabMain.Pages.Item(0).Visible = True
        TabMain.Pages.Item(1).Visible = False
        TabMain.Pages.Item(2).Visible = False
        
        SQL = "SELECT DEMOGRAPHICS.first_name, DEMOGRAPHICS.surname, DEMOGRAPHICS.dob, DEMOGRAPHICS.nhs_number, DEMOGRAPHICS.gender FROM CANCER INNER JOIN DEMOGRAPHICS ON CANCER.nhs_number = DEMOGRAPHICS.nhs_number;"
        
        Form.RecordSource = SQL
        
    
    ElseIf ComboDiseaseType.Value = "Haem Oncology" Then
        TabMain.Pages.Item(0).Visible = False
        TabMain.Pages.Item(1).Visible = True
        TabMain.Pages.Item(2).Visible = False
        
        SQL = "SELECT DEMOGRAPHICS.first_name, DEMOGRAPHICS.surname, DEMOGRAPHICS.dob, DEMOGRAPHICS.nhs_number, DEMOGRAPHICS.gender FROM HAEM INNER JOIN DEMOGRAPHICS ON HAEM.nhs_number = DEMOGRAPHICS.nhs_number;"
        
        Form.RecordSource = SQL
    
    
    ElseIf ComboDiseaseType.Value = "Rare Disease" Then
        TabMain.Pages.Item(0).Visible = False
        TabMain.Pages.Item(1).Visible = False
        TabMain.Pages.Item(2).Visible = True
        
        SQL = "SELECT DEMOGRAPHICS.first_name, DEMOGRAPHICS.surname, DEMOGRAPHICS.dob, DEMOGRAPHICS.nhs_number, DEMOGRAPHICS.gender FROM RD INNER JOIN DEMOGRAPHICS ON RD.nhs_number = DEMOGRAPHICS.nhs_number;"
        
        Form.RecordSource = SQL
        
        
    End If
    
End Sub