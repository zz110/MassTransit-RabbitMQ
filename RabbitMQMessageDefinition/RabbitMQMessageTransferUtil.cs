using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMessageDefinition
{
    public class RabbitMQMessageTransferUtil
    {
        public event TransferMessageDelegate TransferMessageHandler;

        /// <summary>
        /// 发布反馈消息
        /// </summary>
        /// <param name="message"></param>
        public void broadcast(string message)
        {
            if (TransferMessageHandler != null)
            {
                var eventArgs = new TransferMessageEventArgs
                {
                    message = message
                };
                TransferMessageHandler.Invoke(eventArgs);
            }
        }
    }
}
