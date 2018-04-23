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
    Partial Public Class ResourceForm
        Inherits Form


        Private ReadOnly sourceResource_Renamed As Resource = Nothing

        Private ReadOnly editedResourceCopy_Renamed As Resource = Resource.Empty

        Protected Overridable ReadOnly Property SourceResource() As Resource
            Get
                Return sourceResource_Renamed
            End Get
        End Property
        Protected Overridable ReadOnly Property EditedResourceCopy() As Resource
            Get
                Return editedResourceCopy_Renamed
            End Get
        End Property

        Protected Overridable ReadOnly Property DefaultResourceImage() As Image
            Get
                Return My.Resources.NoImage
            End Get
        End Property

        Public Sub New(ByVal resource As Resource)
            If resource Is Nothing Then
                Throw New ArgumentNullException("resource")
            End If

            AddHandler Disposed, AddressOf ResourceForm_Disposed

            Me.sourceResource_Renamed = resource
            InitializeComponent()

            UpdateEditedResourceCopy()
            UpdateForm()
        End Sub

        Private Sub ResourceForm_Disposed(ByVal sender As Object, ByVal e As EventArgs)
            If EditedResourceCopy IsNot Nothing Then
                EditedResourceCopy.Dispose()
            End If
        End Sub

        Protected Overridable Sub UpdateEditedResourceCopy()
            EditedResourceCopy.Caption = SourceResource.Caption
            EditedResourceCopy.Color = SourceResource.Color
            EditedResourceCopy.Image = SourceResource.Image
        End Sub

        Protected Overridable Sub UpdateForm()
            tbCaption.Text = EditedResourceCopy.Caption
            lblColor.BackColor = EditedResourceCopy.Color
            pbImage.Image = (If(EditedResourceCopy.Image Is Nothing, DefaultResourceImage, EditedResourceCopy.Image))
            UpdateFormTitle()
        End Sub

        Protected Overridable Sub UpdateFormTitle()
            Dim formatArgument As String = String.Empty

            If Not String.IsNullOrEmpty(tbCaption.Text) Then
                formatArgument = tbCaption.Text & " - "
            End If

            Me.Text = String.Format("{0}Resource", formatArgument)
        End Sub

        Protected Overridable Sub ApplyChanges()
            SourceResource.Caption = EditedResourceCopy.Caption
            SourceResource.Color = EditedResourceCopy.Color
            SourceResource.Image = EditedResourceCopy.Image
        End Sub

        Private Sub btnColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnColor.Click
            If colorDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                lblColor.BackColor = colorDialog1.Color
                EditedResourceCopy.Color = colorDialog1.Color
            End If
        End Sub

        Private Sub pbImage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles pbImage.Click
            If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                pbImage.Image = Image.FromFile(openFileDialog1.FileName)
                EditedResourceCopy.Image = pbImage.Image
            End If
        End Sub

        Private Sub tbCaption_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles tbCaption.Validated
            EditedResourceCopy.Caption = tbCaption.Text
        End Sub

        Private Sub tbCaption_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbCaption.TextChanged
            UpdateFormTitle()
        End Sub

        Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
            ApplyChanges()
        End Sub

    End Class
End Namespace
