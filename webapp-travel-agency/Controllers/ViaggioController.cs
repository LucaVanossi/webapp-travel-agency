using webapp_travel_agency.Data;
using webapp_travel_agency.Models;
using webapp_travel_agency.Utils;
using Microsoft.AspNetCore.Mvc;

namespace webapp_travel_agency.Controllers
{

    public class ViaggioController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Viaggio> viaggi = new List<Viaggio>();

            using (BlogContext db = new BlogContext())
            {
                viaggi = db.Viaggi.ToList<Viaggio>();
            }


            return View("HomePage", viaggi);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            using (BlogContext db = new BlogContext())
            {
                try
                {
                    Viaggio viaggioFound = db.Viaggi
                         .Where(pViaggio => pViaggio.Id == id)
                         .First();

                    return View("Details", viaggioFound);

                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("Il post con id " + id + " non è stato trovato");
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }


            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("FormViaggio");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Viaggio nuovoViaggio)
        {
            if (!ModelState.IsValid)
            {
                return View("FormViaggio", nuovoViaggio);
            }

            using (BlogContext db = new BlogContext())
            {
                Viaggio viaggioToCreate = new Viaggio(nuovoViaggio.Name, nuovoViaggio.Description, nuovoViaggio.Image);

                db.Viaggi.Add(viaggioToCreate);
                db.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Viaggio viaggioToEdit = null;

            using (BlogContext db = new BlogContext())
            {
                viaggioToEdit = db.Viaggi
                         .Where(pViaggio => pViaggio.Id == id)
                         .First();
            }

            if (viaggioToEdit == null)
            {
                return NotFound();
            }
            else
            {
                return View("Update", viaggioToEdit);
            }
        }

        [HttpPost]
        public IActionResult Update(int id, Viaggio modello)
        {
            if (!ModelState.IsValid)
            {
                return View("FormViaggio", modello);
            }

            Viaggio viaggioToEdit = null;

            using (BlogContext db = new BlogContext())
            {
                viaggioToEdit = db.Viaggi
                         .Where(pViaggi => pViaggi.Id == id)
                         .First();

                db.SaveChanges();

                if (viaggioToEdit != null)
                {
                    viaggioToEdit.Name = modello.Name;
                    viaggioToEdit.Description = modello.Description;
                    viaggioToEdit.Image = modello.Image;



                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }

            }

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            using (BlogContext db = new BlogContext())
            {
                Viaggio viaggioToDelete = db.Viaggi
                         .Where(pViaggio => pViaggio.Id == id)
                         .First();

                if (viaggioToDelete != null)
                {
                    db.Viaggi.Remove(viaggioToDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }

        }



    }


}
