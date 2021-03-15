Public Class frmRegionalSales
    'initializing an array of sales
    Dim arrSales(,) As Integer = {{120000, 90000, 65000},
                                  {190000, 85000, 64000},
                                  {175000, 80000, 71000},
                                  {188000, 83000, 67000},
                                  {125000, 87000, 65000},
                                  {163000, 80000, 64000}}

    Dim row As String
    Dim kznPercentange As Double
    Dim gpPercentange As Double
    Dim wcPercentange As Double
    Dim TotalSales, kznTotalSales, gpTotalSales, wcTotalSales As Integer

    Private Sub CalculateAndOutput()
        'display header
        lstDisplay.Items.Add("Month" & vbTab & "Kwazulu-Natal Sales" & vbTab &
                           "Gauteng Sales" & vbTab & "Western Cape Sales")

        'display array list
        For i = 0 To 5
            row = ""
            For j = 0 To 2
                '  "C0" is the currency specifier without decimals
                row = row & vbTab & arrSales(i, j).ToString("C0") & vbTab

                'get total sales
                TotalSales = TotalSales + arrSales(i, j)
            Next

            'print results in the listbox
            lstDisplay.Items.Add(i + 1 & row)
        Next

        'Get Kwazulu-Natal total sales
        For i = 0 To 5
            For j = 0 To 0
                kznTotalSales = kznTotalSales + arrSales(i, j)
            Next
        Next

        'Get Gauteng total sales
        For i = 0 To 5
            For j = 1 To 1
                gpTotalSales = gpTotalSales + arrSales(i, j)
            Next
        Next

        'Get Western Cape total sales
        For i = 0 To 5
            For j = 2 To 2
                wcTotalSales = wcTotalSales + arrSales(i, j)
            Next
        Next

        'Get percentages value in decimals without multiplying with 100
        kznPercentange = (kznTotalSales / TotalSales)
        gpPercentange = (gpTotalSales / TotalSales)
        wcPercentange = (wcTotalSales / TotalSales)

        'Display Total sales
        lstDisplay.Items.Add("") 'skip a line
        lstDisplay.Items.Add("Total Sales = " & TotalSales.ToString("C0"))

        'Display percentages
        lstDisplay.Items.Add("") 'skip a line
        lstDisplay.Items.Add(vbTab & "Percentages")

        '"P0" is the percent  format specifier without decimals
        lstDisplay.Items.Add("Kwazulu-Natal sales percentage" & vbTab & "= " & kznPercentange.ToString("P0"))
        lstDisplay.Items.Add("Gauteng sales percentage" & vbTab & vbTab & "= " & gpPercentange.ToString("P0"))
        lstDisplay.Items.Add("Westen Cape sales percentage" & vbTab & vbTab & "= " & wcPercentange.ToString("P0"))
        lstDisplay.Items.Add(vbTab & vbTab & vbTab & "* * * END * * *")
    End Sub

    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
        CalculateAndOutput()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'clears the screen
        lstDisplay.Items.Clear()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Close the windows form
        Dim ExitYN As System.Windows.Forms.DialogResult
        ExitYN = MsgBox("Do you really want to exit?", MsgBoxStyle.YesNo)

        If ExitYN = MsgBoxResult.Yes Then
            Application.ExitThread()
        End If
    End Sub


    Private Sub frmRegionalSales_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'close the form using (x) button
        Dim dialog As System.Windows.Forms.DialogResult
        dialog = MsgBox("Do you really want to close?", MsgBoxStyle.YesNo)

        If dialog = MsgBoxResult.No Then
            e.Cancel = True
        Else
            Application.ExitThread()
        End If
    End Sub
End Class
