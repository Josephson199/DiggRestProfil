using Confluent.Kafka;
using DiggRestProfil.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiggRestProfil.Infrastructure
{
    public class KafkaNotifier : INotifier
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private readonly ProducerConfig _producerConfig;

        public KafkaNotifier(ProducerConfig producerConfig, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            _producerConfig = producerConfig;

            if (jsonSerializerOptions != null)
            {
                _jsonSerializerOptions = jsonSerializerOptions;
            }
        }

        public async Task Notify<T>(T message, string topic)
        {
            var json = JsonSerializer.Serialize(message, _jsonSerializerOptions);

            //var config = new ProducerConfig
            //{
            //    BootstrapServers = "localhost:9092",
            //    ClientId = nameof(DiggRestProfil)
            //};

            using var producer = new ProducerBuilder<Null, string>(_producerConfig).Build();

            var r = await producer.ProduceAsync(topic, new Message<Null, string> { Value = json });
        }
    }
}
