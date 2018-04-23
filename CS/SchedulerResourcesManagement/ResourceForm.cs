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

using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace SchedulerResourcesManagement {
    public partial class ResourceForm : Form {
        private readonly Resource sourceResource = null;
        private readonly Resource editedResourceCopy = Resource.Empty;

        protected virtual Resource SourceResource { get { return sourceResource; } }
        protected virtual Resource EditedResourceCopy { get { return editedResourceCopy; } }

        protected virtual Image DefaultResourceImage { get { return SchedulerResourcesManagement.Properties.Resources.NoImage; } }

        public ResourceForm(Resource resource) {
            if (resource == null)
                throw new ArgumentNullException("resource");

            this.Disposed += new EventHandler(ResourceForm_Disposed);

            this.sourceResource = resource;
            InitializeComponent();

            UpdateEditedResourceCopy();
            UpdateForm();
        }

        void ResourceForm_Disposed(object sender, EventArgs e) {
            if (EditedResourceCopy != null)
                EditedResourceCopy.Dispose();
        }

        protected virtual void UpdateEditedResourceCopy() {
            EditedResourceCopy.Caption = SourceResource.Caption;
            EditedResourceCopy.Color = SourceResource.Color;
            EditedResourceCopy.Image = SourceResource.Image;
        }

        protected virtual void UpdateForm() {
            tbCaption.Text = EditedResourceCopy.Caption;
            lblColor.BackColor = EditedResourceCopy.Color;
            pbImage.Image = (EditedResourceCopy.Image == null ? DefaultResourceImage : EditedResourceCopy.Image);
            UpdateFormTitle();
        }

        protected virtual void UpdateFormTitle() {
            string formatArgument = string.Empty;
           
            if (!string.IsNullOrEmpty(tbCaption.Text))
                formatArgument = tbCaption.Text + " - ";

            this.Text = string.Format("{0}Resource", formatArgument);
        }

        protected virtual void ApplyChanges() {
            SourceResource.Caption = EditedResourceCopy.Caption;
            SourceResource.Color = EditedResourceCopy.Color;
            SourceResource.Image = EditedResourceCopy.Image;
        }

        private void btnColor_Click(object sender, EventArgs e) {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                lblColor.BackColor = colorDialog1.Color;
                EditedResourceCopy.Color = colorDialog1.Color;
            }
        }

        private void pbImage_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                pbImage.Image = Image.FromFile(openFileDialog1.FileName);
                EditedResourceCopy.Image = pbImage.Image;
            }
        }

        private void tbCaption_Validated(object sender, EventArgs e) {
            EditedResourceCopy.Caption = tbCaption.Text;
        }

        private void tbCaption_TextChanged(object sender, EventArgs e) {
            UpdateFormTitle();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            ApplyChanges();
        }

    }
}
