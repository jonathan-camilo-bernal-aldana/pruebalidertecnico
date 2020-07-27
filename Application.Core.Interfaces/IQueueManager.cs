using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Interfaces
{
    public interface IQueueManager
    {
        void StartEnqueue();
        void CreateConsumer(string queue);
    }
}
