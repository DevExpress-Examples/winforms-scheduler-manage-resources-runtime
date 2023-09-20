Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Namespace SchedulerResourcesManagement

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' TODO: This line of code loads data into the 'carsDBDataSet.Cars' table. You can move, or remove it, as needed.
            carsTableAdapter.Fill(carsDBDataSet.Cars)
            ' TODO: This line of code loads data into the 'carsDBDataSet.CarScheduling' table. You can move, or remove it, as needed.
            carSchedulingTableAdapter.Fill(carsDBDataSet.CarScheduling)
            AddHandler carSchedulingTableAdapter.Adapter.RowUpdated, New OleDbRowUpdatedEventHandler(AddressOf carSchedulingTableAdapter_RowUpdated)
            AddHandler carsTableAdapter.Adapter.RowUpdated, New OleDbRowUpdatedEventHandler(AddressOf carsTableAdapter_RowUpdated)
            schedulerControl1.OptionsView.ResourceHeaders.RotateCaption = False
            schedulerControl1.OptionsBehavior.SelectOnRightClick = True
            If schedulerStorage1.Appointments.Count > 0 Then schedulerControl1.Start = schedulerStorage1.Appointments(0).Start
        End Sub

'#Region "Data-Related Events"
        Private Sub Appointments_Modified(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            carSchedulingTableAdapter.Update(carsDBDataSet)
        End Sub

        Private Sub Resources_Modified(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            carsTableAdapter.Update(carsDBDataSet)
        End Sub

        Private Sub carSchedulingTableAdapter_RowUpdated(ByVal sender As Object, ByVal e As OleDbRowUpdatedEventArgs)
            If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
                Dim id As Integer = 0
                Using cmd As OleDbCommand = New OleDbCommand("SELECT @@IDENTITY", carSchedulingTableAdapter.Connection)
                    id = CInt(cmd.ExecuteScalar())
                End Using

                e.Row("ID") = id
            End If
        End Sub

        Private Sub carsTableAdapter_RowUpdated(ByVal sender As Object, ByVal e As OleDbRowUpdatedEventArgs)
            If e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert Then
                Dim id As Integer = 0
                Using cmd As OleDbCommand = New OleDbCommand("SELECT @@IDENTITY", carsTableAdapter.Connection)
                    id = CInt(cmd.ExecuteScalar())
                End Using

                e.Row("ID") = id
            End If
        End Sub

'#End Region  ' Data-Related Events
        Private Sub schedulerControl1_PopupMenuShowing(ByVal sender As Object, ByVal e As PopupMenuShowingEventArgs)
            If e.Menu.Id = SchedulerMenuItemId.DefaultMenu Then
                Dim itemNewResource As SchedulerMenuItem = New SchedulerMenuItem("New Resource", AddressOf OnAddResource)
                Dim itemEditResource As SchedulerMenuItem = New SchedulerMenuItem("Edit Resource", AddressOf OnEditResource)
                Dim itemDeleteResource As SchedulerMenuItem = New SchedulerMenuItem("Delete Resource", AddressOf OnDeleteResource)
                Dim baseIndex As Integer = 4
                itemNewResource.BeginGroup = True
                e.Menu.Items.Insert(baseIndex, itemNewResource)
                e.Menu.Items.Insert(baseIndex + 1, itemEditResource)
                e.Menu.Items.Insert(baseIndex + 2, itemDeleteResource)
            End If
        End Sub

        Private Sub OnAddResource(ByVal sender As Object, ByVal e As EventArgs)
            Dim resource As Resource = schedulerStorage1.CreateResource(-1)
            Using form As ResourceForm = New ResourceForm(resource)
                If form.ShowDialog(Me) = DialogResult.OK Then
                    schedulerStorage1.Resources.Add(resource)
                    schedulerStorage1.RefreshData()
                    ScrollToLastResource()
                Else
                    resource.Dispose()
                End If
            End Using
        End Sub

        Private Sub OnEditResource(ByVal sender As Object, ByVal e As EventArgs)
            Dim resource As Resource = schedulerControl1.SelectedResource
            Using form As ResourceForm = New ResourceForm(resource)
                form.ShowDialog(Me)
            End Using
        End Sub

        Private Sub OnDeleteResource(ByVal sender As Object, ByVal e As EventArgs)
            Dim found As Appointment = schedulerStorage1.Appointments.Items.Find(New Predicate(Of Appointment)(AddressOf IsAssignedToCurrentResource))
            If found Is Nothing Then
                schedulerControl1.SelectedResource.Delete()
            Else
                MessageBox.Show("Cannot delete resource: it has appointments assigned to it.", "Message")
            End If
        End Sub

        Private Function IsAssignedToCurrentResource(ByVal apt As Appointment) As Boolean
            Return apt.ResourceId Is Resource.Empty OrElse Convert.ToInt32(apt.ResourceId) = Convert.ToInt32(schedulerControl1.SelectedResource.Id)
        End Function

        Private Sub ScrollToLastResource()
            schedulerControl1.ActiveView.FirstVisibleResourceIndex = Math.Max(0, schedulerStorage1.Resources.Count - schedulerControl1.ActiveView.ResourcesPerPage)
            schedulerControl1.Services.Selection.SelectedResource = schedulerStorage1.Resources(schedulerStorage1.Resources.Count - 1)
        End Sub
    End Class
End Namespace
