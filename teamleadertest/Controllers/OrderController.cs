using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core.Interfaces;
using Domain.Core.DTO;
using Infrastructure.Core.Interfaces.IContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DistributedServices.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManagementApplication _OrderApplication;

        public OrderController(IOrderManagementApplication OrderApplication) {
            _OrderApplication = OrderApplication;
        }

        [HttpGet]
        public ActionResult<List<Ordenes>> Getorders() {
            
            
            var response = _OrderApplication.GetOrders();
            return Ok(response);            
        }

        [HttpPost]
        public ActionResult<bool> CreateOrder(Ordenes orden)
        {
            var response = _OrderApplication.CreateOrder(orden);
            return Ok(response);
        }
    }
}
