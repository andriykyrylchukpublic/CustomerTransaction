using System;
using AutoMapper;
using CustomerTransaction.Models;
using CustomerTransaction.SharedEntities.Models;

namespace CustomerTransaction.StartUp
{
    public class AutomapperProfile: Profile
    {

        public AutomapperProfile()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<Customer, CustomerOutputDto>();
            CreateMap<Transaction, TransactionDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.GetName(typeof(Status), src.Status)))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount.ToString("F")));
            CreateMap<Inquiry, RequestData>();
        }
    }
}
