using Messaging;
using System;
using System.Text.Json;
using Shared.Models;
namespace InventoryService.Consumers
{
    public class PaymentSuccessConsumer : KafkaConsumer
    {
        protected override string Topic => "payment-success";
        protected override string GroupId => "inventory-group";
        private readonly KafkaProducer _producer;
        public PaymentSuccessConsumer(KafkaProducer producer)
        {
            _producer = producer;
        }
        protected override void ProcessMessage(string message)
        {
            var evt = JsonSerializer.Deserialize<EventMessage>(message);
            var stockEvt = new EventMessage
            {
                EventId = Guid.NewGuid(),
                EventType = "StockReserved",
                Timestamp = DateTime.UtcNow,
                Data = evt.Data
            };
            _producer.PublishAsync("stock-reserved", stockEvt).Wait();
        }
    }
}
