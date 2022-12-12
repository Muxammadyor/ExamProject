using ExamProject.Models;

namespace ExamProject.Broker;

public partial interface IDB
{
    Task InsortUserAsync(string name, string login, int role);
    Task InsertRoomAsync(string name, int capacity);
    Task InsertUpdateRoomAsync(int newcapacity);
    Task InsertOrdersAsync(int roomId, int compsnyId, DateTime OrderFrom, DateTime OrderTo);
    Task<List<Order>> SelectEventAsync();
    Task<List<Room>> SelectRoomsAsync();
    Task<Users> ChekUsers(string login);

}
