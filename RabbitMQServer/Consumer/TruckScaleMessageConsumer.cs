using MassTransit;
using RabbitMQManager;
using RabbitMQManager.Log;
using RabbitMQMessageDefinition;
using System.Threading.Tasks;

namespace RabbitMQServer.Consumer
{
    public class TruckScaleMessageConsumer : IConsumer<TruckScaleMessage>
    {
        private Logger logger = new Logger();

        public async Task Consume(ConsumeContext<TruckScaleMessage> context)
        {
            await Handle(context);
        }

        public async Task Handle(ConsumeContext<TruckScaleMessage> context)
        {
            await Task.Factory.StartNew(() =>
            {
                string result = Newtonsoft.Json.JsonConvert.SerializeObject(context.Message);
                IocManager.Resolve<RabbitMQMessageTransferUtil>().broadcast(result);
                logger.Log(typeof(TruckScaleMessageConsumer), "Handle", "TruckScaleMessageConsumer",
                    result, "");
            });
        }
    }
}
