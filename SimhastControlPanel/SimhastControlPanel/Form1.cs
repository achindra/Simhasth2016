using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using System.Net.Http;
using Newtonsoft.Json;
//using Twilio;
//using System.Net;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure.MobileServices;

namespace SimhastControlPanel
{
    public partial class frmApp : Form
    {
        public GMapOverlay mapOverlay = new GMapOverlay();
        public GMarkerGoogle cityCenter = new GMarkerGoogle(new PointLatLng(double.Parse("23.179357"), double.Parse("75.7827451")), GMarkerGoogleType.red_pushpin);
        public static List<ResourceModel> model { get; private set; }
        public static List<String> numbersInRadius = new List<string>();
        public const string NameSpace = "smsgateway-android";
        public const string QueueName = "queue";

        public static QueueClient MsgQueueClient;
        public static MobileServiceClient MobileService = new MobileServiceClient("https://sms-ams.azure-mobile.net/","vvvqqwgdejhhDbURXmpjnFspSPrzeR93");
        public frmApp()
        {
            InitializeComponent();
            /*
            NamespaceManager namespaceManager = NamespaceManager.Create();

            if (!namespaceManager.QueueExists(QueueName))
            {
                namespaceManager.CreateQueue(QueueName);
            }
            */
            //var messagingFactory = MessagingFactory.Create(
            //    namespaceManager.Address, 
            //    namespaceManager.Settings.TokenProvider);

            //MsgQueueClient = messagingFactory.CreateQueueClient("queue");
    }

        /*
        public static NamespaceManager CreateNamespaceManager()
        {
            var uri = ServiceBusEnvironment.CreateServiceUri("sb", NameSpace, String.Empty);
            var tP = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                "manage", "bXr5sBLFusaoqg58sBXf40JNidQXlpc4Xpn4HsD+hg8=");
            return new NamespaceManager(uri, tP);
        }
        */

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblRadius.Text = "Radius: " + double.Parse(trackBar1.Value.ToString()) / 1000 + "km";
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            UpdateMap(trackBar1.Value);
        }

        private void gMapControl_OnMapDrag()
        {
            cityCenter.Position = gMapControl.Position;
            UpdateMap(trackBar1.Value);
        }

        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            lblZoom.Text = "Zoom: " + trackBarZoom.Value;
        }

        private void trackBarZoom_ValueChanged(object sender, EventArgs e)
        {
            gMapControl.Zoom = trackBarZoom.Value;
        }

        private void gMapControl_DoubleClick(object sender, EventArgs e)
        {
            gMapControl.Position = gMapControl.FromLocalToLatLng(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
            cityCenter.Position = gMapControl.Position;
            UpdateMap(trackBar1.Value);
        }

        private void txtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            lblMsgLength.Text = txtMessage.Text.Length + "/160";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "";
            txtMessage_KeyUp(this, null);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                UpdateMap(trackBar1.Value);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                UpdateMap(trackBar1.Value);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                UpdateMap(trackBar1.Value);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                UpdateMap(trackBar1.Value);
        }
        private void lstMapType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lstMapType.SelectedItem.ToString())
            {
                case "Bing":
                    gMapControl.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
                    break;
                case "Google":
                    gMapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
                    break;

                case "OpenStreet":
                    gMapControl.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
                    break;

                case "Wikimapia":
                    gMapControl.MapProvider = GMap.NET.MapProviders.WikiMapiaMapProvider.Instance;
                    break;

                case "Yahoo":
                    gMapControl.MapProvider = GMap.NET.MapProviders.YahooMapProvider.Instance;
                    break;

                case "Cloud":
                    gMapControl.MapProvider = GMap.NET.MapProviders.CloudMadeMapProvider.Instance;
                    break;

                case "Near":
                    gMapControl.MapProvider = GMap.NET.MapProviders.NearMapProvider.Instance;
                    break;

                case "OpenCycle":
                    gMapControl.MapProvider = GMap.NET.MapProviders.OpenCycleMapProvider.Instance;
                    break;

                case "Ovi":
                    gMapControl.MapProvider = GMap.NET.MapProviders.OviMapProvider.Instance;
                    break;

                default:
                    gMapControl.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
                    break;

            }
            UpdateMap(trackBar1.Value);
        }

        private void frmApp_Load(object sender, EventArgs e)
        {
            gMapControl.Position = new GMap.NET.PointLatLng(23.179357, 75.7827451);
            gMapControl.Zoom = 14;
            gMapControl.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            lstMapType.SelectedIndex = 0;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;

            cityCenter = new GMarkerGoogle(new PointLatLng(double.Parse("23.179357"), double.Parse("75.7827451")), GMarkerGoogleType.red_pushpin);

            mapOverlay.Markers.Add(cityCenter);
            CreateCircle(cityCenter.Position, trackBar1.Value, 50);
        }




        #region Private_Func


        private async void UpdateMap(int radius)
        {
            await fetchDetails(radius);
            markPins(radius);
        }


        private async
        Task
