using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisModule
{
    public class RedisCacheManager
    {
        public IDatabase _db;
        public string RedisConString { get; }
        public RedisCacheManager(string redisConString)
        {
            RedisClient redisClient = RedisClient.GetInstance(redisConString);
            _db = redisClient.Database();
        }

        public virtual T Get<T>(string key)
        {
            var rValue = _db.StringGet(key);

            if (!rValue.HasValue)
                return default(T);
            var result = Deserialize<T>(rValue);

            return result;
        }

        public bool HasKey(string key)
        {
            return _db.KeyExists(key);
        }

        public virtual void Set(string key, object data, int cacheTime = 30)
        {
            if (data == null)
                return;

            var entryBytes = Serialize(data);
            var expiresIn = TimeSpan.FromMinutes(cacheTime);

            if (cacheTime == 0)
            {
                _db.StringSet(key, entryBytes);
            }
            else
            {
                _db.StringSet(key, entryBytes, expiresIn);
            }
        }

        public virtual void Remove(string key)
        {
            _db.KeyDelete(key);
        }

        //public virtual void LPush(string key, object data)
        //{
        //    var entryBytes = Serialize(data);
        //    _db.ListLeftPush(key, entryBytes);            
        //}

        public virtual void SortedSetAdd(string key, object data)
        {
            var entryBytes = Serialize(data);
            _db.SortedSetAdd(key, entryBytes, 1);
        }

        public virtual void SortedSetRemove(string key, object data)
        {
            var entryBytes = Serialize(data);
            _db.SortedSetRemove(key, entryBytes);
        }

        //public virtual void ListRemove(string key, object data)
        //{
        //    var entryBytes = Serialize(data);
        //    _db.ListRemove(key, entryBytes);
        //}

        public List<object> Sort(string key)
        {
            List<object> lst = new List<object>();

            RedisValue[] redisValues = _db.Sort(key);

            for (int i = 0; i < redisValues.Length; i++)
            {
                RedisValue value = redisValues[i];
                lst.Add(Deserialize<object>(value));
            }

            return lst;
        }

        public List<string> Keys(string pattern)
        {
            RedisClient redisClient = RedisClient.GetInstance(RedisConString);

            List<string> lst = new List<string>();

            foreach (var ep in redisClient.GetEndpoints())
            {
                var server = redisClient.Server(ep);

                var keys = server.Keys(pattern: "*" + pattern + "*");

                var lstKey = keys.ToList();

                foreach (var p in lstKey)
                {
                    string key = p.ToString();

                    if (!lst.Contains(key))
                    {
                        lst.Add(key);
                    }
                }
            }

            return lst;
        }

        protected virtual byte[] Serialize(object item)
        {
            var jsonString = JsonConvert.SerializeObject(item);
            return Encoding.UTF8.GetBytes(jsonString);
        }
        protected virtual T Deserialize<T>(byte[] serializedObject)
        {
            if (serializedObject == null)
                return default(T);

            var jsonString = Encoding.UTF8.GetString(serializedObject);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
