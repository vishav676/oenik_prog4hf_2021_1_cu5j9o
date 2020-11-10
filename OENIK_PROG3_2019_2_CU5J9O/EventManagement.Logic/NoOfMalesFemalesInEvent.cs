using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace EventManagement.Logic
{
    public class NoOfMalesFemalesInEvent
    {
        public string EventName { get; set; }

        public int noOfMales { get; set; }

        public int noOfFemales { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is TotalEventSale)
            {
                NoOfMalesFemalesInEvent other = obj as NoOfMalesFemalesInEvent;
                return this.EventName == other.EventName && 
                    this.noOfFemales == other.noOfFemales &&
                    this.noOfMales == other.noOfMales;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (int)this.noOfMales + (int)this.noOfFemales + this.EventName.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.EventName}, No of Females {this.noOfFemales}, No of Males {this.noOfMales}";
        }

    }
}
