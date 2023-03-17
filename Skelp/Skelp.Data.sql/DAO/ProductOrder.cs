namespace Skelp.Data.Sql.DAO;

public class ProductOrder
{
    public int ProductOrderId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }

    public virtual Order Order { get; set; }
    public virtual Product Product { get; set; }
}