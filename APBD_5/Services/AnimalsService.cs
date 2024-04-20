using APBD_5.Models;
using APBD_5.Repositories;

namespace APBD_5.Services;

public class AnimalsService : IAnimalsService
{
    private readonly IAnimalsRepository _animalsRepository;

    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;

    }

    public IEnumerable<Animal> GetAnimals(string? orderBy)
    {
        return _animalsRepository.GetAnimals(orderBy);
    }

    public int CreateAnimal(Animal animal)
    {
        return _animalsRepository.CreateAnimal(animal);
    }

    public int UpdateAnimal(Animal animal, int idAnimal)
    {
        return _animalsRepository.UpdateAnimal(animal, idAnimal);
    }

    public int DeleteAnimal(int idAnimal)
    {
        return _animalsRepository.DeleteAnimal(idAnimal);
    }
}