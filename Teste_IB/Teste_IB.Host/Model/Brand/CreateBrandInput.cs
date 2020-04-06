using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_IB.Host.Model.Brand
{
    public class CreateBrandInput
    {
        [Required]
        public string Nome { get; set; }
    }
}
