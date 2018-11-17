using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMessageDefinition
{

    public class TransferMessageEventArgs : EventArgs
    {
        /// <summary>
        /// 消息
        /// </summary>
        public string message { get; set; }
    }

    public delegate void TransferMessageDelegate(TransferMessageEventArgs eventArgs);

}
