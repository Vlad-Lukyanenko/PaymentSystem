using AutoMapper;
using PaymentSystem.Contract.Models;

namespace PaymentSystem.Api.Profiles
{
    public class DomainToContract : Profile
    {
        public DomainToContract()
        {
            CreateMap<Domain.Card, Card>();
            CreateMap<Domain.BankAccount, BankAccount>();
            CreateMap<Domain.Client, Client>();
        }
    }
}
