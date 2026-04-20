using Messaging;
using System;
using System.Text.Json;
using Shared.Models;

namespace PaymentService.Consumers
{
    public class OrderCreatedConsumer : KafkaConsumer
    {
        protected override string Topic => "order-created";
        protected override string GroupId => "payment-group";

        private readonly KafkaProducer _producer;

        public OrderCreatedConsumer(KafkaProducer producer)
        {
            _producer = producer;
        }

        protected override void ProcessMessage(string message)
        {
            var evt = JsonSerializer.Deserialize<EventMessage>(message);

            Console.WriteLine("Payment Processing...");

            
            var fail = Random.Shared.Next(1, 10) < 3;

            if (fail)
            {
                Console.WriteLine("Payment Failed! Triggering compensation event...");

                var failedEvt = new EventMessage
                {
                    EventId = Guid.NewGuid(),
                    EventType = "PaymentFailed",
                    Timestamp = DateTime.UtcNow,
                    Data = evt.Data
                };

                _producer.PublishAsync("payment-failed", failedEvt).Wait();
                return;
            }

            Console.WriteLine("Payment Successful!");

            var paymentEvt = new EventMessage
            {
                EventId = Guid.NewGuid(),
                EventType = "PaymentSuccess",
                Timestamp = DateTime.UtcNow,
                Data = evt.Data
            };

            _producer.PublishAsync("payment-success", paymentEvt).Wait();
        }
    }
}