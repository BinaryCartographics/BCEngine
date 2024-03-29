using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Urmel;
using Microsoft.Xna.Framework;

namespace UrmelAndroid
{
  [Activity(
        Label = "@string/app_name",
        MainLauncher = true,
        Icon = "@drawable/icon",
        AlwaysRetainTaskState = true,
        LaunchMode = LaunchMode.SingleInstance,
        ScreenOrientation = ScreenOrientation.Landscape,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize
    )]

  public class UrmelActivity : AndroidGameActivity
  {
    private Main _game;
    private View _view;

    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      _game = new Main();
      _view = _game.Services.GetService(typeof(View)) as View;

      SetContentView(_view);
      _game.Run();
    }
  }
}
