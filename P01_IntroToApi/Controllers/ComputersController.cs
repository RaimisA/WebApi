using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01_IntroToApi.Controllers.Models;
using System.Security.Cryptography.X509Certificates;

namespace P01_IntroToApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputersController : ControllerBase
    {
        private readonly List<Computer> _computers;

        public ComputersController()
        {
            _computers = new List<Computer>
            {
                new Computer { Id = 1, Name = "Commodore 64", Description = "The best selling computer of all time", Year = 1982 },
                new Computer { Id = 2, Name = "ZX Spectrum", Description = "The best selling computer in the UK", Year = 1982 },
                new Computer { Id = 3, Name = "Amiga 500", Description = "The best selling Amiga model", Year = 1987 },
                new Computer { Id = 4, Name = "Atari 800", Description = "The first computer with custom coprocessors", Year = 1979 },
                new Computer { Id = 5, Name = "Apple II", Description = "The first computer with a color display", Year = 1977 },
                new Computer { Id = 6, Name = "IBM PC", Description = "The first computer with an Intel processor", Year = 1981 },
                new Computer { Id = 7, Name = "Commodore 128", Description = "The last 8-bit computer from Commodore", Year = 1985 },
                new Computer { Id = 8, Name = "Amiga 1200", Description = "The last Amiga model", Year = 1992 },
                new Computer { Id = 9, Name = "Atari ST", Description = "The best selling Atari model", Year = 1985 },
                new Computer { Id = 10, Name = "Apple Macintosh", Description = "The first computer with a graphical user interface", Year = 1984 },
                new Computer { Id = 11, Name = "Collaborative Computer", Description = "The best computer ever", Year = 2021 }
            };

        }
        [HttpGet]
        public IEnumerable<Computer> Get()
        {
            return _computers;
        }

        [HttpGet("{id}")]
        public Computer? Get(int id)
        {
            return _computers.Find(x => x.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] Computer value)
        {
           _computers.Add(value);
        }
        [HttpPut]
        public void Put(int id, [FromBody] Computer newComputer)
        {
            var computer = _computers.Find(x => x.Id == id);
            computer.Name = newComputer.Name;
            computer.Description = newComputer.Description;
            computer.Year = newComputer.Year;

        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var computer = _computers.Find(x => x.Id == id);
            _computers.Remove(computer);
        }
    }
}
