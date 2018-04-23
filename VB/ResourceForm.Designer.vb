Imports Microsoft.VisualBasic
Imports System
Namespace SchedulerResourcesManagement
	Partial Public Class ResourceForm
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
			Me.btnOk = New System.Windows.Forms.Button()
			Me.button2 = New System.Windows.Forms.Button()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.tbCaption = New System.Windows.Forms.TextBox()
			Me.colorDialog1 = New System.Windows.Forms.ColorDialog()
			Me.btnColor = New System.Windows.Forms.Button()
			Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
			Me.pbImage = New System.Windows.Forms.PictureBox()
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.lblColor = New System.Windows.Forms.Label()
			CType(Me.pbImage, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' btnOk
			' 
			Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnOk.Location = New System.Drawing.Point(286, 12)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New System.Drawing.Size(75, 23)
			Me.btnOk.TabIndex = 0
			Me.btnOk.Text = "OK"
			Me.btnOk.UseVisualStyleBackColor = True
'			Me.btnOk.Click += New System.EventHandler(Me.btnOk_Click);
			' 
			' button2
			' 
			Me.button2.CausesValidation = False
			Me.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.button2.Location = New System.Drawing.Point(286, 41)
			Me.button2.Name = "button2"
			Me.button2.Size = New System.Drawing.Size(75, 23)
			Me.button2.TabIndex = 1
			Me.button2.Text = "Cancel"
			Me.button2.UseVisualStyleBackColor = True
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 17)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(46, 13)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Caption:"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(12, 49)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(34, 13)
			Me.label2.TabIndex = 3
			Me.label2.Text = "Color:"
			' 
			' tbCaption
			' 
			Me.tbCaption.Location = New System.Drawing.Point(91, 14)
			Me.tbCaption.Name = "tbCaption"
			Me.tbCaption.Size = New System.Drawing.Size(164, 20)
			Me.tbCaption.TabIndex = 4
'			Me.tbCaption.TextChanged += New System.EventHandler(Me.tbCaption_TextChanged);
'			Me.tbCaption.Validated += New System.EventHandler(Me.tbCaption_Validated);
			' 
			' btnColor
			' 
			Me.btnColor.Location = New System.Drawing.Point(230, 44)
			Me.btnColor.Name = "btnColor"
			Me.btnColor.Size = New System.Drawing.Size(25, 20)
			Me.btnColor.TabIndex = 5
			Me.btnColor.Text = "..."
			Me.btnColor.UseVisualStyleBackColor = True
'			Me.btnColor.Click += New System.EventHandler(Me.btnColor_Click);
			' 
			' openFileDialog1
			' 
			Me.openFileDialog1.FileName = "openFileDialog1"
			' 
			' pbImage
			' 
			Me.pbImage.Image = My.Resources.NoImage
			Me.pbImage.Location = New System.Drawing.Point(5, 18)
			Me.pbImage.Name = "pbImage"
			Me.pbImage.Size = New System.Drawing.Size(230, 116)
			Me.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
			Me.pbImage.TabIndex = 8
			Me.pbImage.TabStop = False
'			Me.pbImage.Click += New System.EventHandler(Me.pbImage_Click);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.pbImage)
			Me.groupBox1.Location = New System.Drawing.Point(15, 81)
			Me.groupBox1.Margin = New System.Windows.Forms.Padding(2)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Padding = New System.Windows.Forms.Padding(2)
			Me.groupBox1.Size = New System.Drawing.Size(240, 139)
			Me.groupBox1.TabIndex = 10
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Image"
			' 
			' lblColor
			' 
			Me.lblColor.BackColor = System.Drawing.SystemColors.Control
			Me.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.lblColor.Location = New System.Drawing.Point(91, 44)
			Me.lblColor.Name = "lblColor"
			Me.lblColor.Size = New System.Drawing.Size(133, 20)
			Me.lblColor.TabIndex = 11
			' 
			' ResourceForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(376, 231)
			Me.Controls.Add(Me.lblColor)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.btnColor)
			Me.Controls.Add(Me.tbCaption)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.button2)
			Me.Controls.Add(Me.btnOk)
			Me.Name = "ResourceForm"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Resource"
			CType(Me.pbImage, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox1.ResumeLayout(False)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents btnOk As System.Windows.Forms.Button
		Private button2 As System.Windows.Forms.Button
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents tbCaption As System.Windows.Forms.TextBox
		Private colorDialog1 As System.Windows.Forms.ColorDialog
		Private WithEvents btnColor As System.Windows.Forms.Button
		Private WithEvents pbImage As System.Windows.Forms.PictureBox
		Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
		Private groupBox1 As System.Windows.Forms.GroupBox
		Private lblColor As System.Windows.Forms.Label
	End Class
End Namespace