

using System;
using CustomerTransaction.Models;
using CustomerTransaction.SharedEntities.Models;

namespace CustomerTransaction
{
    public static class AutomapperConfig
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<Transaction, TransactionDto>()
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.GetName(typeof(Status), src.Status)));
            });
        }
    }
}
