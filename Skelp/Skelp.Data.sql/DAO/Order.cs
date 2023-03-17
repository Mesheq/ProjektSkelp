using System;
using System.Collections.Generic;

namespace Skelp.Data.Sql.DAO;

public class Order
{
    public Order()
    {
        ProductOrders = new List<ProductOrder>();
        Complains = new List<Complain>();
    }

    public int OrderId { get; set; }
    public int UserId { get; set; }
    public DateTime DateAcceptance { get; set; }
    public bool IsPaid { get; set; }
    public DateTime DateRealisation { get; set; }
    public bool Realised { get; set; }


    public virtual User User { get; set; }
    public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    public virtual ICollection<Complain> Complains { get; set; }
}