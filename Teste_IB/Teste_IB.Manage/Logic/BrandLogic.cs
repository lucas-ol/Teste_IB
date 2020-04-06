using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using Teste_IB.Manage.Exceptions;
using Teste_IB.Manage.Model;

namespace Teste_IB.Manage.Logic
{
    public class BrandLogic : IDisposable
    {
        private readonly SqlConnection Connection;
        private readonly SqlCommand Cmd;
        public BrandLogic(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
            Cmd = new SqlCommand();
            Cmd.Connection = Connection;
        }

        public List<Patrimony> GetAllPatrimony()
        {
            List<Patrimony> patrimonies = new List<Patrimony>();
            try
            {
                Connection.Open();
                Cmd.CommandText = $"select * from Patrimony";
                Cmd.CommandType = System.Data.CommandType.Text;
                using (SqlDataReader rd = Cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Patrimony patrimony = new Patrimony();
                        patrimony.Id = rd.GetInt32(rd.GetOrdinal("id"));
                        patrimony.Nome = rd.GetString(rd.GetOrdinal("nome"));
                        patrimony.MarcaId = rd.GetInt32(rd.GetOrdinal("MarcaId"));
                        patrimony.Descricao = rd.GetString(rd.GetOrdinal("descricao"));
                        patrimony.NumeroTombo = rd.GetInt32(rd.GetOrdinal("numeroTombo"));
                        patrimonies.Add(patrimony);
                    }
                }
                return patrimonies;
            }
            finally
            {
                Connection.Close();
            }
        }

        public Patrimony GetPatrimonyById(int id)
        {
            try
            {
                Patrimony patrimony = new Patrimony();
                Connection.Open();
                Cmd.CommandText = $"select * from Patrimony where id ={id}";
                Cmd.CommandType = System.Data.CommandType.Text;
                using (SqlDataReader rd = Cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        patrimony.Id = rd.GetInt32(rd.GetOrdinal("id"));
                        patrimony.Nome = rd.GetString(rd.GetOrdinal("nome"));
                        patrimony.MarcaId = rd.GetInt32(rd.GetOrdinal("MarcaId"));
                        patrimony.Descricao = rd.GetString(rd.GetOrdinal("descricao"));
                        patrimony.NumeroTombo = rd.GetInt32(rd.GetOrdinal("numeroTombo"));
                    }
                }
                return patrimony;
            }
            finally
            {
                Connection.Close();
            }
        }

        public void CreatePatrimony(Patrimony patrimony)
        {
            try
            {
                Connection.Open();
                Cmd.CommandText = $" INSERT INTO patrimony (nome,MarcaId,descricao,numeroTombo)" +
                    $" VALUES ('{patrimony.Nome}', {patrimony.MarcaId},'{patrimony.Descricao}',{patrimony.CreateTomboNumber()}) ";
                Cmd.CommandType = System.Data.CommandType.Text;
                if (Cmd.ExecuteNonQuery() == 0)
                    throw new DataException("O patrimonio não foi inserido");
            }
            finally
            {
                Connection.Close();
            }
        }

        public void UpdatePatrimony(Patrimony patrimony)
        {
            try
            {
                Connection.Open();
                Cmd.CommandText = $" UPDATE patrimony SET nome = '{patrimony.Nome}', MarcaId = {patrimony.MarcaId}," +
                    $"descricao = '{patrimony.Descricao}' WHERE id = {patrimony.Id}";
                Cmd.CommandType = System.Data.CommandType.Text;
                if (Cmd.ExecuteNonQuery() == 0)
                    throw new DataException("O patrimonio não foi atualizado");
            }
            finally
            {
                Connection.Close();
            }
        }

        public void DeletePatrimony(int id)
        {
            try
            {
                Connection.Open();
                Cmd.CommandText = $"DELETE FROM patrimony WHERE id = {id}";
                Cmd.CommandType = System.Data.CommandType.Text;
                if (Cmd.ExecuteNonQuery() == 0)
                    throw new DataException("O patrimonio não foi removido");
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<Patrimony> GetPatrimonyByBrandId(int brandId)
        {
            List<Patrimony> patrimonies = new List<Patrimony>();
            try
            {

                Connection.Open();
                Cmd.CommandText = $"select * from Patrimony where marcaId = {brandId}";
                Cmd.CommandType = System.Data.CommandType.Text;
                using (SqlDataReader rd = Cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Patrimony patrimony = new Patrimony();
                        patrimony.Id = rd.GetInt32(rd.GetOrdinal("id"));
                        patrimony.Nome = rd.GetString(rd.GetOrdinal("nome"));
                        patrimony.MarcaId = rd.GetInt32(rd.GetOrdinal("MarcaId"));
                        patrimony.Descricao = rd.GetString(rd.GetOrdinal("descricao"));
                        patrimony.NumeroTombo = rd.GetInt32(rd.GetOrdinal("numeroTombo"));
                        patrimonies.Add(patrimony);
                    }
                }
                return patrimonies;
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<Brand> GetAllBrand()
        {
            List<Brand> brands = new List<Brand>();
            try
            {

                Connection.Open();
                Cmd.CommandText = $"select * from brand";
                Cmd.CommandType = System.Data.CommandType.Text;
                using (SqlDataReader rd = Cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Brand brand = new Brand();
                        brand.Id = rd.GetInt32(rd.GetOrdinal("id"));
                        brand.Nome = rd.GetString(rd.GetOrdinal("nome"));
                        brands.Add(brand);
                    }
                }
                return brands;
            }
            finally
            {
                Connection.Close();
            }
        }

        public Brand GetBrandById(long id)
        {
            try
            {
                Brand brand = new Brand();
                Connection.Open();
                Cmd.CommandText = $"select * from brand where id = {id}";
                Cmd.CommandType = System.Data.CommandType.Text;
                using (SqlDataReader rd = Cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        brand.Id = rd.GetInt32(rd.GetOrdinal("id"));
                        brand.Nome = rd.IsDBNull(rd.GetOrdinal("Nome")) ? "" : rd.GetString(rd.GetOrdinal("nome"));
                    }
                }
                return brand;
            }
            finally
            {
                Connection.Close();
            }
        }

        public void CreateBrand(string brandName)
        {
            try
            {
                Connection.Open();
                Cmd.CommandText = $"insert into brand(nome) values ('{brandName}') ";
                Cmd.CommandType = System.Data.CommandType.Text;
                if (Cmd.ExecuteNonQuery() == 0)
                    throw new DataException("A linha não foi inserida");
            }

            finally
            {
                Connection.Close();
            }
        }
        public void UpdateBrand(Brand brand)
        {
            try
            {
                Connection.Open();
                Cmd.CommandText = $" UPDATE brand SET [nome] = '{brand.Nome}' WHERE id = {brand.Id}";
                Cmd.CommandType = System.Data.CommandType.Text;
                if (Cmd.ExecuteNonQuery() == 0)
                    throw new DataException("Marca não encontrada");

            }
            finally
            {
                Connection.Close();
            }
        }

        public bool DeleteBrand(int brandId)
        {
            try
            {
                Connection.Open();
                Cmd.CommandText = $" delete from brand WHERE id = {brandId}";
                Cmd.CommandType = System.Data.CommandType.Text;
                return Cmd.ExecuteNonQuery() == 0;
            }
            finally
            {
                Connection.Close();
            }
        }

        #region Dispose
        bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            Connection.Dispose();
            Cmd.Dispose();
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            disposed = true;
        }
        #endregion
    }
}
