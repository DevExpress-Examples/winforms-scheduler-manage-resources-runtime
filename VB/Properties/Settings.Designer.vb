'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.225
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
Namespace SchedulerResourcesManagement.Properties

    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")>
    Friend NotInheritable Partial Class Settings
        Inherits Global.System.Configuration.ApplicationSettingsBase

        Private Shared defaultInstance As SchedulerResourcesManagement.Properties.Settings = CType((Global.System.Configuration.ApplicationSettingsBase.Synchronized(New SchedulerResourcesManagement.Properties.Settings())), SchedulerResourcesManagement.Properties.Settings)

        Public Shared ReadOnly Property [Default] As Settings
            Get
                Return SchedulerResourcesManagement.Properties.Settings.defaultInstance
            End Get
        End Property

        <Global.System.Configuration.ApplicationScopedSettingAttribute()>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>
        <Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString)>
        <Global.System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""|DataDirectory|\CarsDB.mdb""")>
        Public ReadOnly Property CarsDBConnectionString As String
            Get
                Return(CStr((Me("CarsDBConnectionString"))))
            End Get
        End Property
    End Class
End Namespace
