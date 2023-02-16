using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Principal;

namespace PruebaProAmerica.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public Validator validacion { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost(Validator validator)
        {
        


            if (!ModelState.IsValid)
            {



                return Page();
            }
            else
            {
                return RedirectToPage("Se logro ingresar");
            }



        }



    }
}