using APBD_5.Models;

namespace APBD_5.Repositories;

public interface IAnimalsRepository
{
    public IEnumerable<Animal> GetAnimals(string? orderBy);
    public int CreateAnimal(Animal animal);
    public int UpdateAnimal(Animal animal, int idAnimal);
    public int DeleteAnimal(int idAnimal);
}