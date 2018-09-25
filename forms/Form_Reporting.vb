Option Compare Database

Private Sub GeLCancer_Click()

    DoCmd.OpenQuery "GeL_NHSE_report_format_Cancer", acViewPivotTable, acEdit

End Sub


Private Sub GeLHaem_Click()

    DoCmd.OpenQuery "GeL_NHSE_report_format_Haem", acViewPivotTable, acEdit

End Sub

Private Sub GeLRD_Click()

    DoCmd.OpenQuery "GeL_NHSE_report_format_Rd", acViewPivotTable, acEdit

End Sub

Private Sub GMClabCancer_Click()

    DoCmd.OpenQuery "GMC_lab_report_format_Cancer", acViewPivotTable, acEdit

End Sub


Private Sub GMClabHaem_Click()

    DoCmd.OpenQuery "GMC_lab_report_format_Haem", acViewPivotTable, acEdit

End Sub

Private Sub GMClabRD_Click()

    DoCmd.OpenQuery "GMC_lab_report_format_RD", acViewPivotTable, acEdit

End Sub

Private Sub ReceivedByUKB_Click()

    DoCmd.OpenQuery "Q_Imperial_GOSH_UKB_time_profile", acViewPivotTable, acEdit

End Sub

Private Sub NotReceivedByUKB_Click()

    DoCmd.OpenQuery "Q_Imperial_GOSH_not_UKB_time_profile", acViewPivotTable, acEdit

End Sub

Private Sub GMClabCancerExport_Click()

    DoCmd.TransferSpreadsheet acExport, , _
      "GMC_lab_report_format_Cancer", "W:\Cellular Pathology - GMC\GMC_lab\GMC participant samples database\adhoc metrics\vba export datasets\GMC_lab_report_format_Cancer"
      
      fncHyperlinkMsg "W:\Cellular Pathology - GMC\GMC_lab\GMC participant samples database\adhoc metrics\vba export datasets\GMC_lab_report_format_Cancer.xlsx"
    
End Sub

Private Sub GMClabHaemExport_Click()

    DoCmd.TransferSpreadsheet acExport, , _
      "GMC_lab_report_format_Haem", "W:\Cellular Pathology - GMC\GMC_lab\GMC participant samples database\adhoc metrics\vba export datasets\GMC_lab_report_format_Haem"
      
      fncHyperlinkMsg "W:\Cellular Pathology - GMC\GMC_lab\GMC participant samples database\adhoc metrics\vba export datasets\GMC_lab_report_format_Haem.xlsx"
    
End Sub

Private Sub GMClabRDExport_Click()

    DoCmd.TransferSpreadsheet acExport, , _
      "GMC_lab_report_format_RD", "W:\Cellular Pathology - GMC\GMC_lab\GMC participant samples database\adhoc metrics\vba export datasets\GMC_lab_report_format_RD"
      
      fncHyperlinkMsg "W:\Cellular Pathology - GMC\GMC_lab\GMC participant samples database\adhoc metrics\vba export datasets\GMC_lab_report_format_RD.xlsx"
    
End Sub



