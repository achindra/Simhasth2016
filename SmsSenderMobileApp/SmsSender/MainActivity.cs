using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SmsSender
{
    [Activity(Label = "SmsSender", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        private ToggleButton toggleSms;
        private bool SendSms = false;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            

            toggleSms.CheckedChange += (sender, args) =>
            {
                if (args.IsChecked)
                {
                    SendSms = true;
                    Task.Run(() => InitSmsSend());
                }
                else
                {
                    SendSms = false;
                }
            };


        }

        public void InitSmsSend()
        {
            do
            {
                var helperObj = new Helper();
                helperObj.SendMessage();
            } while (SendSms);
        }
    }
}

