namespace ErikaBladh.DessertAnimalsDataBase.Models;
public class Animal
{
	public Animal(int id, string name, string description)
	{
		Id = id;
		Name = name;
		Description = description;
	}

	public int Id { get; }
	public string Name { get; set; }
	public string Description { get; set; }
	public override string ToString()
	{
		return $"{Name} (ID: {Id})\nDescription:\n{Description}";
	}
}
