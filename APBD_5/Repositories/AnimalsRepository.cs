using System.Data.Common;
using System.Data.SqlClient;
using APBD_5.Models;

namespace APBD_5.Repositories;

public class AnimalsRepository : IAnimalsRepository
{
    private readonly IConfiguration _configuration;

    public AnimalsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IEnumerable<Animal> GetAnimals(string? orderBy)
    {
        var animals = new List<Animal>();
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animals_DB.Animal ORDER BY " + orderBy + " ASC;";
        
        var dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            var animal = new Animal
            {
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString(),
            };
            animals.Add(animal);
        }

        return animals;
    }
    
    public int CreateAnimal(Animal animal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Animals_DB.Animal(Name, Description, Category, Area) VALUES(@Name, @Description, @Category, @Area)";
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
    
    public int UpdateAnimal(Animal animal, int idAnimal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE Animals_DB.Animal SET Name=@Name, Description=@Description, Category=@Category, Area=@Area WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdStudent", animal.Name);
        cmd.Parameters.AddWithValue("@FirstName", animal.Description);
        cmd.Parameters.AddWithValue("@LastName", animal.Category);
        cmd.Parameters.AddWithValue("@Email", animal.Area);
        cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int DeleteAnimal(int idAnimal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Animals_DB.Animal WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}