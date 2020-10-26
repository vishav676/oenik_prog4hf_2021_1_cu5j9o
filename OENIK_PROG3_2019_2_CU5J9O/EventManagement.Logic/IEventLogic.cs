using Castle.Components.DictionaryAdapter;
using EventManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagement.Logic
{
    public interface IEventLogic
    {
        void add(Event enitity);

        public IList<Event> getAllEvent();

        bool remove(int id);

        void updatePlace(int id, string newPlace);

    }
}
