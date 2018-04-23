// Developer Express Code Central Example:
// How to manage scheduler resources at runtime
// 
// This example shows how you can manage scheduler resources at runtime. The
// Scheduler context menu is modified to include commands to create, modify or
// delete selected resource. To invoke the menu, right-click any region of
// SchedulerControl (except appointments). A custom form is invoked that enables
// you to set caption, color and image for the selected resource.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3201

namespace SchedulerResourcesManagement {
    partial class ResourceForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnOk = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCaption = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnColor = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblColor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(286, 12);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // button2
            // 
            this.button2.CausesValidation = false;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(286, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Caption:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Color:";
            // 
            // tbCaption
            // 
            this.tbCaption.Location = new System.Drawing.Point(91, 14);
            this.tbCaption.Name = "tbCaption";
            this.tbCaption.Size = new System.Drawing.Size(164, 20);
            this.tbCaption.TabIndex = 4;
            this.tbCaption.TextChanged += new System.EventHandler(this.tbCaption_TextChanged);
            this.tbCaption.Validated += new System.EventHandler(this.tbCaption_Validated);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(230, 44);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(25, 20);
            this.btnColor.TabIndex = 5;
            this.btnColor.Text = "...";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pbImage
            // 
            this.pbImage.Image = global::SchedulerResourcesManagement.Properties.Resources.NoImage;
            this.pbImage.Location = new System.Drawing.Point(5, 18);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(230, 116);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 8;
            this.pbImage.TabStop = false;
            this.pbImage.Click += new System.EventHandler(this.pbImage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbImage);
            this.groupBox1.Location = new System.Drawing.Point(15, 81);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(240, 139);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image";
            // 
            // lblColor
            // 
            this.lblColor.BackColor = System.Drawing.SystemColors.Control;
            this.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColor.Location = new System.Drawing.Point(91, 44);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(133, 20);
            this.lblColor.TabIndex = 11;
            // 
            // ResourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 231);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.tbCaption);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnOk);
            this.Name = "ResourceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resource";
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCaption;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblColor;
    }
}