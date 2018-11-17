using MassTransit;
using RabbitMQManager;
using RabbitMQManager.Log;
using RabbitMQMessageDefinition;
using System.Threading.Tasks;

namespace RabbitMQClient.Consumer
{
    public class RoadGateMessageConsumer : IConsumer<RoadGateMessage>
    {
        private Logger logger = new Logger();
        
        public async Task Consume(ConsumeContext<RoadGateMessage> context)
        {
            await Handle(context);
        }

        public async Task Handle(ConsumeContext<RoadGateMessage> context)
        {
            await Task.Factory.StartNew(() =>
            {
                string result = Newtonsoft.Json.JsonConvert.SerializeObject(context.Message);
                IocManager.Resolve<RabbitMQMessageTransferUtil>().broadcast(result);
                logger.Log(typeof(RoadGateMessageConsumer), "Handle", "RoadGateMessage", result, "");
            });
        }
    }
}
