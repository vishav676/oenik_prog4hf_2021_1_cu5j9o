namespace EventManagement.Repository
{
    using System.Linq;

    /// <summary>
    /// This is general interface which contains all the generic methods for all Tables of the Database.
    /// </summary>
    /// <typeparam name="T">Class Type.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// This method will return all the entries present in particular table.
        /// </summary>
        /// <returns>IQueryable list.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// This method will return the entry with specific id from the particular table.
        /// </summary>
        /// <param name="id">Data Id which needs to be returned from table.</param>
        /// <returns>Return entry of Type T.</returns>
        T GetOne(int id);

        /// <summary>
        /// This methods will not return anything but will help to insert the data in the table.
        /// </summary>
        /// <param name="entity">data model which need to be inserted.</param>
        void Insert(T entity);

        /// <summary>
        /// This method will delete the entry with particular Id.
        /// </summary>
        /// <param name="id">Entry Id which needs to be deleted.</param>
        /// <returns>Boolean value whether deletion is successful or not.</returns>
        bool Remove(int id);

        /// <summary>
        /// This method will delete the data model from the table.
        /// </summary>
        /// <param name="entity">entry which will get deleted.</param>
        /// <returns>Boolean value whether deletion is successful or not.</returns>
        bool Remove(T entity);
    }
}
