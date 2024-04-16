using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Text;

namespace MatchService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageTestController : ControllerBase
    {
        private readonly IConnection _rabbitMQConnection;
        private readonly IModel _profileChannel;
        private readonly IModel _chatChannel;
        private readonly string _profileChannelName = "profile";
        private readonly string _chatChannelName = "chat";

        public MessageTestController(IConnection rabbitMQConnection)
        {
            _rabbitMQConnection = rabbitMQConnection;
            _profileChannel = _rabbitMQConnection.CreateModel();
            _profileChannel.QueueDeclare(queue: _profileChannelName, exclusive: false, autoDelete: false);
            _chatChannel = _rabbitMQConnection.CreateModel();
            _chatChannel.QueueDeclare(queue: _chatChannelName, exclusive: false, autoDelete: false);
        }

        [HttpPost("profile")]
        public IActionResult SendToProfile([FromBody] string message)
        {
            PublishMessage(_profileChannel, message, _profileChannelName);
            return Ok();
        }

        [HttpPost("chat")]
        public IActionResult SendToChat([FromBody] string message)
        {
            PublishMessage(_chatChannel, message, _chatChannelName);
            return Ok();
        }

        // get the logic away from the controller?
        void PublishMessage(IModel channel, string msg, string channelName)
        {
            string message = msg; // removed const identifier from message var
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: channelName,
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine($" [x] Sent {message}");
        }
    }
}