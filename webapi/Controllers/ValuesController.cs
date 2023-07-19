using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class ValuesController : ControllerBase
{
    private string[] Nombres = new string[] { "Juan", "Pedro", "Maria", "Jose", "Luis", "Ana", "Rosa", "Carlos", "Jorge", "Luisa" }; 

    [HttpGet]
    public IActionResult Get()
    {
        var rng = new Random();
        var nombre = Nombres[rng.Next(Nombres.Length)];
        return Ok(new { message = $"Hello {nombre}" });
    }
    //get para retornar un objeto con propiedades de nombres, año y mensaje de mayor o menor de edad
    [HttpGet("lista")]
    public IActionResult GetLista()
    {
        var lista = new Object();
        for (int i = 0; i < 5; i++)
        {
            var random = new Random();
            var nombre = Nombres[random.Next(Nombres.Length)];
            var edad = random.Next(1, 100);
            var mensaje = edad >= 18 ? "Es mayor de edad" : "Es menor de edad";
            lista = new { nombre, edad, mensaje };
        }
        return Ok(lista);
    }
    //get para retornar una lista de nombres indicando su edad de valor aleatorio con un mensaje de mayor o menor de edad
    [HttpGet("nombreedad")]
    public IActionResult GetNombreEdad(){
        
        var lista  = new List<string>();
        for (int i = 0; i< 5; i++){
            var random = new Random();
            var nombre = Nombres[random.Next(Nombres.Length)];
            var edad = random.Next(1,100);
            var mensaje = edad >= 18 ? "Es mayor de edad" : "Es menor de edad";
            lista.Add($"{nombre} tiene {edad} años. {mensaje}");

        }
        return Ok(lista);
    }

    // private static readonly string[] Summaries = new[]
    // {
    //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // };

    // [HttpGet]
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     {
    //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //         TemperatureC = Random.Shared.Next(-20, 55),
    //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }
}
