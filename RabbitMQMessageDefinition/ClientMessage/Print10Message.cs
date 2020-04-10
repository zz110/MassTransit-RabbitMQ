using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMessageDefinition
{
    public class Print10Message : BaseMessage
    {
        public string carno { get; set; }

        public string content { get; set; }
    }
}
