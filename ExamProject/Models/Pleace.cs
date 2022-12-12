namespace ExamProject.Models;

public class Pleace
{
    public Pleace(int roomId,int userId,int pleace)
    {
        this.roomId = roomId;
        this.userId = userId;
        this.pleace = pleace;

    }
    public  int roomId {get;set;}
    public int userId { get; set; }
    public int pleace { get; set; }

}
