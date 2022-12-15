using Backend.Models;

namespace Backend.Managers
{
    public class ProductsManager
    {
        public static List<Product> _products = new List<Product>()
        {

                new Product(){Barcode = 1, ProductName = "Laptop", AmountAvailable = 50, Price = 2000.00, CostForCompany = 1500.00},
                new Product(){Barcode = 2, ProductName = "Laptop Charger", AmountAvailable = 100, Price = 150.00, CostForCompany = 120.00},
                new Product(){Barcode = 3, ProductName = "TV", AmountAvailable = 5, Price = 4999.95, CostForCompany = 2000.00},
                new Product(){Barcode = 4, ProductName = "Custom PC", AmountAvailable = 1, Price = 15000.00, CostForCompany = 12000.00}
        };
       

        public List<Product> getAll()
        {
            if(_products.Count == 0)
            {
                return null;
            }
            else
            {
                return _products;
            }
        }
        public Product getByBarcode(int barcode)
        {
            Product returnvalue = _products.Where(x => x.Barcode == barcode).FirstOrDefault();
            return returnvalue;
        }
        public void add(Product product)
        {
            bool checker = _products.Where(x => x.Barcode == product.Barcode).Any();
            if(checker == false)
            {
                _products.Add(product);
            }
        }
        public void delete(int barcode)
        {
            Product returnvalue = _products.Where(x => x.Barcode == barcode).FirstOrDefault();
            if(returnvalue != null)
            {
                _products.Remove(returnvalue);
            }
        }
        public void update(Product product)
        {
            Product returnvalue = _products.Where(x => x.Barcode == product.Barcode).FirstOrDefault();

            if (returnvalue != null)
            {
                _products.Remove(returnvalue);
                _products.Add(product);
            }
        }
        public void increaseSupply(Product product, int amount)
        {
            Product returnvalue = _products.Where(x => x.Barcode == product.Barcode).FirstOrDefault();
            if (returnvalue != null)
            {
                returnvalue.AmountAvailable = returnvalue.AmountAvailable + amount;
                update(returnvalue);

            }
        }
    }
}
