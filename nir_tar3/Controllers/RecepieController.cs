using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassLibrary1;
using nir_tar3.DTO;



namespace nir_tar3.Controllers
{
    public class RecepieController : ApiController
    {
        cgroup94DbContext db = new cgroup94DbContext();
        // GET: api/Recepie
        public IHttpActionResult Get()
        {
            cgroup94DbContext db = new cgroup94DbContext();       

            var list = from recpie1 in db.recepies
                       select new recepieDTO()
                       {
                           id = recpie1.id,
                           name = recpie1.name,
                           image = recpie1.image,
                           cookingMethod = recpie1.cookingMethod,
                           time = recpie1.time,
                           Ingridients = recpie1.ingridients.Select(x => new IngridientDto()
                           {
                               id = x.id,
                               name = x.name,
                               calories = x.calories,
                               image = x.image
                           }
                           ).ToList()
                       };

            
            return Ok(list);
        }

        // GET: api/Recepie/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Recepie
        public IHttpActionResult Post([FromBody] recepieDTO value)
        {
            try
            {
                recepieDTO i = value;
                recepie x = new recepie();
                x.name = i.name;
                x.image = i.image;
                x.time = i.time;
                x.cookingMethod = i.cookingMethod;
                List<ingridient> ing = new List<ingridient>();
                foreach (IngridientDto item in i.Ingridients)
                {
                    ing.Add(db.ingridients.FirstOrDefault(y => y.id == item.id));
                }
                x.ingridients = ing;
                db.recepies.Add(x);
                db.SaveChanges();
                return Ok();
                // return Created(new Uri(Request.RequestUri.AbsoluteUri + i.recipeId), i);
            }
            catch (Exception ex)
            {
                return (BadRequest(ex.Message));
            }
        }

        // PUT: api/Recepie/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Recepie/5
        public void Delete(int id)
        {
        }
    }
}
