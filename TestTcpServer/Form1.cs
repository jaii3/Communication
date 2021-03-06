﻿using Communication.Bus;
using Communication.Bus.PhysicalPort;
using Communication.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTcpServer
{
    public partial class Form1 : Form
    {
        ITcpServer tcpServer;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            tcpServer = new TcpServer("127.0.0.1", 7779);
            await tcpServer.StartAsync();
            tcpServer.OnReceiveOriginalDataFromTcpClient += TcpServer_ReceiveOriginalDataFromTcpClient;
            tcpServer.OnClientConnect += TcpServer_ClientConnect;
            tcpServer.OnClientDisconnect += TcpServer_ClientDisconnect;
        }

        private async Task TcpServer_ClientDisconnect(int clientId)
        {
        }

        private async Task TcpServer_ClientConnect(string hostName, int port, int clientId)
        {
        }

        private async Task TcpServer_ReceiveOriginalDataFromTcpClient(byte[] data, int size, int clientId)
        {
            var tmp = new byte[size];
            Array.Copy(data,0,tmp,0,size);
            await tcpServer.SendDataAsync(clientId, tmp);
            if (data[0] == 0x89)
            {
                await tcpServer.DisconnectClientAsync(clientId);
            }
        }
    }
}
