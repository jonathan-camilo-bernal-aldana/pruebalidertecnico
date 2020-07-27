using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Transport;
using Apache.NMS.ActiveMQ.Transport.Tcp;
using Apache.NMS.ActiveMQ.Util;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Core.Interfaces.IActiveMq;

namespace Utilities.Core.Implementation.ActiveMq
{
    public class ActiveMq : IActiveMq
    {
        public readonly IConfiguration Configuration;

        public ActiveMq(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Connection ConnectionActiveMq()
        {
            //Url Amazon to connect to ActiveMQ
            Uri connecturi = new Uri(Configuration["ActiveMQ:UrlActiveMq"]);

            //Create transport SSL with protocol TLS
            ITransportFactory sslTransportFactory = new SslTransportFactory { SslProtocol = "TLS" };
            ITransport transport = sslTransportFactory.CreateTransport(connecturi);
            return new Connection(connecturi, transport, new IdGenerator())
            {
                UserName = Configuration["ActiveMQ:UserActiveMq"],
                Password = Configuration["ActiveMQ:PasswordActiveMq"]
            };
        }

        public void CreateProducer(string queue, object obj)
        {
            Connection connection = ConnectionActiveMq();

            ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
            IDestination dest = session.GetQueue(queue);

            using (IMessageProducer producer = session.CreateProducer(dest))
            {
                connection.Start();
                producer.DeliveryMode = MsgDeliveryMode.Persistent;

                IObjectMessage request = session.CreateObjectMessage(obj);

                producer.Send(request);
            }
        }

        public void CreateConsumer(string queue, MessageListener message)
        {
            Connection connection = ConnectionActiveMq();

            ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);

            IDestination dest = session.GetQueue(queue);

            IMessageConsumer consumer = session.CreateConsumer(dest);

            connection.Start();
            consumer.Listener += new MessageListener(message);
        }

    }
}
