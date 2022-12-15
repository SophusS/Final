namespace Backend.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public List<Product> itemList { get; set; }
        public List<int> amountList { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get
            {
                double total = 0;
                foreach (var item  in itemList)
                {
                    total = total + item.Price;
                }
                return total;
            } 
        }
        public bool IsCurrent { get; set; }

        public void add(Product product)
        {
            bool isAlreadyInList = false;
            int counter = 0;
            foreach (var p in itemList)
            {
                
                if (product.Barcode == p.Barcode)
                {
                    isAlreadyInList = true;
                    amountList[counter] = amountList[counter] + 1;
                }
                counter++;
            }

            if (isAlreadyInList == false)
            {
                itemList.Add(product);
                amountList.Add(1);
            }

            
            
        }
        public void deleteItem(Product product)
        {
            int counter = 0;

            foreach (var p in itemList)
            {
                if (product.Barcode == p.Barcode)
                {
                    itemList.Remove(product);
                    amountList.RemoveAt(counter);
                }
                counter++;
            }

        }
    }
}
