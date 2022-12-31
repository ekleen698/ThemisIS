Public Class frmInput

    Private _Title As String
    Private _Prompt As String
    Private _Comment As String = ""
    Public ReadOnly Property Comment As String
        Get
            Return _Comment
        End Get
    End Property

    Public Sub New(Title As String, Prompt As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _Title = Title
        _Prompt = Prompt

    End Sub

    Private Sub frmInput_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Text = _Title
        Me.lblPrompt.Text = _Prompt

    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click

        _Comment = Me.txtComment.Text
#Disable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
        Me.DialogResult = DialogResult.OK
#Enable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

#Disable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
        Me.DialogResult = DialogResult.Cancel
#Enable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance

    End Sub

End Class