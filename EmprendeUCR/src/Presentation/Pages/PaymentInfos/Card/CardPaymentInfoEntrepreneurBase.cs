using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Navigations;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using System.Collections.Generic;

namespace EmprendeUCR.Presentation.Pages.PaymentInfos
{
    public class CardPaymentInfoEntrepreneurBase : ComponentBase
    {
        protected string Status = null;
        protected string DisabledCards = null;
        protected string ActiveCards = null;
        private string IbanAccount = "CR";
        protected IEnumerable<CardPaymentInfo> _cardPaymentInfoList;
        protected SfGrid<CardPaymentInfo> CardPaymentInfoGrid;
        protected bool AddCardDialogVisible = false;
        protected bool AddDisabled = true;
        protected bool ConfirmationDialogVisible { get; set; } = false;
        protected bool PaymentMethodDisabled = false;
        protected int PaymentInfoIdToRemove = -1;
        protected string CardBrand = null;
        protected List<string> CardBrands = new List<string>();
        protected string AddedCardIban {
            get {
                return IbanAccount;
            }
            set {
                IbanAccount = value;
                if (value.Length == 22 && ValidateIbanAccount())
                {
                    AddDisabled = false;
                }
                else {
                    AddDisabled = true;
                }
            }
        }
        protected bool ValidateIbanAccount() {
            return _cardPaymentInfoList.Find(cpi => cpi.Account_Number == IbanAccount).Count() == 0;
        }
        public void CardCommandClicked(CommandClickEventArgs<CardPaymentInfo> args)
        {
            if (args.CommandColumn.Title == "Editar")
            {
            }
            else if (args.CommandColumn.Title == "Eliminar")
            {
                PaymentInfoIdToRemove = args.RowData.Payment_Info_ID;
                ShowConfirmationDialog();
            }
        }
        protected void ShowAddCardIbanDialog()
        {
            AddCardDialogVisible = true;
        }
        protected void CloseAddCardIbanDialog()
        {
            AddedCardIban = "CR";
            AddCardDialogVisible = false;
        }
        protected void ShowConfirmationDialog()
        {
            ConfirmationDialogVisible = true;
        }
        protected void CloseConfirmationDialog()
        {
            PaymentInfoIdToRemove = -1;
            ConfirmationDialogVisible = false;
        }
    }
}
