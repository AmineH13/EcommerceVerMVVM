using EComMVVM.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EComMVVM.Pages
{
    public class ProductModel : PageModel
    {

        private readonly MyDbContext myDbContext;

        public List<Product> Products { get; set; } = new List<Product>();
        public List<Panier> Paniers { get; set; } = new List<Panier>();

        [BindProperty] 
        public Product newProduct { get; set; }

        public ProductModel(MyDbContext dbContext)
        {
            myDbContext = dbContext;
        }
        public void OnGet()
        {
            Products = myDbContext.Products.ToList();
        }


        public IActionResult OnPost(string filterName)
        {
            if (!string.IsNullOrEmpty(filterName))
            {
                Products = myDbContext.Products.Where(p => p.name.Contains(filterName)).ToList();
            }
            else
            {
                Products = myDbContext.Products.ToList();
            }

            return Page();
        }






    }
}
