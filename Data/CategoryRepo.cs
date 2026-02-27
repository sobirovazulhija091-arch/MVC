public class CategoryRepo
{
    public List<Category> categories = new List<Category>();
    public List<Category> Add(Category category)
    {
        categories.Add(category);
        return  categories;
    }
    public List<Category> Get()
    {
        return categories;
    }
    public Category GetById(int id)
    {
        var category = categories.Find(x=>x.Id==id) ?? new Category();
        return category;
    }
    public Category Delete(int id)
    {
         var category = categories.Find(x=>x.Id==id);
          categories.Remove(category);
        return category;
    }
    public Category Update(int id ,Category category)
    {
           var cate = categories.Find(x=>x.Id==id);
           cate.Description = category.Description;
           cate.Name = category.Name;
           return cate;
    }
}