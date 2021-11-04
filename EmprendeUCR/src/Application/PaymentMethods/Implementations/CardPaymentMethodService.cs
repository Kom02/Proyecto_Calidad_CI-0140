using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using EmprendeUCR.Domain.PaymentMethods.Repositories;
namespace EmprendeUCR.Application.PaymentMethods.Implementations
{
    public class CardPaymentMethodService : ICardPaymentMethodService
    {
        private readonly ICardPaymentMethodRepository _cardPaymentMethodRepository;
        public CardPaymentMethodService(ICardPaymentMethodRepository cardPaymentMethodRepository)
        {
            _cardPaymentMethodRepository = cardPaymentMethodRepository;
        }
        public async Task<CardPaymentMethod?> GetPaymentMethodByIdAsync(string name)
        {
            return await _cardPaymentMethodRepository.GetByIdAsync(name);
        }
        public async Task<IEnumerable<CardPaymentMethod>> GetPaymentMethodsAsync()
        {
            return await _cardPaymentMethodRepository.GetAllAsync();
        }
        public async Task ChangeStatusToPaymentMethodAsync(CardPaymentMethod cardPaymentMethod)
        {
            cardPaymentMethod.ChangeStatus();
            await _cardPaymentMethodRepository.SaveAsync(cardPaymentMethod);
        }
        public async Task AddPaymentInfoToPaymentMethodAsync(CardPaymentMethod cardPaymentMethod, CardPaymentInfo cardPaymentInfo)
        {
            cardPaymentMethod.AddCardPaymentInfo(cardPaymentInfo);
            await _cardPaymentMethodRepository.SaveAsync(cardPaymentMethod);
        }
        public async Task DeletePaymentInfoAndRemoveFromPaymentMethodAsync(CardPaymentMethod cardPaymentMethod, CardPaymentInfo cardPaymentInfo)
        {
            cardPaymentMethod.RemovePhonePaymentInfo(cardPaymentInfo);
            await _cardPaymentMethodRepository.DeletePaymentInformation(cardPaymentInfo);
            await _cardPaymentMethodRepository.SaveAsync(cardPaymentMethod);
        }
    }
}