using AnimalDataAPI.Models;

namespace AnimalDataAPI.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals(String orderBy);
    int AddAnimal(Animal animal);
    int UpdateAnimal(int id, Animal animal);
    int RemoveAnimal(int idAnimal);
}