using System;
using QualityExam.TestClasses.Be;

namespace QualityExam.TestClasses;

public class InventoryManager
{
    public void ManageInventory(List<Product> products)
    {
        foreach (var product in products) 
        {
            if (product.StockLevel < product.ReorderPoint) 
            {
                int quantityToOrder = product.ReorderQuantity; 
                if (product.SupplierLeadTime > 7) 
                {
                    quantityToOrder += product.SafetyStock; 
                }
                {
                    quantityToOrder += product.SafetyStock; 
                }
                product.OrderStock(quantityToOrder);   
            }
        }
    }
}
