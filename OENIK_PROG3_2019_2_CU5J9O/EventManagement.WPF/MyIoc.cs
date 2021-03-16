namespace EventManagement.WPF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;

    /// <summary>
    /// This class mantains the singloton behaviour.
    /// </summary>
    public class MyIoc : SimpleIoc, IServiceLocator
    {
        /// <summary>
        /// Gets the instance of the object created.
        /// </summary>
        public static MyIoc Instance { get; private set; } = new MyIoc();
    }
}
