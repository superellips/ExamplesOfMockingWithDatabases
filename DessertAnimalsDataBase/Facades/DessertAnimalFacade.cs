namespace ErikaBladh.DessertAnimalsDataBase.Facades;

using ErikaBladh.DessertAnimalsDataBase.DataAccess;
using ErikaBladh.DessertAnimalsDataBase.Models;

public class DessertAnimalFacade(IDataAccess dataAccess)
{
    private readonly IDataAccess _dataAccess = dataAccess;
    private const string _tableName = "Animals";

    public void Add(Animal animal)
    {
        var sql = $"INSERT INTO {_tableName} (Name, Description) VALUES (@Name, @Description)";
        var parameters = new Dictionary<string, string>()
        {
            { "@Name", animal.Name },
            { "@Description", animal.Description }
        };
        _dataAccess.DoNonQuery(sql, parameters);
    }

    public void Remove(int id)
    {
        var sql = $"DELETE FROM {_tableName} WHERE Id = @Id";
        var parameters = new Dictionary<string, string>()
        {
            { "@Id", id.ToString() }
        };
        _dataAccess.DoNonQuery(sql, parameters);
    }

    public void Update(Animal animal)
    {
        var sql = $"UPDATE {_tableName} SET Name = @Name, Description = @Description WHERE Id = @Id";
        var parameters = new Dictionary<string, string>()
        {
            { "@Id", animal.Id.ToString() },
            { "@Name", animal.Name },
            { "Description", animal.Description }
        };
        _dataAccess.DoNonQuery(sql, parameters);
    }

    public List<Animal>? GetAll()
    {
        var sql = $"SELECT * FROM {_tableName}";
        var result = new List<Animal>();
        foreach (var row in _dataAccess.DoQuery(sql))
        {
            var animal = AnimalFromStringArray(row);
            if (animal is not null) result.Add(animal);
        }
        return result;
    }

    private Animal? AnimalFromStringArray(string[] animalData)
    {
        try
        {
            return new Animal(int.Parse(animalData[0]), animalData[1], animalData[2]);
        }
        catch
        {
			return null;
		}
    }
}
