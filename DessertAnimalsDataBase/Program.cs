namespace ErikaBladh.DessertAnimalsDataBase;

using ErikaBladh.DessertAnimalsDataBase.DataAccess;
using ErikaBladh.DessertAnimalsDataBase.Facades;
using ErikaBladh.DessertAnimalsDataBase.UI;

internal class Program
{
	static void Main(string[] args)
	{
		IDataAccess db = new SQLiteDataAccess("dessert_animals.db");
		var facade = new DessertAnimalFacade(db);
		new Menu(facade).Show();
	}
}
