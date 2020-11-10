using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagement.Logic
{
    interface IFactoryLogic
    {

        FrontOfficeLogic GetFrontOfficeLogic();

        AdminstratorLogic GetAdminstratorLogic();
    }
}
