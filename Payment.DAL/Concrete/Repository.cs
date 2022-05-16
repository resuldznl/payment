using Microsoft.Extensions.Caching.Memory;
using Payment.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        string key = typeof(T).Name.ToLowerInvariant();
        private readonly IMemoryCache memoryCache;
        public Repository(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public bool Add(T model)
        {
            try
            {
                var datas = GetDatas();
                datas.Add(model);
                memoryCache.Set(key, datas);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }

        public T Get(Func<T, bool> filter)
           => GetDatas().FirstOrDefault(filter);

        public List<T> GetAll()
           => GetDatas();
        public List<T> GetAll(Func<T,bool> filter)
           => GetDatas().Where(filter).ToList();
        public List<T> GetDatas()
        {
            if (!memoryCache.TryGetValue(key, out List<T> result))
            {
                result = new();
                memoryCache.Set(key, result);
            }

            return result;
        }

        public bool Update(T model)
        {
            try
            {
                var datas = GetDatas();
                datas.Remove(model);
                datas.Add(model);
                memoryCache.Set(key, datas);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
