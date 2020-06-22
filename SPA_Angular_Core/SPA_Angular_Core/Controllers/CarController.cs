using Microsoft.AspNetCore.Mvc;
using SPA_Angular_Core.DAL.Models;
using SPA_Angular_Core.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPA_Angular_Core.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : Controller
    {
        CarShopContext db;
        public CarController(CarShopContext context)
        {
            db = context;
            if (!db.Cars.Any())
            {
                db.Cars.Add(new Car {Model = "Aston" });
                db.Cars.AddRange(
                new Car { Model = "Honda" },
                new Car { Model = "BMW" },
                new Car { Model = "Audi" },
                new Car { Model = "Vaz" },
                new Car { Model = "Buick" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Car> GetCars()
        {
            var result = db.Cars.ToList();
            return result;
        }

        [HttpGet("{id}")]
        public Car GetCar(int id)
        {
            return db.Cars.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return Ok(car);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult EditCar(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Update(car);
                db.SaveChanges();
                return Ok(car);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var car = db.Cars.FirstOrDefault(x => x.Id == id);
            if (car != null)
            {
                db.Cars.Remove(car);
                db.SaveChanges();
            }

            return Ok(car);
        }
    }
}
