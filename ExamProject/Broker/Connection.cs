using System.Data.SqlClient;

namespace ExamProject.Broker;

public partial class StoregBroker:IDB
{
    public SqlConnection Connection()
    {
        string connectionString = @"Server=MUXAMMADYORKENJ; Database=BLOG;Trusted_Connection=True;MultipleActiveResultSets=true";

        return new SqlConnection(connectionString);
    }
}
