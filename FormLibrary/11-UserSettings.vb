Imports System.Windows.Forms

Public Class frmUserSettings

    Private _oSettings = New ClassLibrary.My.MySettings
    Private _Dirty As Boolean = False

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub frmUserSettings_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Form properties
        Me.ControlBox = False
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size

        ' Form control properties
        Me.PropertyGrid1.SelectedObject = _oSettings
        Me.PropertyGrid1.PropertySort = PropertySort.Alphabetical

    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        ' If changes made, confirm save, then close

        If _Dirty AndAlso
            MsgBox($"Save Changes to User Settings?", vbYesNo + vbQuestion, "Confirm Change") = MsgBoxResult.Yes Then
            _oSettings.Save()
        End If

        Me.Close()

    End Sub

    Private Sub PropertyGrid1_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PropertyGrid1.PropertyValueChanged
        ' When property values changes, confirm change with user.

        If e.ChangedItem.Value.ToString <> e.OldValue.ToString Then _Dirty = True

    End Sub

End Class