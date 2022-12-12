namespace ExamProject.Models;

public class Order
{
    public Order(int Id,int companyId,int roomId,DateTime orderFrom,DateTime orderto)
    {
        this.ID = Id;
        this.CompanyId = companyId;
        this.roomId = roomId;
        this.OrderFrom = orderFrom;
        this.OrderTo = orderto;

    }
    public int ID { get; set; }
    public int CompanyId { get; set; }
    public int roomId { get; set; }
    public DateTime OrderFrom { get; set; }
    public DateTime OrderTo { get; set; }

}
