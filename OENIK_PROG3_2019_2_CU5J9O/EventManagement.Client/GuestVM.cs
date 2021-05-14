namespace EventManagement.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// This class acts as the data model for the client layer.
    /// </summary>
    public class GuestVM : ObservableObject
    {
        private int id;

        private string name;

        private string contact;

        private string email;

        private string city;

        private string gender;

        /// <summary>
        /// Gets or sets Id.
        /// this property of Class represents Id for table guests.
        /// It is unique for every instance and is automatically generated.
        /// </summary>
        public int ID
        {
            get { return this.id; }
            set { this.Set(ref this.id, value); }
        }

        /// <summary>
        /// Gets or Sets Name attribute of the class.
        /// This field stores the Guest Name for the Event.
        /// This is manadatory property and it's Max Length can be 50.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.Set(ref this.name, value); }
        }

        /// <summary>
        /// Gets or Sets Contact attribute of the class.
        /// This field stores the Contact Info of the Guest.
        /// This is manadatory property and it's Max Length can be 50.
        /// </summary>
        public string Contact
        {
            get { return this.contact; }
            set { this.Set(ref this.contact, value); }
        }

        /// <summary>
        /// Gets or Sets Email attribute of the class.
        /// This field stores the Email Id of the Guest.
        /// This is manadatory property and it's Max Length can be 50.
        /// </summary>
        public string Email
        {
            get { return this.email; }
            set { this.Set(ref this.email, value); }
        }

        /// <summary>
        /// Gets or Sets City attribute of the class.
        /// This field stores the City Name where the Guest is from.
        /// This is manadatory property and it's Max Length can be 50.
        /// </summary>
        public string City
        {
            get { return this.city; }
            set { this.Set(ref this.city, value); }
        }

        /// <summary>
        /// Gets or Sets Gender attribute of the class.
        /// This field stores the Gender of the Guest.
        /// This is manadatory property and it's Max Length can be 50.
        /// </summary>
        public string Gender
        {
            get { return this.gender; }
            set { this.Set(ref this.gender, value); }
        }

        /// <summary>
        /// Override public function to generate string from object data.
        /// </summary>
        /// <returns> String.</returns>
        public override string ToString()
        {
            string s = $"Guest Id: {this.ID} \nGuest Name: {this.Name}\nCity: {this.City} \nContact: {this.Contact} \nGender: {this.Gender}\n";
            return s;
        }

        /// <summary>
        /// This method creates the copy of the guest which needs to be edited.
        /// </summary>
        /// <param name="other">Guest object.</param>
        public void CopyFrom(GuestVM other)
        {
            this.GetType().GetProperties().ToList().ForEach(
                prop => prop.SetValue(this, prop.GetValue(other)));
        }
    }
}
