using System;
using System.Collections.Generic;
using System.Text;

namespace Teste_IB.Manage.Model
{
    public class Brand
    {
        public Brand()
        {

        }
        public Brand(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
        public int Id { get; set; }
        public string Nome { get; set; }

    }
}
