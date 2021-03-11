using CommonServiceLocator;
using EventManagement.Data.Models;
using EventManagement.Logic;
using EventManagement.Logic.Interfaces;
using EventManagement.Repository;
using EventManagement.WPF.UI;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EventManagement.WPF
{
    /// <summary>
    /// This class mantains the singloton behaviour.
    /// </summary>
    class MyIoc : SimpleIoc, IServiceLocator
    {
        public static MyIoc Instance { get; private set; } = new MyIoc();
    }
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// This is a constructor which make the object of the required classes.
        /// </summary>
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => MyIoc.Instance);
            MyIoc.Instance.Register<IEditorService, EditorSeviceViaWin>();
            MyIoc.Instance.Register<IGuestLogic, GuestLogic>();
            MyIoc.Instance.Register<IMessenger>(()=> Messenger.Default);
            MyIoc.Instance.Register<IGuestRepository, GuestRepository>();
            MyIoc.Instance.Register<DbContext, EventDbContext>();

        }
    }
}
