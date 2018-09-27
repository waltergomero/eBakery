using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eBakery.UnitOfWork.ViewModels;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using eBakery.UnitOfWork;


namespace eBakery.Web.Razor.Pages.app.Status
{
    public class AddEditStatusModel : PageModel
    {
        private readonly IStatusUnitOfWork _statusUnitOfWork;

        public AddEditStatusModel(IStatusUnitOfWork statusUnitOfWork)
        {
            _statusUnitOfWork = statusUnitOfWork;
        }

        public string Message { get; private set; } = "";
        public string Title { get; private set; } = "";

        [BindProperty]
        public StatusViewModel Status { get; set; }

        public async Task<IActionResult> OnGetAsync(int Id = 0)
        {
            if (Id == 0)
            {
                Title = "Add New Status";
                return Page();
            }
            else
            {
                Title = "Edit Status Information";
                Status = await _statusUnitOfWork.StatusById(Id);
                if (Status == null)
                {
                    Message = "No records found.";
                }
                return Page();

            }
        }

        //Method to save the data back to database
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                    int StatusId = Status.StatusId;
                    string StatusName = Status.StatusName;
                    int StatusTypeId = Status.StatusTypeId;

                    await this._statusUnitOfWork.SaveStatusData(StatusName, StatusId, StatusTypeId);
                    return RedirectToPage("./Index");

            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return Page();
            }
            

        }
    }
}