using AnimalDataAPI.Models;
using Microsoft.Data.SqlClient;

namespace AnimalDataAPI.DataBase;

public class AnimalDataBase : IAnimalDataBase
{
    private IConfiguration _configuration;
    
    public AnimalDataBase(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IEnumerable<Animal> GetAnimals(String orderBy)
    {
        using var con = new SqlConnection(_configuration.GetConnectionString("Default"));
        con.Open();
        
        var allowedColumns = new List<string> {"name", "description", "category", "area" };
        
        if (!allowedColumns.Contains(orderBy.ToLower()))
        {
            throw new ArgumentException("Invalid order by parameter.", orderBy);
        }
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = $"SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY {orderBy}";

        var dr = cmd.ExecuteReader();
        var animals = new List<Animal>();
        while (dr.Read())
        {
            var animal = new Animal()
            {
                Id = dr.GetInt32(0),
                Name = dr.GetString(1),
                Description = dr.GetString(2),
                Category = dr.GetString(3),
                Area = dr.GetString(4)
            };
            animals.Add(animal);
        }
        return animals;
    }

    public int AddAnimal(Animal animal)
    {
        using var con = new SqlConnection(_configuration.GetConnectionString("Default"));
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Animal(Name, Description, Category, Area) VALUES (@Name, @Description, @Category, @Area)";
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        
        var affectedRows = cmd.ExecuteNonQuery();
        return affectedRows;
    }

    public int UpdateAnimal(Animal animal)
    {
        using var con = new SqlConnection(_configuration.GetConnectionString("Default"));
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE Animal SET Name = @Name, Description = @Description, Category = @Category, Area = @Area WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        cmd.Parameters.AddWithValue("@IdAnimal", animal.Id);

        var affectedRows = cmd.ExecuteNonQuery();
        return affectedRows;
    }

    public int RemoveAnimal(int idAnimal)
    {
        using var con = new SqlConnection(_configuration.GetConnectionString("Default"));
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Animal WHERE IdAnimal = @idAnimal";
        cmd.Parameters.AddWithValue("@idAnimal", idAnimal);
        
        var affectedRows = cmd.ExecuteNonQuery();
        return affectedRows;
    }
}