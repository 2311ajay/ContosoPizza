using ContosoPizza.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ContosoPizza.Services;

public class PizzaService
{
    private readonly IMongoCollection<Pizza> _pizzaCollection;
    // static List<Pizza> Pizzas { get; }
    // static int nextId = 3;
    public PizzaService(
        IOptions<PizzaStoreDatabaseSettings> pizzaStoreDatabaseSettings
        )
    {
        var mongoClient = new MongoClient(
            pizzaStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            pizzaStoreDatabaseSettings.Value.DatabaseName);

        _pizzaCollection = mongoDatabase.GetCollection<Pizza>(
            pizzaStoreDatabaseSettings.Value.PizzasCollectionName);
    }

    public async Task<List<Pizza>> GetAsync() =>
        await _pizzaCollection.Find(_ => true).ToListAsync();

    public async Task<Pizza?> GetAsync(string id) =>
        await _pizzaCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Pizza newPizza) =>
        await _pizzaCollection.InsertOneAsync(newPizza);

    public async Task UpdateAsync(string id, Pizza updatedPizza) =>
        await _pizzaCollection.ReplaceOneAsync(x => x.Id == id, updatedPizza);

    public async Task RemoveAsync(string id) =>
        await _pizzaCollection.DeleteOneAsync(x => x.Id == id);
}