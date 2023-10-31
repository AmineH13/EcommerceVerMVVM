using EComMVVM.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EComMVVM.Pages
{
    public class AddProductModel : PageModel
    {


        private readonly MyDbContext myDbContext;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public List<Product> Products { get; set; } = new List<Product>();

        [BindProperty]
        public Product newProduct { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }


        public AddProductModel(MyDbContext dbContext, IWebHostEnvironment hostingEnvironment)
        {
            myDbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
        }

        public void OnGet()
        {
        }






        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var fileName = DateTime.Now.Ticks + Path.GetExtension(ImageFile.FileName);

                var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "phones");
                var filePath = Path.Combine(uploadsFolder, fileName);

                Directory.CreateDirectory(uploadsFolder);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                     await ImageFile.CopyToAsync(fileStream);
                }

                newProduct.image = "/phones/" + fileName; 
            }

             myDbContext.Products.Add(newProduct);
             await myDbContext.SaveChangesAsync();

            return RedirectToPage("Product");
        }
    }
}
    