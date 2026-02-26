public class ProductRepo
{
    public List<Product> products = new List<Product>();
    public List<Product> Add(Product product)
    {
       products.Add(product);
        return products;
    }   
    public List<Product> GetAll()
    {
        return products;
    }
    public Product GetById(int id)
    {
         var product = products.Find(x=>x.Id==id)??new Product();
        return product;
    }
    public Product Delete(int id)
    {
         var product = products.Find(x=>x.Id==id);
        products.Remove(product);
        return product;
    }
    public  Product Update(int id,Product product)
    {
         var p = products.Find(x=>x.Id==id);
         if (p == null){return null!;}
         p.Name=product.Name;
         p.Price=product.Price;
          return p;
    }
}