namespace ExamProject.Models;

public class Users
{
    public Users(int Id,string Name,string login,int role)
    {
        this.Id = Id;
        this.Name = Name;
        this.login = login;
        this.role = role;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string login { get; set; }
    public int role { get; set; }
}
