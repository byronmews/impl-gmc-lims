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
