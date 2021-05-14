namespace EventManagement.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// This class implements the api methods to apply CRUD operations on Guest table.
    /// </summary>
    public class MainLogic
    {
        private string url = "https://localhost:44348/GuestsApi/";

        private HttpClient client = new HttpClient();

        private JsonSerializerOptions jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        /// <summary>
        /// This method gets the guests from the api.
        /// </summary>
        /// <returns>List of Guests.</returns>
        public List<GuestVM> ApiGetGuests()
        {
            string json = this.client.GetStringAsync(this.url + "all").Result;
            var list = JsonSerializer.Deserialize<List<GuestVM>>(json, this.jsonOptions);
            return list;
        }

        /// <summary>
        /// This method delete the Guest from database.
        /// </summary>
        /// <param name="guest">Guest.</param>
        public void ApiDelGuest(GuestVM guest)
        {
            bool success = false;
            if (guest != null)
            {
                string json = this.client.GetStringAsync(this.url + "del/" + guest.ID.ToString()).Result;
                JsonDocument doc = JsonDocument.Parse(json);

                success = doc.RootElement.EnumerateObject().First().Value.GetRawText() == "true";
            }

            SendMessage(success);
        }

        /// <summary>
        /// This method edits or adds the Guest to the database.
        /// </summary>
        /// <param name="guest">Guest.</param>
        /// <param name="editor">Func.</param>
        public void EditGuest(GuestVM guest, Func<GuestVM, bool> editor)
        {
            GuestVM clone = new GuestVM();
            if (guest != null)
            {
                clone.CopyFrom(guest);
            }

            bool? success = editor?.Invoke(clone);
            if (success == true)
            {
                if (guest != null)
                {
                    success = this.ApiEditGuest(clone, true);
                }
                else
                {
                    success = this.ApiEditGuest(clone, false);
                }
            }

            SendMessage(success == true);
        }

        private static void SendMessage(bool success)
        {
            string msg = success ? "Operation completed successfully" : "Operation failed";
            Messenger.Default.Send(msg, "GuestResult");
        }

        private bool ApiEditGuest(GuestVM guest, bool isEditing)
        {
            if (guest == null)
            {
                return false;
            }

            string myUrl = isEditing ? this.url + "mod" : this.url + "add";

            Dictionary<string, string> postData = new Dictionary<string, string>();
            if (isEditing)
            {
                postData.Add("id", guest.ID.ToString());
            }

            postData.Add("name", guest.Name);
            postData.Add("contact", guest.Contact);
            postData.Add("email", guest.Email);
            postData.Add("city", guest.City);
            postData.Add("gender", guest.Gender);
            string json = this.client.PostAsync(myUrl, new FormUrlEncodedContent(postData)).
                Result.Content.ReadAsStringAsync().Result;

            JsonDocument doc = JsonDocument.Parse(json);
            return doc.RootElement.EnumerateObject().First().Value.GetRawText() == "true";
        }
    }
}