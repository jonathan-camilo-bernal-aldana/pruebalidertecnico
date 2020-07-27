using Domain.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Interfaces
{
    public interface IOrderManagementApplication
    {
        bool CreateOrder(Ordenes orden);
        List<Ordenes> GetOrders();
    }
}
