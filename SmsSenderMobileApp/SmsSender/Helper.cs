using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using Android.Util;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace SmsSender
{
    public class Helper
    {
        public static MobileServiceClient MobileService = new MobileServiceClient(
            //"https://sms-ams.azure-mobile.net/",
            //"vvvqqwgdejhhDbURXmpjnFspSPrzeR93"
            "https://sms-service.azure-mobile.net/",    // Please change the mobile service URL
            "vvvqqwasasjhhDbURXmpjnFspSPrzeR93"         // Please change the Mobile Service Key
        );

        private MobileServiceCollection<TodoItem, TodoItem> items;
        private IMobileServiceTable<TodoItem> todoTable = MobileService.GetTable<TodoItem>();
        public async void SendMessage()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems
                items = await todoTable.ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            if (exception != null)
            {
                Log.Debug("Helper", exception.Message);
                //await new MessageDialog(exception.Message, "Error loading items").ShowAsync(); //dont know on andorid
            }
            else
            {
                foreach (TodoItem T in this.items)
                {
                    Console.WriteLine(T.phoneno, T.messageval);
                    SmsManager.Default.SendTextMessage(T.phoneno, null, T.messageval, null, null);
                    Log.Debug("Message Sent: ", T.phoneno);
                    await todoTable.DeleteAsync(T);
                    Log.Debug("Message Deleted: ", T.phoneno + " - " + T.id);
                }
            }
        }

    }

    public class TodoItem
    {
        [JsonProperty(PropertyName = "phoneno")]
        public string phoneno { get; set; }

        [JsonProperty(PropertyName = "messageval")]
        public string messageval { get; set; }

        public string id { get; set; }

    }
}