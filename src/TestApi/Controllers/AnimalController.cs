using Microsoft.AspNetCore.Mvc;
using MTech.Domain;
using MTech.Domain.Enums;

namespace MTech.TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
            => _animalService = animalService;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_animalService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var animal = _animalService.GetById(id);

            if (animal == null)
                return NotFound();

            return Ok(animal);
        }

        [HttpGet("dogs")]
        public IActionResult GetAllDogs()
        {
            return Ok(_animalService.GetByType(AnimalType.Dog));
        }

        [HttpPost]
        public IActionResult Create(Animal animal)
        {
            _animalService.Create(animal);

            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Animal animal)
        {
            _animalService.Update(id, animal);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _animalService.Delete(id);

            return Ok();
        }

        [HttpPost("dogs")]
        public IActionResult CreateDog(Dog dog)
        {
            dog.Type = AnimalType.Dog;
            _animalService.Create(dog);

            return Ok();
        }

        [HttpPost("cows")]
        public IActionResult CreateCow(Cow cow)
        {
            cow.Type = AnimalType.Cow;
            _animalService.Create(cow);

            return Ok();
        }
    }
}
