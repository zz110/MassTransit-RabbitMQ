﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMessageDefinition
{
    public class CameraMessage : BaseMessage
    {
        public string number { get; set; }

        public string content { get; set; }
    }
}
