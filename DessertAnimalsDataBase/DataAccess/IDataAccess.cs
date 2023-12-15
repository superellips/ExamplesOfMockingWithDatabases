namespace ErikaBladh.DessertAnimalsDataBase.DataAccess;
public interface IDataAccess
{
	int DoNonQuery(string sql, Dictionary<string, string>? parameters = null);
	string[][] DoQuery(string sql, Dictionary<string, string>? parameters = null);
}
