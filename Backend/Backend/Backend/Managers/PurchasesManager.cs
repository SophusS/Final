using Backend.Models;

namespace Backend.Managers
{
    public class PurchasesManager
    {
        public static List<Product> _products = new List<Product>()
        {
                new Product(){Barcode = 1052, ProductName = "Laptop", AmountAvailable = 50, Price = 2000.00, CostForCompany = 1500.00},
                new Product(){Barcode = 2051, ProductName = "Laptop Charger", AmountAvailable = 100, Price = 150.00, CostForCompany = 120.00},
                new Product(){Barcode = 1052, ProductName = "TV", AmountAvailable = 5, Price = 4999.95, CostForCompany = 2000.00},
                new Product(){Barcode = 2051, ProductName = "Custom PC", AmountAvailable = 1, Price = 15000.00, CostForCompany = 12000.00}

        };
        public static List<Purchase> _purchases = new List<Purchase>()
        {
                new Purchase(){Date = DateTime.Now, PurchaseId = 1, IsCurrent = false, itemList = new List<Product>{ {_products[0]}, { _products[2]} }, amountList = new List<int>{ 1, 2 } },
                new Purchase(){Date = DateTime.Now, PurchaseId = 2, IsCurrent = false, itemList = new List<Product>{ {_products[1]}, { _products[3]} }, amountList = new List<int>{ 3, 1 } },
                new Purchase(){Date = DateTime.Now, PurchaseId = 3, IsCurrent = true, itemList = new List<Product>{ {_products[1]}, { _products[2]} }, amountList = new List<int>{ 2, 5 } },
        };

        public List<Purchase> getAll()
        {
            if(_purchases.Count == 0)
            {
                return null;
            }
            else
            {
                return _purchases;
            }
        }
        public Purchase getById(int id)
        {
            Purchase returnvalue = _purchases.Where(x => x.PurchaseId == id).FirstOrDefault();
            return returnvalue;
        }
        public void create(Purchase purchase)
        {
            foreach(Purchase x in _purchases)
            {
                if(x.IsCurrent == true)
                {
                    x.IsCurrent = false;
                }
            }
            _purchases.Add(purchase);
        }
        public void addItemToCurrentPurchase(Product product)
        {
            foreach (Purchase x in _purchases)
            {
                if (x.IsCurrent == true)
                {
                    x.add(product);

                }
            }
        }
        public void removeItemFromCurrentPurchase(Product product)
        {
            foreach (Purchase x in _purchases)
            {
                if (x.IsCurrent == true)
                {
                    x.deleteItem(product);

                }
            }
        }
        public void delete(int barcode)
        {
            Purchase returnvalue = _purchases.Where(x => x.PurchaseId == barcode).FirstOrDefault();
            if(returnvalue != null)
            {
                _purchases.Remove(returnvalue);
            }
        }
        public void update(Purchase purchase)
        {
            Purchase returnvalue = _purchases.Where(x => x.PurchaseId == purchase.PurchaseId).FirstOrDefault();

            if (returnvalue != null)
            {
                _purchases.Remove(returnvalue);
                _purchases.Add(purchase);
            }
        }
    }
}