fetchDetails(int radius)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://resourceman.azurewebsites.net");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applocation/json"));

                    HttpResponseMessage response = await client.GetAsync("api/resource?latitude=" + gMapControl.Position.Lat +
                                        "&longitude=" + gMapControl.Position.Lng + "&radius=" + trackBar1.Value.ToString());
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonArray = await response.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<List<ResourceModel>>(jsonArray);
                    }
                }
            }
            catch (Exception e)
            {
                //
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radius"></param>
        private void markPins(int radius)
        {
            mapOverlay.Polygons.Clear();
            mapOverlay.Markers.Clear();
            gMapControl.Overlays.Clear();
            numbersInRadius.Clear();

            if (model != null)
            {
                foreach (var entry in model)
                {
                    if ((radioButton1.Checked ||
                        (radioButton2.Checked && radioButton2.Tag.ToString().Equals(entry.hierarchy)) ||
                        (radioButton3.Checked && radioButton3.Tag.ToString().Equals(entry.hierarchy)) ||
                        (radioButton4.Checked && radioButton4.Tag.ToString().Equals(entry.hierarchy))) &&
                        entry.distance <= trackBar1.Value)
                    {
                        Image img = Image.FromFile("unknown.png", true);

                        switch (entry.hierarchy)
                        {
                            case "Doctor":
                                img = Image.FromFile("doctor.png");
                                break;

                            case "Staff":
                                img = Image.FromFile("Staff.png");
                                break;

                            case "Volunteer":
                                img = Image.FromFile("cpr.png");
                                break;

                            default:
                                break;
                        }

                        Bitmap bmp = new Bitmap(img, new Size(30, 30));

                        GMarkerGoogle pin = new GMarkerGoogle(new PointLatLng(double.Parse(entry.latitude.ToString()), double.Parse(entry.longitude.ToString())), bmp);

                        pin.ToolTip = new GMapRoundedToolTip(pin);
                        pin.ToolTipText = entry.hierarchy + ": " + entry.name + "\n" +
                            entry.reserve1 + " | " + entry.blood_group + " | " + entry.phone;

                        mapOverlay.Markers.Add(pin);
                        numbersInRadius.Add(entry.phone);
                    }
                }
            }
            mapOverlay.Markers.Add(cityCenter);
            CreateCircle(cityCenter.Position, trackBar1.Value, 50000);
            gMapControl.Overlays.Add(mapOverlay);

        }

        private void CreateCircle(PointLatLng point, double radius, int segments)
        {
            List<PointLatLng> gpollist = new List<PointLatLng>();
            double seg = Math.PI * 2 / segments;
            radius /= 100000;

            for (int i = 0; i < segments; i++)
            {
                double theta = seg * i;
                double a = point.Lat + Math.Cos(theta) * radius * 0.9;
                double b = point.Lng + Math.Sin(theta) * radius;

                gpollist.Add(new PointLatLng(a, b));
            }
            GMapPolygon gpol = new GMapPolygon(gpollist, "Hot");
            gpol.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            gpol.Stroke = new Pen(Color.Red, 1);

            mapOverlay.Polygons.Add(gpol);
            gMapControl.Overlays.Add(mapOverlay);

        }
        #endregion

        private async void btnSend_Click(object sender, EventArgs e)
        {
            txtWebResponse.Text = "";
            lstMsgResponse.Items.Clear();
            //MsgQueueClient = QueueClient.Create(QueueName);
            //List<BrokeredMessage> messageList = new List<BrokeredMessage>();
            
            //using (var client = new HttpClient())
            //{
            //var args = new Dictionary<string, string>();

            //args.Add("authkey=", txtAuthKey.Text);
            //String argList = "authkey=" + txtAuthKey.Text.Trim();

            //string numberList = "";
            foreach (string Number in numbersInRadius)
                {
                //messageList.Add(CreateSampleMessage(toNumber, txtMessage.Text));
                
                Item sms = new Item();
                string toNumber = Number.TrimStart('+');
                
                if (toNumber.Length == 10)
                    sms.phoneno = "91" + toNumber;
                else if (toNumber.Length == 12)
                    sms.phoneno = toNumber;
                else //invalid number
                    continue;

                sms.messageval = txtMessage.Text;
                Newtonsoft.Json.Linq.JObject smsToSend = Newtonsoft.Json.Linq.JObject.FromObject(sms);

                await MobileService.GetTable("TodoItem").InsertAsync(smsToSend);
                //SMSMessage sms = new SMSMessage();
                //sms.MobileNumber = toNumber;
                //sms.Message = txtMessage.Text;
                //BrokeredMessage msg = new BrokeredMessage(sms);
                //MsgQueueClient.Send(msg);
                //numberList += toNumber.Trim('+') + ",";
                //var twilio = new TwilioRestClient(txtSid.Text, txtToken.Text);
                //Twilio.Message msg = twilio.SendMessage(txtNumber.Text, toNumber, txtMessage.Text);
                //lstMsgResponse.Items.Add(msg.To + ":" + msg.Status + " | " + msg.RestException + " " + msg.ErrorCode + ":" + msg.ErrorMessage );
            }
            /*
            foreach (BrokeredMessage message in messageList)
            {
                while (true)
                {
                    try
                    {
                        MsgQueueClient.Send(message);
                    }
                    catch (MessagingException ex)
                    {
                        if (!ex.IsTransient)
                        {
                            Console.WriteLine(ex.Message);
                            throw;
                        }
                        else
                        {
                            HandleTransientErrors(ex);
                        }
                    }
                    Console.WriteLine(string.Format("Message sent: Id = {0}, Body = {1}", message.MessageId, message.GetBody<string>()));
                    break;
                }
            }
            */
            //argList += "&mobiles=" + numberList.TrimEnd(',');
            //argList += "&message=" + WebUtility.UrlEncode(txtMessage.Text);
            //argList += "&sender=" + txtSenderId.Text.Trim();
            //argList += "&route=default";
            //argList += "&country=91";

            //string response = await client.GetStringAsync("http://sms.ssdindia.com/api/sendhttp.php?" + argList.Trim());
            //txtWebResponse.Text = response;
            //args.Add("&mobiles=", numberList.TrimEnd(','));
            //args.Add("&message=", WebUtility.UrlEncode(txtMessage.Text));
            //args.Add("&sender=", txtSenderId.Text);
            //args.Add("&route=", "default");
            //args.Add("&country=", "91");

            //args = args.ToDictionary(x => x.Value.Trim(), x => x.Key);
            //args = args.ToDictionary(x => x.Key, x => x.Value.Trim());

            //var content = new FormUrlEncodedContent(args);

            //var response = await client.PostAsync("http://sms.ssdindia.com/api/sendhttp.php", content);
            //txtWebResponse.Text = content.ToString() + "\n";
            //txtWebResponse.Text += await response.Content.ReadAsStringAsync();

            //}
        }
        private static BrokeredMessage CreateSampleMessage(string messageId, string messageBody)
        {
            BrokeredMessage message = new BrokeredMessage(messageBody);
            message.MessageId = messageId;
            return message;
        }
        private static void HandleTransientErrors(MessagingException e)
        {
            //If transient error/exception, let's back-off for 2 seconds and retry
            Console.WriteLine(e.Message);
            Console.WriteLine("Will retry sending the message in 2 seconds");
            //this.Sleep(2000);
        }
    }
}
