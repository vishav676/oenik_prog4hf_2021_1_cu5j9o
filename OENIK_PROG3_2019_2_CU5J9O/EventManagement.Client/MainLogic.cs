using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventManagement.Client
{
    class MainLogic
    {
        string url = "https://localhost:44348/GuestsApi/";

        HttpClient client = new HttpClient();

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        void SendMessage(bool success)
        {
            string msg = success ? "Operation completed successfully" : "Operation failed";
            Messenger.Default.Send(msg, "GuestResult");
        }

        public List<GuestVM> ApiGetGuests()
        {
            string json = client.GetStringAsync(url + "all").Result;
            var list = JsonSerializer.Deserialize<List<GuestVM>>(json, jsonOptions);
            // NewtonSoft: JsonConvert.DeserializeObject<List<CarVM>>(json)

            // DO NOT EXECUTE SendMessage(true);
            // DEADLOCK because the event handler will call back this same method!
            return list;
        }

        public void ApiDelGuest(GuestVM guest)
        {
            bool success = false;
            if (guest != null)
            {
                string json = client.GetStringAsync(url + "del/" + guest.ID.ToString()).Result;
                JsonDocument doc = JsonDocument.Parse(json);
                // NewtonSoft:
                // JObject obj = JObject.Parse(json); return (bool)obj["OperationResult"];

                success = doc.RootElement.EnumerateObject().First().Value.GetRawText() == "true";
            }
            SendMessage(success);
        }

        bool ApiEditGuest(GuestVM guest, bool isEditing)
        {
            if (guest == null) return false;
            string myUrl = isEditing ? url + "mod" : url + "add";

            Dictionary<string, string> postData = new Dictionary<string, string>();
            if (isEditing) postData.Add("id", guest.ID.ToString());
            postData.Add("name", guest.Name);
            postData.Add("contact", guest.Contact);
            postData.Add("email", guest.Email);
            postData.Add("city", guest.City);
            postData.Add("gender", guest.Gender);
            string json = client.PostAsync(myUrl, new FormUrlEncodedContent(postData)).
                Result.Content.ReadAsStringAsync().Result;

            JsonDocument doc = JsonDocument.Parse(json);
            return doc.RootElement.EnumerateObject().First().Value.GetRawText() == "true";
        }

        public void EditGuest(GuestVM guest, Func<GuestVM, bool> editor)
        {
            GuestVM clone = new GuestVM();
            if (guest != null) clone.CopyFrom(guest);
            bool? success = editor?.Invoke(clone);
            if (success == true)
            {
                if (guest != null) success = ApiEditGuest(clone, true);
                else success = ApiEditGuest(clone, false);
            }
            SendMessage(success == true);
        }
    }
}