namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices.ComTypes;
    using System.Text;

    /// <summary>
    /// public class to store the no of males and females in the event.
    /// </summary>
    public class NoOfMalesFemalesInEvent
    {
        /// <summary>
        /// Gets or sets event Name.
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets no of males.
        /// </summary>
        public int NoOfMales { get; set; }

        /// <summary>
        /// Gets or sets no of females.
        /// </summary>
        public int NoOfFemales { get; set; }

        /// <summary>
        /// Override equals method to check whether two objects are equal.
        /// </summary>
        /// <param name="obj">other Object.</param>
        /// <returns>Boolean Value.</returns>
        public override bool Equals(object obj)
        {
            if (obj is TotalEventSale)
            {
                NoOfMalesFemalesInEvent other = obj as NoOfMalesFemalesInEvent;
                return this.EventName == other.EventName &&
                    this.NoOfFemales == other.NoOfFemales &&
                    this.NoOfMales == other.NoOfMales;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Override GetHashCode method to generate the hash code based on object.
        /// </summary>
        /// <returns>int value (HashCode).</returns>
        public override int GetHashCode()
        {
            return (int)this.NoOfMales + (int)this.NoOfFemales + this.EventName.GetHashCode();
        }

        /// <summary>
        /// Override toString to generate the string value from the object.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            return $"{this.EventName}, No of Females {this.NoOfFemales}, No of Males {this.NoOfMales}";
        }
    }
}
