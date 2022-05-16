using Microsoft.Extensions.Caching.Memory;
using Payment.DAL.Abstract;
using Payment.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Concrete
{
    public class AccountDal : Repository<Account>, IAccountDal
    {
        public AccountDal(IMemoryCache memoryCache) : base(memoryCache)
        { }
    }
}
