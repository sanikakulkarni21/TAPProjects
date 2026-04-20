using Messaging;
namespace NotificationService.Consumers
{
    public class StockConsumer : KafkaConsumer
    {
        protected override string Topic => "stock-reserved";
        protected override string GroupId => "notification-group";
        protected override void ProcessMessage(string message)
        {
            System.Console.WriteLine("Email Sent to Customer");
            System.Console.WriteLine(message);
        }
    }
}
