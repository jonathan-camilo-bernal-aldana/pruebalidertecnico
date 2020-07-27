using Apache.NMS;
using Utilities.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Core.Interfaces.IActiveMq;
using Application.Core.Interfaces;
using Domain.Core.DTO;
using Infrastructure.Core.Interfaces.IContext;
using System.Threading;
using Services.Core.Interfaces;

namespace Application.Core.Implementation
{
    public class QueueManager: IQueueManager
    {
        
        private readonly IConfiguration _configuration;
        public readonly IActiveMq ActiveMq;
        private readonly IContextDb _dbContext;
        private readonly IServiceSap _serviceSap;
        protected static TimeSpan ReceiveTimeout = TimeSpan.FromSeconds(15);
        protected static AutoResetEvent Semaphore = new AutoResetEvent(false);
        public QueueManager(IConfiguration configuration, IActiveMq activeMq, IContextDb context, IServiceSap ServiceSap)
        {
            ActiveMq = activeMq;
            _configuration = configuration;
            _dbContext = context;
            _serviceSap = ServiceSap;
        }

        public void CreateConsumer(string queue)
        {
            ActiveMq.CreateConsumer(queue, OnMessageCreateOrder);
        }

        public void OnMessageCreateOrder(IMessage receivedMsg)
        {
          
            Exception exception = null;
            try
            {
                IObjectMessage message = receivedMsg as IObjectMessage;

                //Request Handle 
                Ordenes request = message?.Body as Ordenes;


                //Save BD
                var response =_dbContext.Create(request);

                //Service SAP
                try
                {
                    _serviceSap.CreateOrderSap(response);
                }
                catch (Exception)
                {

                }


                // Wait for the message
                Semaphore.WaitOne((int)ReceiveTimeout.TotalMilliseconds, true);
                Semaphore.Set(); Thread.Sleep((int)ReceiveTimeout.TotalMilliseconds);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }

        public void StartEnqueue()
        {
            CreateConsumer(_configuration.GetSection("QueueNames:OrderCreate").Value);
        }
    }
}
