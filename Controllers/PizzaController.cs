using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly PizzaService _pizzaService;
    public PizzaController(PizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    // GET all action
    [HttpGet]
    public async Task<List<Pizza>> Get() =>
        await _pizzaService.GetAsync();

    // GET by Id action
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Pizza>> Get(string id)
    {
        var pizza = await _pizzaService.GetAsync(id);

        if(pizza is null)
            return NotFound();

        return pizza;
    }

    // POST action
    [HttpPost]
    public async Task<IActionResult> Post(Pizza pizza)
    {            
        await _pizzaService.CreateAsync(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    // PUT action

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Pizza newPizzaData)
    {
        var oldPizzaData = await _pizzaService.GetAsync(id);

        if(oldPizzaData is null)
            return NotFound();

        newPizzaData.Id = oldPizzaData.Id;
    
        await _pizzaService.UpdateAsync(id, newPizzaData);         
    
        return NoContent();
    }

    // DELETE action

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var pizza = await _pizzaService.GetAsync(id);
    
        if (pizza is null)
            return NotFound();
        
        await _pizzaService.RemoveAsync(id);
    
        return NoContent();
    }
}