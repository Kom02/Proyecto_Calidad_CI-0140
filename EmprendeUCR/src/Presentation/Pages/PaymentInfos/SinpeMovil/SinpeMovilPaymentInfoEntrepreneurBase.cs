using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using System.Collections.Generic;
using System;

namespace EmprendeUCR.Presentation.Pages.PaymentInfos
{
    public class SinpeMovilPaymentInfoEntrepreneurBase : ComponentBase
    {
        private string Number = "";
        protected IEnumerable<SinpeMovilPaymentInfo> _sinpeMovilPaymentInfoList;
        protected SfGrid<SinpeMovilPaymentInfo> SinpeMovilPaymentInfoGrid;
        protected bool AddDisabled = true;
        protected bool AddSinpePhoneNumberDialogVisible = false;
        protected bool ConfirmationDialogVisible { get; set; } = false;
        protected const string SINPE_MOVIL = "SINPE Movil";
        protected int PaymentInfoIdToRemove = -1;
        protected bool PaymentMethodDisabled = false;
        protected string AddedNumber
        {
            get
            {
                return Number;
            }
            set
            {
                Number = value;
                if (value == null)
                {
                    AddDisabled = true;
                }
                else
                {
                    if (value.Length == 8 && ValidatePhoneNumber())
                    {
                        AddDisabled = false;
                    }
                    else
                    {
                        AddDisabled = true;
                    }
                }
            }
        }
        protected bool ValidatePhoneNumber()
        {
            if (Number == "") {
                return false;
            }
            return _sinpeMovilPaymentInfoList.Find(spi => spi.Phone_Number == int.Parse(Number)).Count() == 0;
        }
        public void SinpeMovilCommandClicked(CommandClickEventArgs<SinpeMovilPaymentInfo> args)
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
        protected void ShowAddSinpePhoneNumberDialog()
        {
            AddSinpePhoneNumberDialogVisible = true;
        }
        protected void CloseAddSinpePhoneNumberDialog()
        {
            AddedNumber = "";
            AddSinpePhoneNumberDialogVisible = false;
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
