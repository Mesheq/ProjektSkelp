namespace Skelp.Data.Sql.DAO;

public class Complain
{
    public int ComplainId { get; set; }
    public int UserId { get; set; }
    public int OrderId { get; set; }
    public string Description { get; set; }

    public virtual User User { get; set; }
    public virtual Order Order { get; set; }
}