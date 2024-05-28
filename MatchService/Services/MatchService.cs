using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;
using System.Text.Json;
using MatchServiceApp.Models;
using RabbitMQ.Client;

namespace MatchServiceApp.Services
{
    public enum CommunicationType
    {
        Messaging,
        HTTP,
    }

    public enum YesOrNo
    {
        y, 
        n,
    }

    public class MatchService
    {
        private readonly HttpClient _httpClient;
        private readonly IConnection _rabbitMQConnection;
        private readonly IModel _profileChannel;
        private readonly string _profileChannelName = "profile";

        public MatchService(IConnection rabbitMQConnection)
        {
            _httpClient = new HttpClient();
            _rabbitMQConnection = rabbitMQConnection;
            _profileChannel = _rabbitMQConnection.CreateModel();
            _profileChannel.QueueDeclare(queue: _profileChannelName, exclusive: false, autoDelete: false);
        }

        public void AddIdToSwipedNo(int swiperID, int swipedID, CommunicationType comType = CommunicationType.Messaging)
        {
            if (comType == CommunicationType.Messaging)
            {
                byte[] body = Encoding.UTF8.GetBytes(FormatMessage(swiperID, swipedID, YesOrNo.n));
                _profileChannel.BasicPublish(exchange: "", routingKey: _profileChannelName, basicProperties: null, body: body);
                Console.WriteLine($"Sent request to add ID: {swipedID} to SwipedNo array for user with ID: {swiperID}");
            }
            else if (comType == CommunicationType.HTTP)
            {
                throw new NotImplementedException();
            }
        }

        public void AddIdToSwipedYes(int swiperID, int swipedID, CommunicationType comType = CommunicationType.Messaging)
        {
            if (comType == CommunicationType.Messaging)
            {
                string message = $"{swiperID}:{swipedID}:y";
                byte[] body = Encoding.UTF8.GetBytes(message);
                _profileChannel.BasicPublish(exchange: "", routingKey: _profileChannelName, basicProperties: null, body: body);
                Console.WriteLine($"Sent request to add ID: {swipedID} to SwipedNo array for user with ID: {swiperID}");
            }
            else if (comType == CommunicationType.HTTP)
            {
                throw new NotImplementedException();
            }
        }

        public string FormatMessage(int swiperID, int swipedID, YesOrNo YoN)
        {
            string message = $"{swiperID}:{swipedID}:{YoN.ToString()}";
            return message;
        }
    }
}
