namespace EventManagement.WPF
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using CommonServiceLocator;
    using EventManagement.Data.Models;
    using EventManagement.Logic;
    using EventManagement.Logic.Interfaces;
    using EventManagement.Repository;
    using EventManagement.WPF.UI;
    using GalaSoft.MvvmLight.Ioc;
    using GalaSoft.MvvmLight.Messaging;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// This is a constructor which make the object of the required classes.
        /// </summary>
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => MyIoc.Instance);
            MyIoc.Instance.Register<IEditorService, EditorSeviceViaWin>();
            MyIoc.Instance.Register<IGuestLogic, GuestLogic>();
            MyIoc.Instance.Register<IMessenger>(() => Messenger.Default);
            MyIoc.Instance.Register<IGuestRepository, GuestRepository>();
            MyIoc.Instance.Register<DbContext, EventDbContext>();
        }
    }
}
