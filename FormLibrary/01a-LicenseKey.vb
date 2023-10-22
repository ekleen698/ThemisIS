Imports ClassLibrary.GlobalObjects
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frmLicenseKey

    Public ReadOnly Property Result As Integer = 0  '-1=Cancel, 0=Fail, 1=Pass
    Public ReadOnly Property LicenseKey As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


    End Sub

    Private Sub frmExport_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Initialize form properties
        Me.cmdLocation.Visible = False
        Me.cmdSize.Visible = False

        ' Set initial Root path to Desktop
        Me.txtKey.Text = ""

    End Sub

    Private Sub cmdContinue_Click(sender As Object, e As EventArgs) Handles cmdContinue.Click
        ' Validate key then set Pass result and validated key and then close form

        ' validate key
        Try
            If CurrDirectory.ValidateLicenseKey(Me.txtKey.Text) Then
                _Result = 1
                _LicenseKey = Me.txtKey.Text
                Me.Close()
            Else
                MsgBox("The key could not be validated.", vbOKOnly + vbCritical, "Key Validation")
                Me.txtKey.Text = ""
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try


    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        ' Set Cancel result and close form

        _Result = -1
        Me.Close()

    End Sub

    Private Sub cmdLocation_Click(sender As Object, e As EventArgs) Handles cmdLocation.Click
        ' Hidden button

        MsgBox(Me.Location.ToString)
    End Sub

    Private Sub cmdSize_Click(sender As Object, e As EventArgs) Handles cmdSize.Click
        ' Hidden button

        MsgBox(Me.Size.ToString)
    End Sub


End Class