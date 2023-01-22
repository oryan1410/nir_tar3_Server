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
    public class IngridientController : ApiController
    {
        cgroup94DbContext db = new cgroup94DbContext();
        // GET: api/Ingridient
        public IHttpActionResult  Get()
        {
            var list = db.ingridients.Select(ing => new IngridientDto()
            {
                id = ing.id,
                name = ing.name,
                calories = ing.calories,
                image = ing.image
                
            }).ToList();


            return Ok(list);
        }

        // GET: api/Ingridient/5
        public ingridient [] Get(int id)
        {
            return db.recepies.SingleOrDefault(x => x.id == id).ingridients.ToArray();
        }

        // POST: api/Ingridient
        public IHttpActionResult Post([FromBody]ingridient i)
        {
            try
            {                
                db.ingridients.Add(i);
                db.SaveChanges();
                return Ok("succesfull!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }

        // PUT: api/Ingridient/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ingridient/5
        public void Delete(int id)
        {
        }
    }
}
