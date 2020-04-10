using MassTransit;
using RabbitMQMessageDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQServer.Consumer
{
    public class PrintFaultMessageConsumer : IConsumer<Fault<PrintMessage>>
    {
        public async Task Consume(ConsumeContext<Fault<PrintMessage>> context)
        {
            await Task.Factory.StartNew(() =>
            {


                int i1 = 100;

                Console.WriteLine(i1);

                Console.Beep();
                    
                
                
            
            });
        }
    }
}
