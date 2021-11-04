using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Domain.PaymentInfos.Repositories;
namespace EmprendeUCR.Application.PaymentInfos.Implementations
{
    public class CardPaymentInfoService : ICardPaymentInfoService
    {
        private readonly ICardPaymentInfoRepository _cardPaymentInfoRepository;
        public CardPaymentInfoService(ICardPaymentInfoRepository cardPaymentInfoRepository)
        {
            _cardPaymentInfoRepository = cardPaymentInfoRepository;
        }
        public async Task AddPaymentInfoAsync(CardPaymentInfo cardPaymentInfo)
        {
            await _cardPaymentInfoRepository.AddPaymentInfo(cardPaymentInfo);
        }
        public async Task<CardPaymentInfo?> GetCardPaymentInfoByIdAsync(string accountNumber)
        {
            return await _cardPaymentInfoRepository.GetByIdAsync(accountNumber);
        }

        public async Task<CardPaymentInfo?> GetCardPaymentInfoByPaymentInfoID(int paymentInfoID)
        {
            return await _cardPaymentInfoRepository.GetByPaymentInfoID(paymentInfoID);
        }

        public async Task<IEnumerable<CardPaymentInfo>> GetCardPaymentInfosAsync()
        {
            return await _cardPaymentInfoRepository.GetAllAsync();
        }

        public async Task<List<CardPaymentInfo>?> GetCardPaymentInfosByPaymentInfoIDAsync(List<HasPaymentInfo> list)
        {
            List<CardPaymentInfo> asociateCards = new();
            for (int i = 0; i < list.Length(); i++)
            {
                var add = await GetCardPaymentInfoByPaymentInfoID(list[i].Payment_Info_ID);
                if (add != null)
                {
                    asociateCards.Add(add);
                }
            }
            return asociateCards;
        }

    }
}