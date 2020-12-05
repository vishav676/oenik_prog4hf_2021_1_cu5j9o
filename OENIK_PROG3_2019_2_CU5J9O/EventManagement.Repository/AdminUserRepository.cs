namespace EventManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EventManagement.Data.Models;
    using EventManagement.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class implements all the methods that are defined in <see cref="IAdminUserRepository"/> and extends <see cref="Repo{T}"/> class.
    /// </summary>
    public class AdminUserRepository : Repo<AdminUser>, IAdminUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdminUserRepository"/> class.
        /// </summary>
        /// <param name="ctx"><see cref="DbContext"/>.</param>
        public AdminUserRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// This will retrieve the specific user from the database table.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <returns>Admin user.</returns>
        public override AdminUser GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// this method checks if the password is correct.
        /// </summary>
        /// <param name="name">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>Bool value wether password is correct or not.</returns>
        public bool PasswordCorrect(string name, string password)
        {
            var result = this.Search(name).FirstOrDefault();
            if (result != null)
            {
                if (result.Password == password)
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc/>
        public IQueryable<AdminUser> Search(string name)
        {
            var q = from item in this.GetAll()
                    where item.Username == name
                    select item;
            return q;
        }
    }
}
