using System.Data;
using MySql.Data.MySqlClient;

namespace Integration.Core.Data;

public class Repository
{
    public const string CONNECTION_STRING = "server=localhost;database=legado;uid=root;pwd=root;";
    public const string CONNECTION_STRING_V =
        "server=localhost;database=legado;uid=root;pwd=Chamex13;";

    protected static IDbConnection Connect()
    {
        return new MySqlConnection(CONNECTION_STRING);
    }

    protected static string GetDeleteNoWhereStatement() => "DELETE FROM monolito";


}
