namespace ExamProject.Models;

public class Room
{
    public Room(int Id,string Name,int capasity)
    {
        this.Id = Id;
        this.Name = Name;
        this.capacity = capasity;
    }
    public Room(string Name,int capasity)
    {
        this.Name = Name;
        this.capacity = capasity;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int capacity { get; set; }

}
