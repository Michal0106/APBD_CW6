using AnimalDataAPI.DataBase;
using AnimalDataAPI.Models;

namespace AnimalDataAPI.Services;

public class AnimalService : IAnimalService
{
    private IAnimalDataBase _animalDataBase;

    public AnimalService(IAnimalDataBase animalDataBase)
    {
        _animalDataBase = animalDataBase;
    }
    public IEnumerable<Animal> GetAnimals(String orderBy)
    {
        return _animalDataBase.GetAnimals(orderBy);
    }
    public int AddAnimal(Animal animal)
    {
        return _animalDataBase.AddAnimal(animal);
    }
    public int UpdateAnimal(int id, Animal animal)
    {
        animal.Id = id;
        return _animalDataBase.UpdateAnimal(animal);
    }
    public int RemoveAnimal(int idAnimal)
    {
        return _animalDataBase.RemoveAnimal(idAnimal);
    }
}