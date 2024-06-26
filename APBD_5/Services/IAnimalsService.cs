using APBD_5.Models;

namespace APBD_5.Services;

public interface IAnimalsService
{
    public IEnumerable<Animal> GetAnimals(string? orderBy);
    public int CreateAnimal(Animal animal);
    public int UpdateAnimal(Animal animal, int idAnimal);
    public int DeleteAnimal(int idAnimal);
}