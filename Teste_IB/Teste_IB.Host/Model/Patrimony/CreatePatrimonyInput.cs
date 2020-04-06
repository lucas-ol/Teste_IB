using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_IB.Host.Model.Patrimony
{
    public class CreatePatrimonyInput
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public int MarcaId { get; set; }
        public string descricao { get; set; }
    }
}
