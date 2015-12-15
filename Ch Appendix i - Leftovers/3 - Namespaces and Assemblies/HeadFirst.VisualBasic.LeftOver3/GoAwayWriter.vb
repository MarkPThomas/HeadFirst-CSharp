Option Strict On
Option Explicit On

Imports System.Windows.Forms

Public Class GoAwayWriter

    Public Shared Sub GoAway(ByVal name As String)
        MessageBox.Show("Leave me alone {0}! ", name)
    End Sub
End Class
