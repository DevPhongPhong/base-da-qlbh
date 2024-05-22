using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Net;

namespace RedisModule
{
    public class RedisClient : IDisposable
    {
        private ConnectionMultiplexer _connection;
        private string RedisConString { get; set; }
        public RedisClient(string redisConString)
        {
            RedisConString = redisConString;
            Connect();
        }

        public void Connect()
        {
            _connection = ConnectionMultiplexer.Connect(RedisConString);
        }

        public void Close()
        {
            if (_connection != null)
            {
                if (_connection.IsConnected)
                {
                    _connection.Close();
                }

                _connection.Dispose();
            }
        }

        public void Subscribe(string channel, Action<RedisChannel, RedisValue> handler)
        {
            RedisChannel redisChannel = new RedisChannel(channel, RedisChannel.PatternMode.Auto);
            _connection.GetSubscriber().Subscribe(redisChannel, handler);
        }

        public void Publish(string channel, string msg)
        {
            RedisChannel redisChannel = new RedisChannel(channel, RedisChannel.PatternMode.Auto);

            ISubscriber pubsub = _connection.GetSubscriber();
            pubsub.Publish(redisChannel, msg);
        }

        public void UnSubscribe(bool all, string channel)
        {
            ISubscriber pubsub = _connection.GetSubscriber();

            if (all)
            {
                pubsub.UnsubscribeAll();
            }
            else
            {
                RedisChannel redisChannel = new RedisChannel(channel, RedisChannel.PatternMode.Auto);
                pubsub.Unsubscribe(redisChannel);
            }
        }

        public IList<string> GetChannels(string channel)
        {
            var endPoints = _connection.GetEndPoints();

            var lst = new List<string>();

            foreach (var endPoint in endPoints)
            {
                IServer server=_connection.GetServer(endPoint);
                RedisChannel[] redisChannels = server.SubscriptionChannels(channel);

                foreach (var rd in redisChannels)
                {
                    lst.Add(rd.ToString());
                }
            }

            return lst;
        }

        public IDatabase Database(int? db = null)
        {
            return _connection.GetDatabase(db ?? -1); //_settings.DefaultDb);
        }

        public EndPoint[] GetEndpoints()
        {
            return _connection.GetEndPoints();
        }

        public IServer Server(EndPoint endPoint)
        {
            return _connection.GetServer(endPoint);
        }

        private static RedisClient _redisClient;

        public static RedisClient GetInstance(string redisConString)
        {
            if (_redisClient == null)
            {
                _redisClient = new RedisClient(redisConString);
            }

            return _redisClient;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Close();                
            }

        }
    }
}
