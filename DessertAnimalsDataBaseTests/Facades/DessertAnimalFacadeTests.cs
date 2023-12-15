using ErikaBladh.DessertAnimalsDataBase.DataAccess;
using ErikaBladh.DessertAnimalsDataBase.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ErikaBladh.DessertAnimalsDataBase.Facades.Tests;

[TestClass()]
public class DessertAnimalFacadeTests
{
	Mock<IDataAccess> _mock = null;
	IDataAccess _mockDb = null;
	DessertAnimalFacade _subject = null;
	List<Animal> _animals = new List<Animal>()
	{
		new Animal(1, "Vanillama", " Wandering through the Creamy Highlands."),
		new Animal(2,"Marshmellowphin", " Gliding through the Sea of Sweetness.")
	};

	[TestInitialize]
	public void Setup()
	{
		_mock = new Mock<IDataAccess>();
		_mock.Setup(x => x.DoNonQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>())).Returns(1).Verifiable();
		_mock.Setup(x => x.DoQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>())).Returns(new string[][] { new string[] { "1", "Test", "Test" } }).Verifiable();
		_mockDb = _mock.Object;
		_subject = new DessertAnimalFacade(_mockDb);
	}

	[TestMethod()]
	public void AddTest()
	{
		_subject.Add(_animals[1]);

		_mock.Verify(x => x.DoNonQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()), Times.Once);
	}

	[TestMethod()]
	public void RemoveTest()
	{
		_subject.Remove(1);

		_mock.Verify(x => x.DoNonQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()), Times.Once);
	}

	[TestMethod()]
	public void UpdateTest()
	{
		_subject.Update(_animals[1]);

		_mock.Verify(x => x.DoNonQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()), Times.Once);
	}

	[TestMethod()]
	public void GetAllTest()
	{
		var returnValue = new List<string[]>();
		_animals.ForEach(a => returnValue.Add(new string[] { a.Id.ToString(), a.Name, a.Description }));
		_mock.Setup(x => x.DoQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>())).Returns(returnValue.ToArray()).Verifiable();

		var actual = _subject.GetAll();

		_mock.Verify(x => x.DoQuery(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()), Times.Once);

		Assert.AreEqual(_animals.Count, actual.Count);
		Assert.AreEqual(_animals[0].Name, actual[0].Name);
		Assert.AreEqual(_animals[1].Description, actual[1].Description);
	}
}