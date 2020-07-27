using Application.Core.Interfaces;
using Domain.Core.DTO;
using Infrastructure.Core.Interfaces.IContext;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Core.Interfaces.IActiveMq;

namespace Application.Core.Implementation
{
    public class OrderManagementApplication : IOrderManagementApplication
    {
        private readonly IContextDb _dbContext;
        private readonly IConfiguration _configuration;
        public readonly IActiveMq ActiveMq;
        public OrderManagementApplication(IContextDb context, IConfiguration configuration, IActiveMq activeMq)
        {
            _dbContext = context;
            ActiveMq = activeMq;
            _configuration = configuration;
        }
        public bool CreateOrder(Ordenes orden)
        {
            try
            {
                ActiveMq.CreateProducer(_configuration.GetSection("QueueNames:OrderCreate").Value, orden);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public List<Ordenes> GetOrders()
        {
            return _dbContext.Get();
        }
    }
}
