using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            //var label = FindViewById<Button>(Resource.Id.MyButton);
            var label = FindViewById<TextView>(Resource.Id.textView1);
            button.Click += delegate 
            {
                count++;
                label.Text = $"You clicked {count} times";
                //button.Text = string.Format("{0} clicks!", count++);
            };
        }
    }
}

