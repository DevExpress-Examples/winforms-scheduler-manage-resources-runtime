Imports Microsoft.VisualBasic
Imports System
Namespace SchedulerResourcesManagement
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim TimeRuler1 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler
            Dim TimeRuler2 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler
            Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl
            Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
            Me.carSchedulingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.bindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
            Me.carsDBDataSet = New CarsDBDataSet
            Me.carsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.carSchedulingTableAdapter = New CarsDBDataSetTableAdapters.CarSchedulingTableAdapter
            Me.carsTableAdapter = New CarsDBDataSetTableAdapters.CarsTableAdapter
            Me.label1 = New System.Windows.Forms.Label
            CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.carSchedulingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.carsDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.carsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'schedulerControl1
            '
            Me.schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Timeline
            Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.schedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource
            Me.schedulerControl1.Location = New System.Drawing.Point(0, 44)
            Me.schedulerControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.schedulerControl1.Name = "schedulerControl1"
            Me.schedulerControl1.OptionsView.ResourceHeaders.Height = 100
            Me.schedulerControl1.OptionsView.ResourceHeaders.ImageAlign = DevExpress.XtraScheduler.HeaderImageAlign.Top
            Me.schedulerControl1.OptionsView.ResourceHeaders.ImageSize = New System.Drawing.Size(100, 100)
            Me.schedulerControl1.OptionsView.ResourceHeaders.ImageSizeMode = DevExpress.XtraScheduler.HeaderImageSizeMode.ZoomImage
            Me.schedulerControl1.Size = New System.Drawing.Size(897, 438)
            Me.schedulerControl1.Start = New Date(2008, 10, 19, 0, 0, 0, 0)
            Me.schedulerControl1.Storage = Me.schedulerStorage1
            Me.schedulerControl1.TabIndex = 0
            Me.schedulerControl1.Text = "schedulerControl1"
            Me.schedulerControl1.Views.DayView.TimeRulers.Add(TimeRuler1)
            Me.schedulerControl1.Views.TimelineView.ResourcesPerPage = 3
            Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(TimeRuler2)
            '
            'schedulerStorage1
            '
            Me.schedulerStorage1.Appointments.DataSource = Me.carSchedulingBindingSource
            Me.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
            Me.schedulerStorage1.Appointments.Mappings.Description = "Description"
            Me.schedulerStorage1.Appointments.Mappings.End = "EndTime"
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
            Me.schedulerStorage1.Resources.Mappings.Color = "Color"
            Me.schedulerStorage1.Resources.Mappings.Id = "ID"
            Me.schedulerStorage1.Resources.Mappings.Image = "Picture"
            '
            'carSchedulingBindingSource
            '
            Me.carSchedulingBindingSource.DataMember = "CarScheduling"
            Me.carSchedulingBindingSource.DataSource = Me.bindingSource1
            '
            'bindingSource1
            '
            Me.bindingSource1.DataSource = Me.carsDBDataSet
            Me.bindingSource1.Position = 0
            '
            'carsDBDataSet
            '
            Me.carsDBDataSet.DataSetName = "CarsDBDataSet"
            Me.carsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'carsBindingSource
            '
            Me.carsBindingSource.DataMember = "Cars"
            Me.carsBindingSource.DataSource = Me.bindingSource1
            '
            'carSchedulingTableAdapter
            '
            Me.carSchedulingTableAdapter.ClearBeforeFill = True
            '
            'carsTableAdapter
            '
            Me.carsTableAdapter.ClearBeforeFill = True
            '
            'label1
            '
            Me.label1.Dock = System.Windows.Forms.DockStyle.Top
            Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.label1.Location = New System.Drawing.Point(0, 0)
            Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(897, 44)
            Me.label1.TabIndex = 1
            Me.label1.Text = "Use the Scheduler context menu to create, modify or delete resource." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "To invoke t" & _
                "he menu, right-click any region of the SchedulerControl (except appointments)." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & _
                ""
            Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Form1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(897, 482)
            Me.Controls.Add(Me.schedulerControl1)
            Me.Controls.Add(Me.label1)
            Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.carSchedulingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.carsDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.carsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

		#End Region

		Private WithEvents schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
		Private bindingSource1 As System.Windows.Forms.BindingSource
		Private carsDBDataSet As CarsDBDataSet
		Private WithEvents schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
		Private carSchedulingBindingSource As System.Windows.Forms.BindingSource
        Private carSchedulingTableAdapter As CarsDBDataSetTableAdapters.CarSchedulingTableAdapter
		Private carsBindingSource As System.Windows.Forms.BindingSource
        Private carsTableAdapter As CarsDBDataSetTableAdapters.CarsTableAdapter
		Private label1 As System.Windows.Forms.Label
	End Class
End Namespace

