using Microsoft.AspNetCore.Mvc;
using P01_IntroToApi.Controllers.Models;
using System.Collections.Generic;
using System.Linq;

namespace P01_IntroToApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartphonesController : ControllerBase
    {
        private static readonly List<Smartphone> _smartphones;
        private static int _nextId;

        static SmartphonesController()
        {
            _smartphones = new List<Smartphone>
            {
                new Smartphone { Id = 1, Brand = "Apple", Model = "iPhone 13", ReleaseYear = 2021 },
                new Smartphone { Id = 2, Brand = "Samsung", Model = "Galaxy S21", ReleaseYear = 2021 },
                new Smartphone { Id = 3, Brand = "Google", Model = "Pixel 6", ReleaseYear = 2021 },
                new Smartphone { Id = 4, Brand = "OnePlus", Model = "9 Pro", ReleaseYear = 2021 }
            };
            _nextId = _smartphones.Max(s => s.Id) + 1;
        }

        [HttpGet]
        public IEnumerable<Smartphone> Get()
        {
            return _smartphones;
        }

        [HttpGet("{id}")]
        public Smartphone? Get(int id)
        {
            return _smartphones.Find(s => s.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] Smartphone value)
        {
            value.Id = _nextId++;
            _smartphones.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Smartphone newSmartphone)
        {
            var smartphone = _smartphones.Find(s => s.Id == id);
            if (smartphone != null)
            {
                smartphone.Brand = newSmartphone.Brand;
                smartphone.Model = newSmartphone.Model;
                smartphone.ReleaseYear = newSmartphone.ReleaseYear;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var smartphone = _smartphones.Find(s => s.Id == id);
            if (smartphone != null)
            {
                _smartphones.Remove(smartphone);
            }
        }
    }
}