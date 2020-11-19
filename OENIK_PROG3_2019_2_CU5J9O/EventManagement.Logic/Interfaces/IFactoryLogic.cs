namespace EventManagement.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This inteface will contains methods to generate specific logics.
    /// </summary>
    public interface IFactoryLogic
    {
        /// <summary>
        /// This method generate the logic instance of type <see cref="FrontOfficeLogic"/>.
        /// </summary>
        /// <returns>Instance of <see cref="FrontOfficeLogic"/>.</returns>
        FrontOfficeLogic GetFrontOfficeLogic();

        /// <summary>
        /// This method generate the logic instance of type <see cref="AdminstratorLogic"/>.
        /// </summary>
        /// <returns>Instance of <see cref="AdminstratorLogic"/>.</returns>
        AdminstratorLogic GetAdminstratorLogic();
    }
}
