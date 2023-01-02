Imports ClassLibrary.GlobalObjects
'Imports ClassLibrary.GlobalFunctions
Imports System.Windows.Forms
'Imports System.IO
'Imports System.Data.SqlClient
'Imports System.Data.SqlTypes
Imports System.ComponentModel
'Imports Microsoft.Office.Interop

Public Class frmSearchUpdate
    Private _iEmails As Integer = 0

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmSearchUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Form properties
        Me.Text = $"Update Selected Emails"
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size

        Try
            'Get count of emails
            With CurrProjDB.Connection.CreateCommand
                .CommandText = $"SELECT COUNT(0) FROM dbo.DisplayEmailIDs;"
                _iEmails = .ExecuteScalar
            End With

            ' Form control properties
            Me.lblNumEmails.Text = $"{_iEmails} Emails Found"

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Form Open Error")

        End Try

    End Sub

    Private Sub frmSearchUpdate_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Clean up class objects

        Try
            ' some action

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Form Close Error")

        End Try

    End Sub

    Private Sub cmdProduce_Click(sender As Object, e As EventArgs) Handles cmdProduce.Click
        ' Delete existing and insert new row(s) into dbo.EmailExemptStatus and dbo.AttachExemptStatus
        '   for all emails in search criteria

        Dim sStatus As String = "Produce"

        Try
            'Get user confirmation to continue with update
            If MsgBox($"You are about to update {_iEmails} emails as '{sStatus}'." + vbCrLf + vbCrLf +
                      "If any emails or attachments are already marked, the marking will be changed.",
                      MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Confirm Update") = MsgBoxResult.Cancel Then
                Exit Sub
            End If

            ' Create parameters table
            Dim dt As New DataTable
            dt.Columns.Add("ID", GetType(Integer))
            dt.Columns.Add("Description", GetType(String))
            dt.Rows.Add({-1, "No exemptions identified."})

            With CurrProjDB.Connection.CreateCommand
                .Parameters.Add("@ID", SqlDbType.Int).Value = -1
                .Parameters.Add("@Exemptions", SqlDbType.Structured).Value = dt
                .Parameters("@Exemptions").TypeName = "TVP"

                ' Emails
                .CommandText = "EXEC dbo.fEmailExemption @ID, @Exemptions;"
                .ExecuteNonQuery()

                ' Attachments
                .CommandText = "EXEC dbo.fAttachExemption @ID, @Exemptions;"
                .ExecuteNonQuery()

            End With

            MsgBox("Update Successful",, "Update Status")
            Me.Close()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Email Status Update Error")

        End Try

    End Sub

    Private Sub cmdNonResponsive_Click(sender As Object, e As EventArgs) Handles cmdNonResponsive.Click
        ' Delete existing and insert new row(s) into dbo.EmailExemptStatus and dbo.AttachExemptStatus
        '   for all emails in search criteria

        Dim sStatus As String = "Non-Responsive"

        Try
            'Get user confirmation to continue with update
            If MsgBox($"You are about to update {_iEmails} emails as '{sStatus}'." + vbCrLf + vbCrLf +
                      "If any emails or attachments are already marked, the marking will be changed.",
                      MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Confirm Update") = MsgBoxResult.Cancel Then
                Exit Sub
            End If

            ' Create parameters table
            Dim dt As New DataTable
            dt.Columns.Add("ID", GetType(Integer))
            dt.Columns.Add("Description", GetType(String))
            dt.Rows.Add({0, "Not applicable to this matter."})

            With CurrProjDB.Connection.CreateCommand
                .Parameters.Add("@ID", SqlDbType.Int).Value = -1
                .Parameters.Add("@Exemptions", SqlDbType.Structured).Value = dt
                .Parameters("@Exemptions").TypeName = "TVP"

                ' Emails
                .CommandText = "EXEC dbo.fEmailExemption @ID, @Exemptions;"
                .ExecuteNonQuery()

                ' Attachments
                .CommandText = "EXEC dbo.fAttachExemption @ID, @Exemptions;"
                .ExecuteNonQuery()

            End With

            MsgBox("Update Successful",, "Update Status")
            Me.Close()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Email Status Update Error")

        End Try

    End Sub

    Private Sub cmdExempt_Click(sender As Object, e As EventArgs) Handles cmdExempt.Click
        ' Delete/Insert rows for all emails in DisplayEmailIDs into EmailExemptionStatus
        ' Delete/Insert rows for all and associated attachments 

        Dim sStatus As String = "Exempt"

        'Get user confirmation to continue with update
        If MsgBox($"You are about to update {_iEmails} emails as '{sStatus}'." + vbCrLf + vbCrLf +
                      "If any emails or attachments are already marked, the marking will be changed.",
                      MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Confirm Update") = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        Try
            With New frmEmailExemption("Exemption")
                .ShowDialog()
            End With

            Me.Close()

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Email Status Update Error")

        End Try

    End Sub

    Private Sub cmdRedact_Click(sender As Object, e As EventArgs) Handles cmdRedact.Click
        ' No longer used, button hidden

        'Insert rows for all emails in DisplayEmailIDs into EmailExemptionStatus

        'Try
        '    With New frmEmailExemption("Redaction")
        '        .ShowDialog()
        '    End With

        '    'MsgBox("Update Successful",, "Update Status")
        '    Me.Close()

        'Catch ex As Exception
        '    MsgBox($"{DateTime.Now} > {ex.GetType}", , "Email Status Update Error")
        '    'Logger.WriteToLog($"{ex.GetType} occurred while marking EmailID={iEmailID} as 'Exempt'.")
        '    Logger.WriteToLog(ex.ToString)

        'End Try

    End Sub

    Private Sub cmdReset_Click(sender As Object, e As EventArgs) Handles cmdReset.Click
        'Delete rows for all emails in DisplayEmailIDs from EmailExemptionStatus

        Try
            'Get user confirmation to continue with update
            If MsgBox($"You are about to update {_iEmails} emails as 'Not Reviewed'.",
                      MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Confirm Update") = MsgBoxResult.Cancel Then
                Exit Sub
            End If

            'Insert multiple rows into the email exemption status table
            With CurrProjDB.Connection.CreateCommand
                .CommandText = $"EXEC fUpdateReset;"
                .ExecuteNonQuery()
            End With

            MsgBox("Update Successful",, "Update Status")

        Catch ex As Exception
            Logger.WriteToLog(ex.ToString)
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Email Status Update Error")

        End Try

    End Sub

End Class