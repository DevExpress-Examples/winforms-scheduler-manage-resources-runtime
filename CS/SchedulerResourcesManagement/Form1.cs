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
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace SchedulerResourcesManagement {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'carsDBDataSet.Cars' table. You can move, or remove it, as needed.
         
            // TODO: This line of code loads data into the 'carsDBDataSet.CarScheduling' table. You can move, or remove it, as needed.
            carSchedulingTableAdapter.Fill(carsDBDataSet.CarScheduling);
            carsTableAdapter.Fill(carsDBDataSet.Cars);

            schedulerControl1.OptionsView.ResourceHeaders.RotateCaption = false;
            schedulerControl1.OptionsBehavior.SelectOnRightClick = true;

            if (schedulerStorage1.Appointments.Count > 0)
                schedulerControl1.Start = schedulerStorage1.Appointments[0].Start;
        }

        #region Data-Related Events

        private void Appointments_Modified(object sender, PersistentObjectsEventArgs e) {
            carSchedulingTableAdapter.Update(carsDBDataSet);
            carsDBDataSet.AcceptChanges();
        }

        private void Resources_Modified(object sender, PersistentObjectsEventArgs e) {
            carsTableAdapter.Update(carsDBDataSet);
            carsDBDataSet.AcceptChanges();
        }

     

        #endregion Data-Related Events

        private void schedulerControl1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e) {
            if (e.Menu.Id == DevExpress.XtraScheduler.SchedulerMenuItemId.DefaultMenu) {
                SchedulerMenuItem itemNewResource = new SchedulerMenuItem("New Resource", OnAddResource);
                SchedulerMenuItem itemEditResource = new SchedulerMenuItem("Edit Resource", OnEditResource);
                SchedulerMenuItem itemDeleteResource = new SchedulerMenuItem("Delete Resource", OnDeleteResource);
                int baseIndex = 4;

                itemNewResource.BeginGroup = true;
                e.Menu.Items.Insert(baseIndex, itemNewResource);
                e.Menu.Items.Insert(baseIndex + 1, itemEditResource);
                e.Menu.Items.Insert(baseIndex + 2, itemDeleteResource);
            }
        }

        private void OnAddResource(object sender, EventArgs e) {
            Resource resource = schedulerStorage1.CreateResource(-1);

            using (ResourceForm form = new ResourceForm(resource)) {
                if (form.ShowDialog(this) == DialogResult.OK) {
                    schedulerStorage1.Resources.Add(resource);
                    schedulerStorage1.RefreshData();
                    ScrollToLastResource();
                }
                else {
                    resource.Dispose();
                }
            }
        }

        private void OnEditResource(object sender, EventArgs e) {
            Resource resource = schedulerControl1.SelectedResource;
            
            using (ResourceForm form = new ResourceForm(resource)) {
                form.ShowDialog(this);
            }
        }

        private void OnDeleteResource(object sender, EventArgs e) {
            Appointment found = schedulerStorage1.Appointments.Items.Find(IsAssignedToCurrentResource);

            if (found == null)
                schedulerControl1.SelectedResource.Delete();
            else
                MessageBox.Show("Cannot delete resource: it has appointments assigned to it.", "Message");
        }

        private bool IsAssignedToCurrentResource(Appointment apt) {
            return (apt.ResourceId == Resource.Empty || Convert.ToInt32(apt.ResourceId) == Convert.ToInt32(schedulerControl1.SelectedResource.Id));
        }

        private void ScrollToLastResource() {
            schedulerControl1.ActiveView.FirstVisibleResourceIndex = Math.Max(0, schedulerStorage1.Resources.Count - schedulerControl1.ActiveView.ResourcesPerPage);
            schedulerControl1.Services.Selection.SelectedResource = schedulerStorage1.Resources[schedulerStorage1.Resources.Count - 1];
        }
    }
}