<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128635548/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3201)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# WinForms Scheduler - Manage resources at runtime

This example shows how to manage Scheduler resources in code (create, modify, delete selected resource).

The [PopupMenuShowing](https://docs.devexpress.com/WindowsForms/DevExpress.XtraScheduler.SchedulerControl.PopupMenuShowing) event is handled to add custom commands:

```csharp
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
```
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-scheduler-manage-resources-runtime&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-scheduler-manage-resources-runtime&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
