using AutoMapper;
using PaymentSystem.SqlRepository.Models;

namespace PaymentSystem.SqlRepository.Profiles
{
    public class DomainToSqlProfile : Profile
    {
        public DomainToSqlProfile()
        {
            CreateMap<Domain.Card, Card>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Domain.BankAccount, BankAccount>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Domain.Client, Client>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Domain.Transaction, Transaction>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}