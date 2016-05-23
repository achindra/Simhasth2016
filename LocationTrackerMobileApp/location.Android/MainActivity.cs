using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Locations;
using Location.Droid.Services;
using Android.Content.PM;
using Location.Lib;

namespace Location.Droid
{
    [Activity(Label = "Simhasth", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.ScreenLayout)]
    public class MainActivity : Activity
    {
        readonly string logTag = "MainActivity";

        // make our labels
        TextView latText;
        TextView longText;
        private EditText name;
        private EditText phone;
        private EditText bloodGroup;
        private EditText hierarchy;
        private EditText reserve;
        private Button reset;
        private Button save;
        private ToggleButton toggleGps;
        private TextView status;

        #region Lifecycle

        //Lifecycle stages
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //Log.Debug(logTag, "OnCreate: Location app is becoming active");

            SetContentView(Resource.Layout.User);

            // This event fires when the ServiceConnection lets the client (our App class) know that
            // the Service is connected. We use this event to start updating the UI with location
            // updates from the Service
            App.Current.LocationServiceConnected += (object sender, ServiceConnectedEventArgs e) =>
            {
                Log.Debug(logTag, "ServiceConnected Event Raised");
                // notifies us of location changes from the system
                App.Current.LocationService.LocationChanged += HandleLocationChanged;
                //notifies us of user changes to the location provider (ie the user disables or enables GPS)
                App.Current.LocationService.ProviderDisabled += HandleProviderDisabled;
                App.Current.LocationService.ProviderEnabled += HandleProviderEnabled;
                // notifies us of the changing status of a provider (ie GPS no longer available)
                App.Current.LocationService.StatusChanged += HandleStatusChanged;
            };

            name = FindViewById<EditText>(Resource.Id.name);
            phone = FindViewById<EditText>(Resource.Id.phone);
            reserve = FindViewById<EditText>(Resource.Id.reserve);
            bloodGroup = FindViewById<EditText>(Resource.Id.bloodGroup);
            hierarchy = FindViewById<EditText>(Resource.Id.hierarchy);

            latText = FindViewById<TextView>(Resource.Id.lat);
            longText = FindViewById<TextView>(Resource.Id.longx);

            reset = FindViewById<Button>(Resource.Id.reset);
            save = FindViewById<Button>(Resource.Id.save);

            toggleGps = FindViewById<ToggleButton>(Resource.Id.toggleGps);

            status = FindViewById<TextView>(Resource.Id.status);

            reset.Click += (sender, args) =>
            {
                name.Text = "";
                phone.Text = "";
                reserve.Text = "";
                bloodGroup.Text = "";
                hierarchy.Text = "";
            };

            save.Click += (sender, args) =>
            {
                var user = new User();
                user.BloodGroup = bloodGroup.Text;
                user.Hierarchy = hierarchy.Text;
                user.Name = name.Text;
                user.Phone = phone.Text;
                user.Reserve = reserve.Text;
                App.UserDetails = user;

                SaveSet();
            };

            toggleGps.CheckedChange += (sender, args) =>
            {
                if (args.IsChecked)
                {
                    status.Text = "Broadcast Starting...";
                    App.StartLocationService();
                    App.IsServiceRunning = true;
                    status.Text = "Broadcast Started!";
                }
                else
                {
                    status.Text = "Broadcast Stopping...";
                    App.StopLocationService();
                    App.IsServiceRunning = false;
                    status.Text = "Broadcast Stopped!";
                }
            };

            // Start the location service:
            //App.StartLocationService();
        }

        protected override void OnPause()
        {
            Log.Debug(logTag, "OnPause: Location app is moving to background");
            SaveSet();
            base.OnPause();
        }


        protected override void OnResume()
        {
            Log.Debug(logTag, "OnResume: Location app is moving into foreground");
            RetrieveSet();
            base.OnResume();
        }

        protected override void OnDestroy()
        {
            Log.Debug(logTag, "OnDestroy: Location app is becoming inactive");
            SaveSet();
            base.OnDestroy();

            // Stop the location service:
            if(App.IsServiceRunning)
                App.StopLocationService();
        }

        #endregion

        #region Android Location Service methods

        ///<summary>
        /// Updates UI with location data
        /// </summary>
        public void HandleLocationChanged(object sender, LocationChangedEventArgs e)
        {
            Android.Locations.Location location = e.Location;
            Log.Debug(logTag, "Foreground updating");

            // these events are on a background thread, need to update on the UI thread
            RunOnUiThread(() =>
            {
                latText.Text = String.Format("Latitude: {0}", location.Latitude);
                longText.Text = String.Format("Longitude: {0}", location.Longitude);
                //altText.Text = String.Format ("Altitude: {0}", location.Altitude);
                //speedText.Text = String.Format ("Speed: {0}", location.Speed);
                //accText.Text = String.Format ("Accuracy: {0}", location.Accuracy);
                //bearText.Text = String.Format ("Bearing: {0}", location.Bearing);
            });

        }

        public void HandleProviderDisabled(object sender, ProviderDisabledEventArgs e)
        {
            Log.Debug(logTag, "Location provider disabled event raised");
        }

        public void HandleProviderEnabled(object sender, ProviderEnabledEventArgs e)
        {
            Log.Debug(logTag, "Location provider enabled event raised");
        }

        public void HandleStatusChanged(object sender, StatusChangedEventArgs e)
        {
            Log.Debug(logTag, "Location status changed, event raised");
        }



        #endregion

        protected void SaveSet()
        {

            //store
            var prefs = Application.Context.GetSharedPreferences("LocationTracker", FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutString("Name", name != null ? name.Text : "");
            prefEditor.PutString("Phone", phone != null ? phone.Text : "");
            prefEditor.PutString("BloodGroup", bloodGroup != null ? bloodGroup.Text : "");
            prefEditor.PutString("Hierarchy", hierarchy != null ? hierarchy.Text : "");
            prefEditor.PutString("Reserve", reserve != null ? reserve.Text : "");
            prefEditor.Commit();

        }

        // Function called from OnCreate
        protected void RetrieveSet()
        {
            //retreive 
            var prefs = Application.Context.GetSharedPreferences("LocationTracker", FileCreationMode.Private);
            if (name != null)
                name.Text = prefs.GetString("Name", "");
            if (phone != null)
                phone.Text = prefs.GetString("Phone", "");
            if (bloodGroup != null)
                bloodGroup.Text = prefs.GetString("BloodGroup", "");
            if (hierarchy != null)
                hierarchy.Text = prefs.GetString("Hierarchy", "");
            if (reserve != null)
                reserve.Text = prefs.GetString("Reserve", "");

        }

    }
}


