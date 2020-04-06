using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Teste_IB.Host.Model.Patrimony;
using Teste_IB.Manage.Logic;
using Teste_IB.Manage.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teste_IB.Host.Controllers
{
    [Route("[controller]")]
    public class PatrimonioController : Controller
    {
        private readonly string ConnectionString;

        public PatrimonioController(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("default");
        }
        // GET: api/<controller>
        [HttpGet]
        public IList<Patrimony> Get()
        {

            using (BrandLogic logic = new BrandLogic(ConnectionString))
            {
                return logic.GetAllPatrimony();
            }

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Patrimony Get(int id)
        {
            using (BrandLogic logic = new BrandLogic(ConnectionString))
            {
                return logic.GetPatrimonyById(id);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]CreatePatrimonyInput value)
        {
            using (BrandLogic logic = new BrandLogic(ConnectionString))
            {
                logic.CreatePatrimony(new Patrimony(value.Nome, value.MarcaId, value.descricao));
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]UpdatePatrimonyInput value)
        {
            using (BrandLogic logic = new BrandLogic(ConnectionString))
            {
                logic.UpdatePatrimony(new Patrimony(id, value.Nome, value.MarcaId, value.descricao));
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (BrandLogic logic = new BrandLogic(ConnectionString))
            {
                logic.DeletePatrimony(id);
            }
        }
    }
}
