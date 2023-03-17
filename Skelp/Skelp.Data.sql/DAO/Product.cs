// using Skelp.Data.Sql.Enums;

using System.Collections.Generic;

namespace Skelp.Data.Sql.DAO;

public class Product
{
    public Product()
    {
        ProductOrders = new List<ProductOrder>();
    }

    public int ProductId { get; set; }
    public int SellerId { get; set; }
    public string ProductName { get; set; }
    public string Brand { get; set; }
    public string ProductDescription { get; set; }
    public double Price { get; set; }
    public int Weight { get; set; }


    public virtual Seller Seller { get; set; }
    public virtual ICollection<ProductOrder> ProductOrders { get; set; }
}