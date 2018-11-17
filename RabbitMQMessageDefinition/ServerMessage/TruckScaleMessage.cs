using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMessageDefinition
{
    public class TruckScaleMessage : BaseMessage
    {
        public string carno { get; set; }

        public string weight { get; set; }
    }
}
