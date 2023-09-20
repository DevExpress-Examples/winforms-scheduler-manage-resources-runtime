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
Imports System.Windows.Forms

Namespace SchedulerResourcesManagement

    Friend Module Program

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Sub Main()
            Call Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Call Application.Run(New Form1())
        End Sub
    End Module
End Namespace
