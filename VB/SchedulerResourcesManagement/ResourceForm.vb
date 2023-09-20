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
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Namespace SchedulerResourcesManagement

    Public Partial Class ResourceForm
        Inherits Form

        Private ReadOnly sourceResourceField As Resource = Nothing

        Private ReadOnly editedResourceCopyField As Resource = Resource.Empty

        Protected Overridable ReadOnly Property SourceResource As Resource
            Get
                Return sourceResourceField
            End Get
        End Property

        Protected Overridable ReadOnly Property EditedResourceCopy As Resource
            Get
                Return editedResourceCopyField
            End Get
        End Property

        Protected Overridable ReadOnly Property DefaultResourceImage As Image
            Get
                Return Properties.Resources.NoImage
            End Get
        End Property

        Public Sub New(ByVal resource As Resource)
            If resource Is Nothing Then Throw New ArgumentNullException("resource")
            AddHandler Disposed, New EventHandler(AddressOf ResourceForm_Disposed)
            sourceResourceField = resource
            InitializeComponent()
            UpdateEditedResourceCopy()
            UpdateForm()
        End Sub

        Private Sub ResourceForm_Disposed(ByVal sender As Object, ByVal e As EventArgs)
            If EditedResourceCopy IsNot Nothing Then EditedResourceCopy.Dispose()
        End Sub

        Protected Overridable Sub UpdateEditedResourceCopy()
            EditedResourceCopy.Caption = SourceResource.Caption
            EditedResourceCopy.Color = SourceResource.Color
            EditedResourceCopy.Image = SourceResource.Image
        End Sub

        Protected Overridable Sub UpdateForm()
            tbCaption.Text = EditedResourceCopy.Caption
            lblColor.BackColor = EditedResourceCopy.Color
            pbImage.Image = If(EditedResourceCopy.Image Is Nothing, DefaultResourceImage, EditedResourceCopy.Image)
            UpdateFormTitle()
        End Sub

        Protected Overridable Sub UpdateFormTitle()
            Dim formatArgument As String = String.Empty
            If Not String.IsNullOrEmpty(tbCaption.Text) Then formatArgument = tbCaption.Text & " - "
            Text = String.Format("{0}Resource", formatArgument)
        End Sub

        Protected Overridable Sub ApplyChanges()
            SourceResource.Caption = EditedResourceCopy.Caption
            SourceResource.Color = EditedResourceCopy.Color
            SourceResource.Image = EditedResourceCopy.Image
        End Sub

        Private Sub btnColor_Click(ByVal sender As Object, ByVal e As EventArgs)
            If colorDialog1.ShowDialog() = DialogResult.OK Then
                lblColor.BackColor = colorDialog1.Color
                EditedResourceCopy.Color = colorDialog1.Color
            End If
        End Sub

        Private Sub pbImage_Click(ByVal sender As Object, ByVal e As EventArgs)
            If openFileDialog1.ShowDialog() = DialogResult.OK Then
                pbImage.Image = Image.FromFile(openFileDialog1.FileName)
                EditedResourceCopy.Image = pbImage.Image
            End If
        End Sub

        Private Sub tbCaption_Validated(ByVal sender As Object, ByVal e As EventArgs)
            EditedResourceCopy.Caption = tbCaption.Text
        End Sub

        Private Sub tbCaption_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            UpdateFormTitle()
        End Sub

        Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs)
            ApplyChanges()
        End Sub
    End Class
End Namespace
