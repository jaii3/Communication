﻿using Communication.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TopPortLib.Interfaces
{
    public interface IPigeonPort
    {
        IPhysicalPort PhysicalPort { get; set; }

        event RequestedDataEventHandler OnRequestedData;

        event RespondedDataEventHandler OnRespondedData;

        event ReceiveResponseDataEventHandler OnReceiveResponseData;
        Task StartAsync();

        Task StopAsync();

        Task<TRsp> RequestAsync<TReq, TRsp>(TReq req, int timeout = -1) where TReq : IByteStream;

        Task SendAsync<TReq>(TReq req, int timeout = -1) where TReq : IByteStream;
    }
}
