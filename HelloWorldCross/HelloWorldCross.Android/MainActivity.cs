using Android.App;
using Android.Content.PM;
using Android.Runtime;

using Avalonia;
using Avalonia.Android;

namespace HelloWorldCross.Android;

[Activity(
    Label = "HelloWorldCross.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]


public class MainActivity : AvaloniaMainActivity<App>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder)
            .WithInterFont();
    }
}

/*
public class MainActivity : AvaloniaMainActivity { }


[Application]
public class Application : AvaloniaAndroidApplication<App>
{
    protected Application(nint javaReference, JniHandleOwnership transfer)
        : base(javaReference, transfer) { }

    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder).WithInterFont();
    }
}
*/
