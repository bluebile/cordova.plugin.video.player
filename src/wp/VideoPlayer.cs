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

                MediaPlayerLauncher mediaPlayerLauncher = new MediaPlayerLauncher();

                mediaPlayerLauncher.Media = new Uri(url, UriKind.RelativeOrAbsolute);
                mediaPlayerLauncher.Location = MediaLocationType.Data;
                mediaPlayerLauncher.Controls = MediaPlaybackControls.Pause | MediaPlaybackControls.Stop;
                mediaPlayerLauncher.Orientation = MediaPlayerOrientation.Landscape;
                mediaPlayerLauncher.Show();

            });

        }

    }
}