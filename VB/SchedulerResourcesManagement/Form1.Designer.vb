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
Namespace SchedulerResourcesManagement

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

'#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim timeRuler1 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Dim timeRuler2 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
            Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
            Me.label1 = New System.Windows.Forms.Label()
            Me.carSchedulingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.carsDBDataSet = New SchedulerResourcesManagement.CarsDBDataSet()
            Me.carsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.carSchedulingTableAdapter = New SchedulerResourcesManagement.CarsDBDataSetTableAdapters.CarSchedulingTableAdapter()
            Me.carsTableAdapter = New SchedulerResourcesManagement.CarsDBDataSetTableAdapters.CarsTableAdapter()
            CType((Me.schedulerControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.schedulerStorage1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.carSchedulingBindingSource), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.carsDBDataSet), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.carsBindingSource), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' schedulerControl1
            ' 
            Me.schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Timeline
            Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.schedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource
            Me.schedulerControl1.Location = New System.Drawing.Point(0, 36)
            Me.schedulerControl1.Name = "schedulerControl1"
            Me.schedulerControl1.OptionsView.ResourceHeaders.Height = 100
            Me.schedulerControl1.OptionsView.ResourceHeaders.ImageAlign = DevExpress.XtraScheduler.HeaderImageAlign.Top
            Me.schedulerControl1.OptionsView.ResourceHeaders.ImageSize = New System.Drawing.Size(100, 100)
            Me.schedulerControl1.OptionsView.ResourceHeaders.ImageSizeMode = DevExpress.XtraScheduler.HeaderImageSizeMode.ZoomImage
            Me.schedulerControl1.Size = New System.Drawing.Size(673, 356)
            Me.schedulerControl1.Start = New System.DateTime(2008, 10, 19, 0, 0, 0, 0)
            Me.schedulerControl1.Storage = Me.schedulerStorage1
            Me.schedulerControl1.TabIndex = 0
            Me.schedulerControl1.Text = "schedulerControl1"
            Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
            Me.schedulerControl1.Views.TimelineView.ResourcesPerPage = 3
            Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2)
            AddHandler Me.schedulerControl1.PopupMenuShowing, New DevExpress.XtraScheduler.PopupMenuShowingEventHandler(AddressOf Me.schedulerControl1_PopupMenuShowing)
            ' 
            ' schedulerStorage1
            ' 
            Me.schedulerStorage1.Appointments.DataSource = Me.carSchedulingBindingSource
            Me.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
            Me.schedulerStorage1.Appointments.Mappings.Description = "Description"
            Me.schedulerStorage1.Appointments.Mappings.[End] = "EndTime"
            Me.schedulerStorage1.Appointments.Mappings.Label = "Label"
            Me.schedulerStorage1.Appointments.Mappings.Location = "Location"
            Me.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo"
            Me.schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo"
            Me.schedulerStorage1.Appointments.Mappings.ResourceId = "CarId"
            Me.schedulerStorage1.Appointments.Mappings.Start = "StartTime"
            Me.schedulerStorage1.Appointments.Mappings.Status = "Status"
            Me.schedulerStorage1.Appointments.Mappings.Subject = "Subject"
            Me.schedulerStorage1.Appointments.Mappings.Type = "EventType"
            Me.schedulerStorage1.Resources.DataSource = Me.carsBindingSource
            Me.schedulerStorage1.Resources.Mappings.Caption = "Model"
            Me.schedulerStorage1.Resources.Mappings.Id = "ID"
            Me.schedulerStorage1.Resources.Mappings.Image = "Picture"
            AddHandler Me.schedulerStorage1.AppointmentsInserted, New DevExpress.XtraScheduler.PersistentObjectsEventHandler(AddressOf Me.Appointments_Modified)
            AddHandler Me.schedulerStorage1.AppointmentsChanged, New DevExpress.XtraScheduler.PersistentObjectsEventHandler(AddressOf Me.Appointments_Modified)
            AddHandler Me.schedulerStorage1.AppointmentsDeleted, New DevExpress.XtraScheduler.PersistentObjectsEventHandler(AddressOf Me.Appointments_Modified)
            AddHandler Me.schedulerStorage1.ResourcesInserted, New DevExpress.XtraScheduler.PersistentObjectsEventHandler(AddressOf Me.Resources_Modified)
            AddHandler Me.schedulerStorage1.ResourcesChanged, New DevExpress.XtraScheduler.PersistentObjectsEventHandler(AddressOf Me.Resources_Modified)
            AddHandler Me.schedulerStorage1.ResourcesDeleted, New DevExpress.XtraScheduler.PersistentObjectsEventHandler(AddressOf Me.Resources_Modified)
            ' 
            ' label1
            ' 
            Me.label1.Dock = System.Windows.Forms.DockStyle.Top
            Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte((204))))
            Me.label1.Location = New System.Drawing.Point(0, 0)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(673, 36)
            Me.label1.TabIndex = 1
            Me.label1.Text = "Use the Scheduler context menu to create, modify or delete resource." & Global.Microsoft.VisualBasic.Constants.vbCrLf & "To invoke t" & "he menu, right-click any region of the SchedulerControl (except appointments)." & Global.Microsoft.VisualBasic.Constants.vbCrLf & ""
            Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' carSchedulingBindingSource
            ' 
            Me.carSchedulingBindingSource.DataMember = "CarScheduling"
            Me.carSchedulingBindingSource.DataSource = Me.carsDBDataSet
            ' 
            ' carsDBDataSet
            ' 
            Me.carsDBDataSet.DataSetName = "CarsDBDataSet"
            Me.carsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' carsBindingSource
            ' 
            Me.carsBindingSource.DataMember = "Cars"
            Me.carsBindingSource.DataSource = Me.carsDBDataSet
            ' 
            ' carSchedulingTableAdapter
            ' 
            Me.carSchedulingTableAdapter.ClearBeforeFill = True
            ' 
            ' carsTableAdapter
            ' 
            Me.carsTableAdapter.ClearBeforeFill = True
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(673, 392)
            Me.Controls.Add(Me.schedulerControl1)
            Me.Controls.Add(Me.label1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            AddHandler Me.Load, New System.EventHandler(AddressOf Me.Form1_Load)
            CType((Me.schedulerControl1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.schedulerStorage1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.carSchedulingBindingSource), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.carsDBDataSet), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.carsBindingSource), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

'#End Region
        Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl

        Private carsDBDataSet As SchedulerResourcesManagement.CarsDBDataSet

        Private schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage

        Private carSchedulingTableAdapter As SchedulerResourcesManagement.CarsDBDataSetTableAdapters.CarSchedulingTableAdapter

        Private carsTableAdapter As SchedulerResourcesManagement.CarsDBDataSetTableAdapters.CarsTableAdapter

        Private label1 As System.Windows.Forms.Label

        Private carSchedulingBindingSource As System.Windows.Forms.BindingSource

        Private carsBindingSource As System.Windows.Forms.BindingSource
    End Class
End Namespace
