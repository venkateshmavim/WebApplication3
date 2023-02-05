using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;

        

        public void OnGet()
        {
            ProductService service = new ProductService();
            Products = service.GetProducts();
        }
    }
}