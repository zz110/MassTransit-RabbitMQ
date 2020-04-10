using MassTransit;
using RabbitMQManager;
using RabbitMQManager.Log;
using RabbitMQMessageDefinition;
using System;
using System.Threading.Tasks;

namespace RabbitMQClient.Consumer
{
    public class PrintMessageConsumer : IConsumer<PrintMessage>
    {
        private Logger logger = new Logger();


        public async Task Consume(ConsumeContext<PrintMessage> context)
        {
            await Handle(context);
        }

        public async Task Handle(ConsumeContext<PrintMessage> context)
        {
            await Task.Factory.StartNew(() =>
            {


                string result = Newtonsoft.Json.JsonConvert.SerializeObject(context.Message);
                IocManager.Resolve<RabbitMQMessageTransferUtil>().broadcast(result);
                logger.Log(typeof(PrintMessageConsumer), "Handle", "PrintMessage",
                    result, "");


            });
        }
    }
}
