﻿using MessageLibrary;
using System.Collections.ObjectModel;
using System.Windows;
using CommonLibrary;

namespace TelegramServer
{


    public partial class MainWindow : Window
    {
        private ObservableCollection<User> UsersOnline;
        private ObservableCollection<User> UsersOffline;
        private DataBaseContext DbContext;

        private TcpServerWrap Server;
        
        public MainWindow()
        {
            
            DbContext = new DataBaseContext();
  

            User newUser = new User()
            {
                Name = "Dmitro Osipov",
                DateRegistration = System.DateTime.Now,
                Email = "DmitroOsipov@gmail.com",
                Password = "aboba",
                ProfileDescription = "Ich bin",
            };

            DbContext.Users.Add(newUser);
          

            DbContext.SaveChanges();

           

            InitializeComponent();

            UsersOnline = new ObservableCollection<User>();
            UsersOffline = new ObservableCollection<User>();

            LB_UsersOffline.ItemsSource = UsersOffline;
            LB_UsersOnline.ItemsSource = UsersOnline;   


            Server = new TcpServerWrap();

            Server.Started += OnServerStarted;
            Server.Stopped += OnServerStopped;
            Server.MessageReceived += ClientMessageRecived;

        }


        private void BtnStartServer_Click(object sender, RoutedEventArgs e)
        {
            int port;
            if(int.TryParse(TB_ListenerPort.Text, out port) && port > 9999 && port < 100000)
            {
                BtnStartServer.IsEnabled = false;
                Server.Start(port, 1000);
            }
        }

        private void OnServerStarted(TcpServerWrap client)
        {
            Dispatcher.Invoke(() =>
            {
                BtnStopServer.IsEnabled = true;
            });
        }

        private void OnServerStopped(TcpServerWrap client)
        {
            Dispatcher.Invoke(() =>
            {
                BtnStopServer.IsEnabled = false;
                BtnStartServer.IsEnabled = true;
            });
        }

        private void ClientMessageRecived(TcpClientWrap client, Message msg)
        {
            

        }

    }
}
