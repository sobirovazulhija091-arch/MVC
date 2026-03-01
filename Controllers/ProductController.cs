using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
public class ProductController(ProductRepo productRepo):Controller
{
    private readonly ProductRepo repo = productRepo;
    [Authorize]
    public ActionResult Index()
    {
        return View(repo.products);
    }
    public IActionResult Create()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Product product)
    {
        if(!ModelState.IsValid){return View(product);}
        repo.Add(product);
        return RedirectToAction(nameof(Index));
    }
     [Authorize(Roles = "Admin,Manager")]
    [Authorize]
    public IActionResult GetById(int id)
    { 
            var product = repo.GetById(id);
            return View(product);
    }
     [Authorize(Roles = "Admin,Manager")]
    [Authorize]
    public IActionResult Delete(int id)
    {
            var product = repo.Delete(id);
            return View(product);
    }
    [Authorize(Roles = "Admin")]
    [Authorize]
    public IActionResult Update(int id)
    {
         var product = repo.products.Find(x => x.Id == id);
         return View(product);  
    }
   [Authorize(Roles = "Admin")]
    [Authorize]
    [HttpPost]
    public IActionResult Update(int id,Product product)
    {
         var p = repo.Update(id,product);
         return RedirectToAction(nameof(Index));
    }
}