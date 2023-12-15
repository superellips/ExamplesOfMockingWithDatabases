namespace ErikaBladh.DessertAnimalsDataBase;

using ErikaBladh.DessertAnimalsDataBase.DataAccess;
using ErikaBladh.DessertAnimalsDataBase.Facades;
using ErikaBladh.DessertAnimalsDataBase.UI;

internal class Program
{
	static void Main(string[] args)
	{
		// Current behavior is to place the database file in the same directory as the executable.
		// Edit below if you need it placed somewhere else.
		var pathToDatabase = "dessert_animals.db";
		IDataAccess db = new SQLiteDataAccess(pathToDatabase);
		var facade = new DessertAnimalFacade(db);
		new Menu(facade).Show();
	}
}
