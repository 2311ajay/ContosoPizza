namespace ContosoPizza.Models;

public class PizzaStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = "" + Environment.GetEnvironmentVariable("DB_URL");

    public string DatabaseName { get; set; } = "" + Environment.GetEnvironmentVariable("DatabaseName");

    public string PizzasCollectionName { get; set; } = "" + Environment.GetEnvironmentVariable("PizzasCollectionName");
}