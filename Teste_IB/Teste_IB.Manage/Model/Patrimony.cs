using System;
using System.Collections.Generic;
using System.Text;

namespace Teste_IB.Manage.Model
{
    public class Patrimony
    {
        public Patrimony()
        {

        }
        public Patrimony(string nome, int marcaId, string descricao)
        {
            this.Nome = nome;
            this.MarcaId = marcaId;
            this.Descricao = descricao;

        }
        public Patrimony(int id, string nome, int marcaId, string descricao)
        {
            this.Id = id;
            this.Nome = nome;
            this.MarcaId = marcaId;
            this.Descricao = descricao;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MarcaId { get; set; }
        public string Descricao { get; set; }
        public int NumeroTombo { get; set; }
        public int CreateTomboNumber()
        {
            Random rd = new Random();
            return rd.Next();
        }
    }
}
