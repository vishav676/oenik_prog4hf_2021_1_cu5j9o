using EventManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Logic.Interfaces
{
    public interface IEditorService
    {
        bool EditGuest(Guest guest);
    }
}
