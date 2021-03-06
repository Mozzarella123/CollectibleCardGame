﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BaseNetworkArchitecture.Common;
using BaseNetworkArchitecture.Server;
using Server.Controllers;
using Server.Network.Models;
using Server.Unity;

namespace Server.Network.Controllers
{
    public class ServerController
    {
        private readonly IServer _server;
        private readonly ConnectedClientsRepositoryController _clientsRepositoryController;

        public ServerController(IServer server,ConnectedClientsRepositoryController clientsRepositoryController)
        {
            _server = server;
            _server.ClientConnected += OnClientConnected;
            _clientsRepositoryController = clientsRepositoryController;
        }

        private void OnClientConnected(object sender, ClientConnectedEventArgs e)
        {
            Client client = new Client(e.ClientConnection);
            _clientsRepositoryController.Add(client);
            UnityKernel.Get<ILogger>().Print("Client connected");
        }

        public void Start()
        {
            _server.Start();
        }

        public void Stop()
        {
            _server.Stop();
        }
    }
}
