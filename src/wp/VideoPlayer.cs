using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using Microsoft.Phone.Controls;
using System.Reflection;
using System.Collections;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.ApplicationModel;

namespace WPCordovaClassLib.Cordova.Commands
{
    public class VideoPlayer : BaseCommand
    {

        public void show(string options)
        {

            string[] args = JSON.JsonHelper.Deserialize<string[]>(options);
            string url = args[0];

            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {

                string[] arrayStr = url.Split('\\');
                string destFile = System.IO.Path.Combine(ApplicationData.Current.LocalFolder.Path, arrayStr[arrayStr.Length-1]);
                System.IO.File.Copy(System.IO.Path.Combine(Package.Current.InstalledLocation.Path, url), destFile, true);
                MediaPlayerLauncher mediaPlayerLauncher = new MediaPlayerLauncher();

                mediaPlayerLauncher.Media = new Uri(destFile, UriKind.Relative);
                mediaPlayerLauncher.Location = MediaLocationType.Data;
                mediaPlayerLauncher.Controls = MediaPlaybackControls.Pause | MediaPlaybackControls.Stop;
                mediaPlayerLauncher.Orientation = MediaPlayerOrientation.Landscape;
                mediaPlayerLauncher.Show();

            });

        }

    }
}
