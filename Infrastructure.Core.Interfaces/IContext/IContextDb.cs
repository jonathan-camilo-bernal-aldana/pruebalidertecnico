using Domain.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Core.Interfaces.IContext
{
    public interface IContextDb
    {
        List<Ordenes> Get();
        Ordenes GetById(string id);
        Ordenes Create(Ordenes book);
        void Update(string id, Ordenes orden);
        void Delete(Ordenes orden);
        void DeleteById(string id);

    }
}
