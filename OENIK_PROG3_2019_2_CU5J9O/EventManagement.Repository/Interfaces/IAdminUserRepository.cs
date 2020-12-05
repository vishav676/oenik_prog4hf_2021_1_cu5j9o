namespace EventManagement.Repository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EventManagement.Data.Models;

    /// <summary>
    /// This inteface inherits IRepository interface.
    /// This contains the methods which will be implemented in the AdminUserRepository class.
    /// </summary>
    public interface IAdminUserRepository : IRepository<AdminUser>
    {
        /// <summary>
        /// This method will search the user whos logging in.
        /// </summary>
        /// <param name="name">username.</param>
        /// <returns>IQueryable.</returns>
        IQueryable<AdminUser> Search(string name);

        /// <summary>
        /// this method checks if the password is correct.
        /// </summary>
        /// <param name="name">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>Bool value wether password is correct or not.</returns>
        bool PasswordCorrect(string name, string password);
    }
}
