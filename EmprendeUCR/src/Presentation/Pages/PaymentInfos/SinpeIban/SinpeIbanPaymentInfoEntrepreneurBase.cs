using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Navigations;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using System.Collections.Generic;

namespace EmprendeUCR.Presentation.Pages.PaymentInfos
{
    public class SinpeIbanPaymentInfoEntrepreneurBase : ComponentBase
    {
        private string IbanAccount = "CR";
        protected IEnumerable<SinpeIbanPaymentInfo> _sinpeIbanPaymentInfoList;
        protected SfGrid<SinpeIbanPaymentInfo> SinpeIbanPaymentInfoGrid;
        protected bool AddDisabled = true;
        protected bool AddSinpeIbanDialogVisible = false;
        protected bool ConfirmationDialogVisible { get; set; } = false;
        protected const string SINPE_IBAN = "SINPE";
        protected int PaymentInfoIdToRemove = -1;
        protected bool PaymentMethodDisabled = false;
        protected string AddedSinpeIban
        {
            get
            {
                return IbanAccount;
            }
            set
            {
                IbanAccount = value;
                if (value.Length == 22 && ValidateIbanAccount())
                {
                    AddDisabled = false;
                }
                else
                {
                    AddDisabled = true;
                }
            }
        }
        protected bool ValidateIbanAccount()
        {
            return _sinpeIbanPaymentInfoList.Find(spi => spi.Account_Number == IbanAccount).Count() == 0;
        }
        public void SinpeIbanCommandClicked(CommandClickEventArgs<SinpeIbanPaymentInfo> args)
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
        protected void ShowAddSinpeIbanDialog()
        {
            AddSinpeIbanDialogVisible = true;
        }

        protected void CloseAddSinpeIbanDialog()
        {
            AddedSinpeIban = "CR";
            AddSinpeIbanDialogVisible = false;
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