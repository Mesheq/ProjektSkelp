using System.Collections.Generic;

namespace Skelp.Data.Sql.DAO;

public class Seller
{
    public Seller()
    {
        Products = new List<Product>();
    }

    public int SellerId { get; set; }
    public string SellerName { get; set; }
    public string CompanyAdress { get; set; }
    public string CompanyEmail { get; set; }
    public bool CompanyIsBanned { get; set; }
    public int Pesel { get; set; }
    public int Nip { get; set; }
    public int Regon { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}