using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_IB.Manage.Logic;
using Teste_IB.Manage.Model;
using Teste_IB.Manage.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teste_IB.Host.Controllers
{
    [Route("api/[controller]")]
    public class MarcaController : Controller
    {
        private readonly string ConnectionString;
        public MarcaController(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("default");
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            using (BrandLogic logic = new BrandLogic(ConnectionString))
            {
                return logic.GetAllBrand();
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}/patrimonios")]
        public Brand Get(int id)
        {
            using (BrandLogic logic = new BrandLogic(ConnectionString))
            {
                return logic.GetBrandById(id);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string name)
        {
            using (BrandLogic logic = new BrandLogic(ConnectionString))
            {
                logic.CreateBrand(name);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string name)
        {
            using (BrandLogic logic = new BrandLogic(ConnectionString))
            {
                logic.UpdateBrand(new Brand(id, name));
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (BrandLogic logic = new BrandLogic(ConnectionString))
            {
                logic.DeleteBrand(id);
            }
        }
    }
}
