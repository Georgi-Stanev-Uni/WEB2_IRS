using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IRS.Pages
{
    public class LoginModel : PageModel
    {
        public bool boll { get;  set; }

        public IActionResult OnPost (string submitForm)
        {
            if (submitForm == "Login")
            {

                return RedirectToPage("/Home");
            }
            else
            {
                return RedirectToPage("/Login");
            }
            }
        public void OnGet()
        
        {

        }
    }
}
