using Entities.Models;
using Microsoft.Extensions.Configuration;
using RedisModule;
using System.Linq;

namespace Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        string RedisConString;
        CMS_DBContext _dbContext;
        RedisCacheManager redisCacheManager;

        public StaticDataService(CMS_DBContext dbContext, IConfiguration configuration)
        {
            RedisConString = configuration.GetConnectionString("RedisConString");
            _dbContext = dbContext;
            redisCacheManager = new RedisCacheManager(RedisConString);
        }

        public Entities.Models.StaticData[] GetEmailAndPhoneNum()
        {
            string KeyEmailAndPhone = "EmailAndPhone";
            Entities.Models.StaticData[] staticDatas = redisCacheManager.Get<Entities.Models.StaticData[]>(KeyEmailAndPhone);

            if (staticDatas != null && staticDatas.Count() > 0) return staticDatas;
            staticDatas = _dbContext.StaticDatas.Where(staticData => staticData.Key == "email" || staticData.Key == "phonenum").ToArray();

            redisCacheManager.Set(KeyEmailAndPhone, staticDatas);

            return staticDatas;
        }
    }
}
