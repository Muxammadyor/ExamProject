using ExamProject.Broker.Procedure;
using ExamProject.Models;
using System.Data;
using System.Data.SqlClient;

namespace ExamProject.Broker;

public partial class StoregBroker : IDB
{
    public async Task<Users>  ChekUsers(string login)
    {
        using var connection = Connection();
        using var command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Procedures.SP_ChekUsers;
        command.Parameters.Add(new SqlParameter("@login", login));

        await connection.OpenAsync();
        using var dataReader = await command.ExecuteReaderAsync();
        var users = await ParseDataFromDataReader(dataReader);

        return users.FirstOrDefault();
    }

    public async Task InsertOrdersAsync(int roomId, int companyId, DateTime OrderFrom, DateTime OrderTo)
    {
        using var connection = Connection();
        using var command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Procedures.SP_InsertOrderRoom;

        command.Parameters.Add(new SqlParameter("@romeId", roomId));
        command.Parameters.Add(new SqlParameter("@companyID", companyId));
        command.Parameters.Add(new SqlParameter("@OrederTimeFrom", OrderFrom));
        command.Parameters.Add(new SqlParameter("@OrederTimeTo", OrderTo));

        await connection.OpenAsync();
        using var dataReader = await command.ExecuteReaderAsync();

    }

    public async Task InsertRoomAsync(string name, int capacity)
    {
        using var connection = Connection();
        using var command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Procedures.SP_InsertRoom;
        command.Parameters.Add(new SqlParameter("@name", name));
        command.Parameters.Add(new SqlParameter("@capacity", capacity));
        await connection.OpenAsync();
        using var dataReader = await command.ExecuteReaderAsync();
    }

    public async Task InsertUpdateRoomAsync(int newcapacity)
    {
        using var connection = Connection();
        using var command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Procedures.SP_UpdateRoom;
        command.Parameters.Add(new SqlParameter("@roomsigimi", newcapacity));

        await connection.OpenAsync();
        using var dataReader = await command.ExecuteReaderAsync();

    }

    public async Task InsortUserAsync(string name, string login, int role)
    {
        using var connection = Connection();
        using var command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Procedures.SP_InsertUsers;
        command.Parameters.Add(new SqlParameter("@name", name));
        command.Parameters.Add(new SqlParameter("@login", login));
        command.Parameters.Add(new SqlParameter("@role", role));
        await connection.OpenAsync();
        using var dataReader = await command.ExecuteReaderAsync();
    }

    public async Task<List<Order>> SelectEventAsync()
    {
        using var connection = Connection();
        using var command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Procedures.SP_SelectEvents;

        await connection.OpenAsync();
        using var dataReader = await command.ExecuteReaderAsync();
        var order = await ParseDataFromDataReader2(dataReader);

        return order;
    }

    public Task<List<Room>> SelectRoomsAsync()
    {
        throw new NotImplementedException();
    }


    private async Task<List<Users>> ParseDataFromDataReader(SqlDataReader dataReader)
    {
        List<Users> users = new List<Users>();

        while (await dataReader.ReadAsync())
        {
            var user = new Users(
                Id: dataReader.GetInt32(0),
                Name: dataReader.GetString(1),
                login:dataReader.GetString(2),
                role:dataReader.GetInt32(3)
                );

            users.Add(user);
        }

        return users;
    }

    public async Task<List<Order>> ParseDataFromDataReader2(SqlDataReader dataReader)
    {
        List<Order> order = new List<Order>();
        while (await dataReader.ReadAsync())
        {
            var user = new Order(
                Id: dataReader.GetInt32(0),
                companyId: dataReader.GetInt32(1),
                roomId: dataReader.GetInt32(2),
                orderFrom: dataReader.GetDateTime(3),
                orderto: dataReader.GetDateTime(4)
                );

            order.Add(user);
        }

        return order;

    }
}
