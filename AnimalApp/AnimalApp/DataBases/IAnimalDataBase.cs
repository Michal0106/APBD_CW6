using AnimalDataAPI.Models;

namespace AnimalDataAPI.DataBase;

public interface IAnimalDataBase
{
    IEnumerable<Animal> GetAnimals(String orderBy);
    int AddAnimal(Animal animal);
    int UpdateAnimal(Animal animal);
    int RemoveAnimal(int idAnimal);
}