using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Caching.Memory;

public class CategoryController(CategoryRepo categoryRepo):Controller
{
     private readonly CategoryRepo repo = categoryRepo;
    [Authorize]
     public ActionResult Index()
    {
        return View(repo.categories);
    }
    [Authorize]
    public IActionResult Create()
    {
        return View();
    }
    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category category)
    {
      if(!ModelState.IsValid){return View(category);}
      repo.Add(category);
      return RedirectToAction(nameof(Index));
    }
    [Authorize(Roles = "Admin,Managment")]
    [Authorize]
    public IActionResult Delete(int id)
    {
        var category = repo.Delete(id);
        return View(category);
    }
    [Authorize]
    public IActionResult GetById(int id)
    {
       var category = repo.GetById(id);
       return View(category);
    }
    [Authorize]
     public IActionResult Update(int id)
    {
        var category = repo.categories.Find(x=>x.Id==id);
        return View(category);
    }
    [Authorize(Roles = "Admin")]
    [Authorize]
    [HttpPost]
    public IActionResult Update(int id,Category category)
    {
        var update = repo.Update(id,category);
        return RedirectToAction(nameof(Index));
    }
   
}