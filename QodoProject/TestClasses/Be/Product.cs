using System;

namespace QualityExam.TestClasses.Be;

public class Product
{
    public required string Name { get; set; }
    public int StockLevel { get; set; }
    public int ReorderPoint { get; set; }
    public int ReorderQuantity { get; set; }
    public int SupplierLeadTime { get; set; }
    public int SafetyStock { get; set; }

    public void OrderStock(int quantity)
    {
        StockLevel += quantity;
    }
}
