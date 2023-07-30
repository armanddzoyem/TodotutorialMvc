using Microsoft.AspNetCore.Mvc;
using TodoTutorial.Models.Domain;

namespace TodoTutorial.Controllers
{
	public class PersonController : Controller
    {
        private readonly DatabaseContext _ctx ;
        public PersonController(DatabaseContext ctx) 
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            ViewBag.greeting = "Hello World";
            ViewData["greeting2"] = "I am using ViewData";
            TempData["greeting3"] = "It's a TempData msg";
            return View();
        }
        //get method
        [HttpGet]
        public IActionResult AddPerson()
        {
            return View();
        }
        //post method
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
			try
            {
                _ctx.Person.Add(person);
                _ctx.SaveChanges();
                TempData["msg"] = "Added succefully";
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "could not Added!!!";
                return View();
            }
        }



        public IActionResult EditPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.Person.Update(person);
                _ctx.SaveChanges();
                TempData["msg"] = "Updated succefully";
                return RedirectToAction("DisplayPersons");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "could not Updated!!!";
                return View();
            }
        }
       
        
        public IActionResult DisplayPersons()
        {
            var persons = _ctx.Person.ToList();
            return View(persons);
        }




        public IActionResult DeletePerson(int id)
        {
            try
            {
                var person = _ctx.Person.Find(id);
                if (person != null) 
                {
                    _ctx.Person.Remove(person);
                    _ctx.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                
            }


            return RedirectToAction("DisplayPersons");
        }
    }
}
