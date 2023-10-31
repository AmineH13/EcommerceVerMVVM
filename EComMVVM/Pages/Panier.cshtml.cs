using EComMVVM.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EComMVVM.Pages
{
    public class PanierModel : PageModel
    {


        private readonly MyDbContext _dbContextConnection;
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Panier> Paniers { get; set; } = new List<Panier>();


        public PanierModel(MyDbContext dbContext)
        {
            _dbContextConnection = dbContext;
        }

        public void OnGet()
        {

            var panier = _dbContextConnection.Paniers.Where(p => p.IdUser == 1).ToList();

            var productIDs = panier.Select(p => p.IdProduct).ToList();

            var produits = new List<Product>();

            foreach (int idp in productIDs)
            {
                var produit = _dbContextConnection.Products.FirstOrDefault(p => p.id == idp);
                if (produit != null)
                {
                    produits.Add(produit);
                }
            }

            Products = produits;
            
        }





        public IActionResult OnPost()
        {
            if (Request.Form.TryGetValue("idProduit", out var idProduitValue))
            {
                if (int.TryParse(idProduitValue, out int idProduit))
                {
                    var nouveauPanier = new Panier
                    {
                        IdProduct = idProduit,
                        IdUser = 1
                    };

                    _dbContextConnection.Paniers.Add(nouveauPanier);
                    _dbContextConnection.SaveChanges();
                    return RedirectToPage("Product");
                }
            }


            return Page();
        }



    }
}


