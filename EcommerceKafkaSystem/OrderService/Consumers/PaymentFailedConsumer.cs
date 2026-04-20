using Messaging;
namespace OrderService.Consumers
{
    public class PaymentFailedConsumer : KafkaConsumer
    {
        protected override string Topic => "payment-failed";
        protected override string GroupId => "order-cancel-group";
        protected override void ProcessMessage(string message)
        {
            System.Console.WriteLine("Order Cancelled");
            System.Console.WriteLine(message);
        }
    }
}
