Option Compare Database

' Added Excel Object Library to the references. Exports query to excel and opens.
' Add current Timestamp, hardset cell to A1
Public Function fncHyperlinkMsg(filepath As String)

    Dim appExcel As Excel.Application
    Dim myWorkbook As Excel.Workbook
    Dim ws As Object
    Dim pivotTbl As Object
    
    Set appExcel = CreateObject("Excel.Application")
    Set myWorkbook = appExcel.Workbooks.Open(filepath)
    
    myWorkbook.Sheets(1).Range("A1").Value = "Version=" & Format(DateTime.Now, "dd-mm-yyyy hh:mm:ss") ' change cell value as needed
    
    intMessage = MsgBox("Do you want to open the export in Excel?" & vbCrLf & vbCrLf & _
    "Filename is:" & vbCrLf & vbCrLf & filepath, vbYesNo, "Query exported")
    
    
    ' If selected yes
    If intMessage = vbYes Then
    
        appExcel.Visible = True
        
        ' Refresh all pivots within workbook
        'For Each pivotTbl In myWorkbook.Worksheets
        '    pivotTbl.PivotCache.BackgroundQuery = True
        '    pivotTbl.RefeshTable
        'Next pivotTbl
        'myWorkbook.Close
    
        'Set appExcel = Nothing
        'Set myWorkbook = Nothing
        
    Else
        appExcel.Visible = False
    End If
    
End Function


