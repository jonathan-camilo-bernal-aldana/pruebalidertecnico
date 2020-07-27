using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Core.Interfaces.IActiveMq
{
    public interface IActiveMq
    {
        Connection ConnectionActiveMq();
        void CreateProducer(string queue, object obj);
        void CreateConsumer(string queue, MessageListener message);

    }
}
