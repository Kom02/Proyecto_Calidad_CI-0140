using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Reports.Entities;

namespace EmprendeUCR.Application.Reports.Implementations
{
    public class CreateReportService :IReportService
    {
        private readonly IReportService _context;
        public CreateReportService(IReportService context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Report>> GetReportsAsync()
        {
            return await _context.GetReportsAsync();
        }
        public async Task SaveAsync()
        {
            await _context.SaveAsync();
        }
        public async Task<Report?> GetReportByIdAsync(int id)
        {
            return await _context.GetReportByIdAsync(id);
        }
        public async Task AddReportAsync(Report report)
        {
            await _context.AddReportAsync(report);
        }
        /*
         * 
         * Private Variables
         * 
         * 
         */
        /*
         * 
         * Private Variables
         * 
         */
        private bool TitleNotValid;
        private bool DescriptionNotValid;
        public bool AddDialogVisible;
        public string Title;
        public string Content;
        public bool ContentNotValid;
        public bool CreateReportDisabled;
        public string user;

        /**
         * @brief Open a Popup with the form to add a category name
         * @details the dialog was made with a SfDialog with HTML
         * @param
         * @return
         */
        public void OpenCreateReportDialog()
        {
            this.AddDialogVisible = true;
            this.CreateReportDisabled = true;
        }


        /**
        * @brief Closes the Popup that allows the adding of a new category
        * @details The dialog was made with a SfDialog with HTML
        * @param 
        * @return
        */
        public void CloseCreateReportDialog()
        {
            this.AddDialogVisible = false;
            ResetCreateReportData();
        }

        /**
        * @brief Adds a new category to the database and reflects the changes to the site
        * @details calls the service InsertCategoryAsync(Category); to add the category, and getParentId(TitleDad) to get its parent, add category only if the category values are valid
        * @param 
        * @return 
        */
        public async void CreateReport()
        {
            this.AddDialogVisible = false;
            Report report = new Report();
            report.Title = Title;
            report.Content = Content;
            report.User = user;
            await AddReportAsync(report);
            ResetCreateReportData();
        }

        /**
        * @brief Resets all local variables used for adding categories, to their initial state
        * @details all the variables that were set bellow are used for adding categories
        * @param
        * @return
        */
        public void ResetCreateReportData()
        {
            AddDialogVisible = false;
            Title = null;
            Content = null;
            CreateReportDisabled = false;
            TitleNotValid = false;
        }

        /**
        * @brief Inserts a new category in the databased
        * @param Category of type category, that will be inserted in the database
        * @return Task<bool>, depends if the action could be made
        */
        public void ValidateTitle(Microsoft.AspNetCore.Components.ChangeEventArgs args)
        {
            TitleNotValid = true;
            Title = (String)args.Value;
            if (Title.Length > 0)
            {
                TitleNotValid = false;
            }
            CreateReportDisabled = TitleNotValid || DescriptionNotValid;
        }
        public void ValidateDescription(Microsoft.AspNetCore.Components.ChangeEventArgs args)
        {
            ContentNotValid = true;
            Content = (String)args.Value;
            if (Content.Length > 0)
            {
                ContentNotValid = false;
            }
            CreateReportDisabled = TitleNotValid || DescriptionNotValid;
        }

    }
}
