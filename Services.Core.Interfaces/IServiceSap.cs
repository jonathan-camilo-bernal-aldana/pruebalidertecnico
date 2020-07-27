using Domain.Core.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core.Interfaces
{
    public interface IServiceSap
    {
        Task<HttpStatusCode> CreateOrderSap(Ordenes order);
    }
}
