using ExamProject.Broker;
using ExamProject.Models;
using System.Security.Cryptography.X509Certificates;

namespace ExamProject.UIMain;

public class UI
{
    public IDB IDB { get; }
    public UI(IDB db)
    {
        this.IDB = db;
    }
    public async Task View()
    {
        Console.WriteLine("ASSALOMU ALEKUM XUSH KELIBSIZ");
        Console.WriteLine("1.TIZIMGA KIRISH");
        Console.WriteLine("2.ROYXATDAN OTISH");

        string position = Console.ReadLine();
        switch(position)
        {
            case "1":
                var user=await ChekUser();
                await MiniUI(user);
                break;
        }
    }

    public async Task<Users> ChekUser()
    {
        Console.Write("LOGIN-> ");
        string login = Console.ReadLine();
        var id = await IDB.ChekUsers(login);

        return id;
    }

    public async Task MiniUI(Users user)
    {
        if(user.role==0)
        {
            await Admin();            
        }
        else if(user.role==1)
        {
            //companiya
        }
        else if(user.role==2)
        {
            // user
        }
        else
        {
            Console.WriteLine("bunday foydalanuvchi royhatda yoq");
            Console.ReadKey();
            Console.Clear();
            await View();
        }
        
    }
    public async Task AddRoom()
    {
        Console.Write("Xona nomi->");
        string name = Console.ReadLine();
        Console.Write("Sigimi->");
        int copacity = int.Parse(Console.ReadLine());
        await IDB.InsertRoomAsync(name,copacity);
        Console.Clear();
        Console.WriteLine("1.Chiqish");
        Console.WriteLine("2.Ortga");
        switch(Console.ReadLine())
        {
            case "1":
                await View();
                break;
            case "2":
                await Admin();
                break;
        }
    }
    public async Task Admin()
    {
        Console.WriteLine("1.Xona qoshish");
        Console.WriteLine("2.Xona sigimini ozgartirish");
        Console.WriteLine("3.Sorovlarga javob berish");
        int adminPosition = int.Parse(Console.ReadLine());
        switch (adminPosition)
        {
            case 1:
                await AddRoom();
                break;
            case 2:

                break;
            default:

                break;
        }

    }



}
