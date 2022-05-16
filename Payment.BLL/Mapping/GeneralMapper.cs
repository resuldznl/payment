using AutoMapper;
using Payment.Entities.ComplexType;
using Payment.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.BLL.Mapping
{
    public class GeneralMapper : Profile
    {
        public GeneralMapper()
        {
            CreateMap<CreateAccountVM, Account>();
            CreateMap<Account, CreateAccountVM>();
            CreateMap<Account, GetAccountVM>();
            CreateMap<GetAccountVM, Account>();
        }
    }
}
