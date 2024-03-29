﻿using SalesManagementSystem.Untils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementSystem.Models
{
    public class ClientModel
    {
        public string  Id { get; set; }

        [Required(ErrorMessage = "Inform a name")]
        public string  Name { get; set; }

        [Required(ErrorMessage = "Inform a CPF or CNPJ")]
        public string  CPF { get; set; }

        [Required(ErrorMessage = "Inform a email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string  Email { get; set; }
        public string  Password { get; set; }

        public List<ClientModel> ListClients()
        {
            List<ClientModel> list = new List<ClientModel>();
            ClientModel client;
            DAL dal = new DAL();
            string sql = "SELECT Id, Name, Cpf_cnpj, Email, Password FROM Client order by Name asc";
            DataTable dt = dal.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                client = new ClientModel
                {
                    Id = dt.Rows[i]["Id"].ToString(),
                    Name = dt.Rows[i]["Name"].ToString(),
                    CPF = dt.Rows[i]["Cpf_cnpj"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    Password = dt.Rows[i]["Password"].ToString(),

                };
                list.Add(client);
            }
            return list;
        }

        public ClientModel GetClient(int? id)
        {
            ClientModel client;
            DAL dal = new DAL();
            string sql = $"SELECT Id, Name, Cpf_cnpj, Email, Password FROM Client where id='{id}' order by Name asc";
            DataTable dt = dal.RetDataTable(sql);

                client = new ClientModel
                {
                    Id = dt.Rows[0]["Id"].ToString(),
                    Name = dt.Rows[0]["Name"].ToString(),
                    CPF = dt.Rows[0]["Cpf_cnpj"].ToString(),
                    Email = dt.Rows[0]["Email"].ToString(),
                    Password = dt.Rows[0]["Password"].ToString(),

                };
            return client;
        }

        public void Save()
        {
            DAL dal = new DAL();
            string sql;
            if (Id != null)
            {
                 sql = $"UPDATE INTO CLIENT SET Name='{Name}', Cpf_cnpj='{CPF}', Email='{Email}' where Id='{Id}'";
            } else
            {
                 sql = $"INSERT INTO CLIENT(Name, Cpf_cnpj, Email, Password) VALUES ('{Name}', '{CPF}', '{Email}','123456' )";
            }
            
            dal.ExecuteSQLCommand(sql);
        }

        public void Delete(int id)
        {
            DAL dal = new DAL();
            string sql = $"DELETE FROM CLIENT WHERE ID='{id}'";
            dal.ExecuteSQLCommand(sql);
        }
    }
}
