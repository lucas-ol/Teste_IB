using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_IB.Manage.Logic;
using Teste_IB.Manage.Model;
using Teste_IB.Manage.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Teste_IB.Host.Model.Brand;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teste_IB.Host.Controllers
{
    [Route("[controller]")]
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
        [HttpGet("{id}")]
        public Brand GetById(int id)
        {
            using (BrandLogic logic = new BrandLogic(ConnectionString))
            {
                return logic.GetBrandById(id);
            }
        }


        [HttpGet("{id}/patrimonios")]
        public IEnumerable<Patrimony> Get(int id)
        {
            using (BrandLogic logic = new BrandLogic(ConnectionString))
            {
                return logic.GetPatrimonyByBrandId(id);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]CreateBrandInput input)
        {
            using (BrandLogic logic = new BrandLogic(ConnectionString))
            {
                logic.CreateBrand(input.Nome);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]CreateBrandInput input)
        {
            using (BrandLogic logic = new BrandLogic(ConnectionString))
            {
                logic.UpdateBrand(new Brand(id, input.Nome));
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
