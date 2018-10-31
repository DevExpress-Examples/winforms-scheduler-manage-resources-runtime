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
        private readonly Resource editedResourceCopy = ResourceEmpty.Resource;

        protected virtual Resource SourceResource { get { return sourceResource; } }
        protected virtual Resource EditedResourceCopy { get { return editedResourceCopy; } }

        protected virtual Image DefaultResourceImage { get { return SchedulerResourcesManagement.Properties.Resources.NoImage; } }

        public ResourceForm(Resource resource, SchedulerDataStorage  schedulerStorage) {
            if (resource == null)
                throw new ArgumentNullException("resource");

            this.Disposed += new EventHandler(ResourceForm_Disposed);

            this.editedResourceCopy = schedulerStorage.CreateResource(null);
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
            EditedResourceCopy.SetColor(SourceResource.GetColor());
            EditedResourceCopy.SetImage(SourceResource.GetImage());
        }

        protected virtual void UpdateForm() {
            tbCaption.Text = EditedResourceCopy.Caption;
            lblColor.BackColor = EditedResourceCopy.GetColor();
            pbImage.Image = (EditedResourceCopy.GetImage() == null ? DefaultResourceImage : EditedResourceCopy.GetImage());
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
            SourceResource.SetColor(EditedResourceCopy.GetColor());
            SourceResource.SetImage(EditedResourceCopy.GetImage());
        }

        private void btnColor_Click(object sender, EventArgs e) {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                lblColor.BackColor = colorDialog1.Color;
                EditedResourceCopy.SetColor(colorDialog1.Color);
            }
        }

        private void pbImage_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                pbImage.Image = Image.FromFile(openFileDialog1.FileName);
                EditedResourceCopy.SetImage(pbImage.Image);
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
