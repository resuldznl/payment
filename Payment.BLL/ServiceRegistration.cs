using Microsoft.Extensions.DependencyInjection;
using Payment.BLL.Abstract;
using Payment.BLL.Concrete;
using Payment.DAL.Abstract;
using Payment.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Payment.BLL
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountDal, AccountDal>();
            services.AddScoped<ITransactionHistoryDal, TransactionHistoryDal>();
        }
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransactionHistoryService, TransactionHistoryService>();
        }
        
    }
}
