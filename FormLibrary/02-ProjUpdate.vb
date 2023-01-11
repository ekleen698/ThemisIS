Imports ClassLibrary
Imports ClassLibrary.GlobalObjects
Imports System.ComponentModel
Imports System.IO
Imports System.Windows.Forms
'Imports System.Data.SqlClient

Public Class frmProjUpdate
    ' Disable Close button
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.ClassStyle = param.ClassStyle Or &H200
            Return param
        End Get
    End Property

    Private _sMode As String = ""   'either "Create" or "Edit"
    Private _oProject As Project = Nothing  'Project object affected by this form
    Private _dirty As Boolean = False   'indicates whether or not changes have been made
    ' Test

    Public Sub New(Optional ByRef Project As Project = Nothing)
        'Throws exception

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'If no Project is passed to the form open in "Create" mode, otherwise open in "Edit"
        'mode for the passed Project
        If IsNothing(Project) Then
            _sMode = "Create"
        Else
            _sMode = "Edit"
            _oProject = Project
        End If

    End Sub

    Private Sub frmProjUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Initialize form settings on load

        ' Form properties
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size

        If _sMode = "Create" Then
            'Add new project to directory
            Me.Text = $"Create New Project"
            Me.txtCreatedOn.Text = Today.ToString("d")
            Me.txtVersion.Text = Application.ProductVersion
            Me.lblID.Visible = False
            Me.txtID.Visible = False
            Me.cmdSubmit.Text = "Create"

        ElseIf _sMode = "Edit" Then
            'Edit existing project
            Me.Text = $"Edit Existing Project"
            Me.txtName.Text = _oProject.Name
            Me.txtOwner.Text = _oProject.Owner
            Me.txtDistrict.Text = _oProject.District
            Me.txtDescription.Text = _oProject.Description
            Me.txtID.Text = _oProject.ID.ToString
            Me.txtCreatedOn.Text = _oProject.CreatedOn.ToString("d")
            Me.txtVersion.Text = _oProject.ApplicationVersion
            Me.cmdSubmit.Text = "Update"
            Me.cmdSubmit.Enabled = False

        End If

        _dirty = False

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        'Close form without executing INSERT/UPDATE, confirm action if form is dirty

        If _dirty Then
            If MsgBox("Close without saving changes?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question,
                      "Confirm Exit") <> MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If

        Me.Close()

    End Sub

    Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
        'Execute operation to CREATE/UPDATE project

        Try
            'Validation requires that Project Name and Owner fields are not empty
            If fValidate() Then

                Cursor.Current = Cursors.WaitCursor

                If _sMode = "Create" Then
                    'Create new Project and Project Database
                    Logger.WriteToLog($"***Begin New Project Database Setup***")

                    'Insert row in project directory table 
                    _oProject = CurrDirectory.AddProject(
                        Me.txtName.Text,
                        Me.txtOwner.Text,
                        Me.txtDistrict.Text,
                        Me.txtDescription.Text,
                        Application.ProductVersion,
                        WithDB:=True)

                    If IsNothing(_oProject) Then
                        Logger.WriteToLog($"Error: Empty Project object returned by AddProject().")
                        Throw New Exception("CurrDirectory.AddProject() Error")
                    Else
                        ' Set 'Curr' objects so the Project Details form can be opened
                        CurrProject = _oProject
                        CurrProjDB = New ProjectDB(CurrProject.DatabaseName)
                        Logger.WriteToLog($"***End New Project Database Setup***")
                    End If

                ElseIf _sMode = "Edit" Then
                    'Update project information in project directory table
                    CurrDirectory.UpdateProject(_oProject, Me.txtName.Text, Me.txtOwner.Text,
                        Me.txtDistrict.Text, Me.txtDescription.Text)
                    Logger.WriteToLog($"***Project {_oProject.ID} Details Updated***")

                End If

                Me.Close()

            End If

        Catch ex As Exception
            MsgBox($"{DateTime.Now} > {ex.GetType}", , "Create Project Error")
            Logger.WriteToLog($"[{ex.GetType}] in Project Update form {_sMode} mode.")
            Logger.WriteToLog(ex.ToString)

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        'If text entered into textbox, set form Dirty property and show Submit button

        _dirty = True
        Me.cmdSubmit.Enabled = True
    End Sub

    Private Sub txtOwner_TextChanged(sender As Object, e As EventArgs) Handles txtOwner.TextChanged
        'If text entered into textbox, set form Dirty property and show Submit button

        _dirty = True
        Me.cmdSubmit.Enabled = True
    End Sub

    Private Sub txtDistrict_TextChanged(sender As Object, e As EventArgs) Handles txtDistrict.TextChanged
        'If text entered into textbox, set form Dirty property and show Submit button

        _dirty = True
        Me.cmdSubmit.Enabled = True
    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged
        'If text entered into textbox, set form Dirty property and show Submit button

        _dirty = True
        Me.cmdSubmit.Enabled = True
    End Sub

    Private Function fValidate() As Boolean
        'Requires that Name and Owner fields have text in them before creating a new project
        ' or updating an existing one.

        If ((Me.txtName.Text.Length > 0) And (Me.txtOwner.Text.Length > 0)) Then
            Return True
        Else
            MsgBox("Please fill in all required fields.", MsgBoxStyle.OkOnly, "Required Information")
            Return False
        End If

    End Function

End Class