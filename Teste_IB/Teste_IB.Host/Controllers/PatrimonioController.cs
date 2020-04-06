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
    [Route("api/[controller]")]
    public class PatrimonioController : Controller
    {
        private readonly string ConnectionString;
        private readonly ILogger logger;
        public PatrimonioController(IConfiguration configuration, ILogger logger)
        {
            ConnectionString = configuration.GetConnectionString("default");
            this.logger = logger;
        }
        // GET: api/<controller>
        [HttpGet]
        public IList<Patrimony> Get()
        {
            try
            {
                using (BrandLogic logic = new BrandLogic(ConnectionString))
                {
                    return logic.GetAllPatrimony();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Patrimony Get(int id)
        {
            try
            {
                using (BrandLogic logic = new BrandLogic(ConnectionString))
                {
                    return logic.GetPatrimonyById(id);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]CreatePatrimonyInput value)
        {
            try
            {
                using (BrandLogic logic = new BrandLogic(ConnectionString))
                {
                    logic.CreatePatrimony(new Patrimony(value.Nome, value.MarcaId, value.descricao));
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]UpdatePatrimonyInput value)
        {
            try
            {
                using (BrandLogic logic = new BrandLogic(ConnectionString))
                {
                    logic.UpdatePatrimony(new Patrimony(value.Id, value.Nome, value.MarcaId, value.descricao));
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                using (BrandLogic logic = new BrandLogic(ConnectionString))
                {
                    logic.DeletePatrimony(id);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
