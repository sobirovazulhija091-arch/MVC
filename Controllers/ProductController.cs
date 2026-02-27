using Microsoft.AspNetCore.Mvc;
public class ProductController(ProductRepo productRepo):Controller
{
    private readonly ProductRepo repo = productRepo;
    public ActionResult Index()
    {
        return View(repo.products);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Product product)
    {
        if(!ModelState.IsValid){return View(product);}
        repo.Add(product);
        return RedirectToAction(nameof(Index));
    }
    public IActionResult GetById(int id)
    { 
            var product = repo.GetById(id);
            return View(product);
    }
    public IActionResult Delete(int id)
    {
            var product = repo.Delete(id);
            return View(product);
    }
    public IActionResult Update(int id)
    {
         var product = repo.products.Find(x => x.Id == id);
         return View(product);  
    }
    [HttpPost]
    public IActionResult Update(int id,Product product)
    {
         var p = repo.Update(id,product);
         return RedirectToAction(nameof(Index));
    }
}