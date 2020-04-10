using MassTransit;
using RabbitMQManager;
using RabbitMQManager.Log;
using RabbitMQMessageDefinition;
using System;
using System.Threading.Tasks;

namespace RabbitMQClient.Consumer
{
    public class Print10MessageConsumer : IConsumer<Print10Message>
    {
        private Logger logger = new Logger();


        public async Task Consume(ConsumeContext<Print10Message> context)
        {
            await Handle(context);
        }

        public async Task Handle(ConsumeContext<Print10Message> context)
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
