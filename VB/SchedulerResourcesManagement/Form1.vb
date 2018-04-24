' Developer Express Code Central Example:
' How to manage scheduler resources at runtime
' 
' This example shows how you can manage scheduler resources at runtime. The
' Scheduler context menu is modified to include commands to create, modify or
' delete selected resource. To invoke the menu, right-click any region of
' SchedulerControl (except appointments). A custom form is invoked that enables
' you to set caption, color and image for the selected resource.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3201

Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Namespace SchedulerResourcesManagement
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            ' TODO: This line of code loads data into the 'carsDBDataSet.Cars' table. You can move, or remove it, as needed.

            ' TODO: This line of code loads data into the 'carsDBDataSet.CarScheduling' table. You can move, or remove it, as needed.
            carSchedulingTableAdapter.Fill(carsDBDataSet_Renamed.CarScheduling)
            carsTableAdapter.Fill(carsDBDataSet_Renamed.Cars)

            schedulerControl1.OptionsView.ResourceHeaders.RotateCaption = False
            schedulerControl1.OptionsBehavior.SelectOnRightClick = True

            If schedulerStorage1.Appointments.Count > 0 Then
                schedulerControl1.Start = schedulerStorage1.Appointments(0).Start
            End If
        End Sub

        #Region "Data-Related Events"

        Private Sub Appointments_Modified(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs) Handles schedulerStorage1.AppointmentsInserted, schedulerStorage1.AppointmentsChanged, schedulerStorage1.AppointmentsDeleted
            carSchedulingTableAdapter.Update(carsDBDataSet_Renamed)
            carsDBDataSet_Renamed.AcceptChanges()
        End Sub

        Private Sub Resources_Modified(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs) Handles schedulerStorage1.ResourcesInserted, schedulerStorage1.ResourcesChanged, schedulerStorage1.ResourcesDeleted
            carsTableAdapter.Update(carsDBDataSet_Renamed)
            carsDBDataSet_Renamed.AcceptChanges()
        End Sub



        #End Region ' Data-Related Events

        Private Sub schedulerControl1_PopupMenuShowing(ByVal sender As Object, ByVal e As PopupMenuShowingEventArgs) Handles schedulerControl1.PopupMenuShowing
            If e.Menu.Id = DevExpress.XtraScheduler.SchedulerMenuItemId.DefaultMenu Then
                Dim itemNewResource As New SchedulerMenuItem("New Resource", AddressOf OnAddResource)
                Dim itemEditResource As New SchedulerMenuItem("Edit Resource", AddressOf OnEditResource)
                Dim itemDeleteResource As New SchedulerMenuItem("Delete Resource", AddressOf OnDeleteResource)
                Dim baseIndex As Integer = 4

                itemNewResource.BeginGroup = True
                e.Menu.Items.Insert(baseIndex, itemNewResource)
                e.Menu.Items.Insert(baseIndex + 1, itemEditResource)
                e.Menu.Items.Insert(baseIndex + 2, itemDeleteResource)
            End If
        End Sub

        Private Sub OnAddResource(ByVal sender As Object, ByVal e As EventArgs)
            Dim resource As Resource = schedulerStorage1.CreateResource(-1)

            Using form As New ResourceForm(resource, schedulerStorage1)
                If form.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
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

            Using form As New ResourceForm(resource, Me.schedulerStorage1)
                form.ShowDialog(Me)
            End Using
        End Sub

        Private Sub OnDeleteResource(ByVal sender As Object, ByVal e As EventArgs)
            Dim found As Appointment = schedulerStorage1.Appointments.Items.Find(AddressOf IsAssignedToCurrentResource)

            If found Is Nothing Then
                schedulerControl1.SelectedResource.Delete()
            Else
                MessageBox.Show("Cannot delete resource: it has appointments assigned to it.", "Message")
            End If
        End Sub

        Private Function IsAssignedToCurrentResource(ByVal apt As Appointment) As Boolean
            Return (Object.Equals(apt.ResourceId, ResourceEmpty.Id) OrElse Convert.ToInt32(apt.ResourceId) = Convert.ToInt32(schedulerControl1.SelectedResource.Id))
        End Function

        Private Sub ScrollToLastResource()
            schedulerControl1.ActiveView.FirstVisibleResourceIndex = Math.Max(0, schedulerStorage1.Resources.Count - schedulerControl1.ActiveView.ResourcesPerPage)
            schedulerControl1.Services.Selection.SelectedResource = schedulerStorage1.Resources(schedulerStorage1.Resources.Count - 1)
        End Sub
    End Class
End Namespace