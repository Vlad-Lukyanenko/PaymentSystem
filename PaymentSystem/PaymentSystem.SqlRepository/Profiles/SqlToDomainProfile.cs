using AutoMapper;
using PaymentSystem.SqlRepository.Models;

namespace PaymentSystem.SqlRepository.Profiles
{
    public class SqlToDomainProfile : Profile
    {
        public SqlToDomainProfile()
        {
            CreateMap<Card, Domain.Card>();
            CreateMap<BankAccount, Domain.BankAccount>();
            CreateMap<Client, Domain.Client>();
            CreateMap<Transaction, Domain.Transaction>();
        }
    }
}