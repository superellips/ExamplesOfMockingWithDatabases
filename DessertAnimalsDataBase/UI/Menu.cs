namespace ErikaBladh.DessertAnimalsDataBase.UI;

using ErikaBladh.DessertAnimalsDataBase.Facades;
using ErikaBladh.DessertAnimalsDataBase.Models;

public class Menu(DessertAnimalFacade facade)
{
	private readonly DessertAnimalFacade _facade = facade;

	public void Show()
	{
		Dictionary<string, Action> _menuItems = new()
		{
			{ "1", AddAnimal },
			{ "2", RemoveAnimal },
			{ "3", UpdateAnimal },
			{ "4", ListAllAnimals },
			{ "5", Exit }
		};
		while (true)
		{
			Console.WriteLine("1. Add animal");
			Console.WriteLine("2. Remove animal");
			Console.WriteLine("3. Update animal");
			Console.WriteLine("4. List all animals");
			Console.WriteLine("5. Exit");
			Console.Write("Choose an option: ");
			var input = Console.ReadLine();
			if (_menuItems.ContainsKey(input))
			{
				_menuItems[input].Invoke();
			}
			else
			{
				Console.WriteLine("Invalid input");
			}
		}
	}

	private void AddAnimal()
	{
		Console.Write("Name: ");
		var name = Console.ReadLine();
		Console.Write("Description: ");
		var description = Console.ReadLine();
		var animal = new Animal(0, name, description);
		_facade.Add(animal);
	}

	private void RemoveAnimal()
	{
		Console.Write("Id: ");
		var id = int.Parse(Console.ReadLine());
		_facade.Remove(id);
	}

	private void UpdateAnimal()
	{
		Console.Write("Id: ");
		var id = int.Parse(Console.ReadLine());
		Console.Write("Name: ");
		var name = Console.ReadLine();
		Console.Write("Description: ");
		var description = Console.ReadLine();
		var animal = new Animal(id, name, description);
		_facade.Update(animal);
	}

	private void ListAllAnimals()
	{
		foreach (var a in _facade.GetAll())
		{
			Console.WriteLine(a + "\n");
		}
	}

	private void Exit()
	{
		Environment.Exit(0);
	}
}
