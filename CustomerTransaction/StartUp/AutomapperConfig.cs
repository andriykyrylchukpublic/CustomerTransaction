using System;
using CustomerTransaction.Models;
using CustomerTransaction.SharedEntities.Models;

namespace CustomerTransaction.StartUp
{
    public static class AutomapperConfig
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Customer, CustomerOutputDto>();
                cfg.CreateMap<Transaction, TransactionDto>()
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.GetName(typeof(Status), src.Status)))
                    .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount.ToString("F")));

                cfg.CreateMap<Inquiry, RequestData>();

            });
        }
    }
}
