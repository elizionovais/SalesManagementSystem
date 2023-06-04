using SalesManagementSystem.Untils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementSystem.Models
{
    public class SellerModel
    {
        public string  Id { get; set; }

        [Required(ErrorMessage = "Inform a name")]
        public string  Name { get; set; }

        [Required(ErrorMessage = "Inform a email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string  Email { get; set; }
        public string  Password { get; set; }

        public List<SellerModel> ListSellers()
        {
            List<SellerModel> list = new List<SellerModel>();
            SellerModel seller;
            DAL dal = new DAL();
            string sql = "SELECT Id, Name, Cpf_cnpj, Email, Password FROM Seller order by Name asc";
            DataTable dt = dal.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                seller = new SellerModel
                {
                    Id = dt.Rows[i]["Id"].ToString(),
                    Name = dt.Rows[i]["Name"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    Password = dt.Rows[i]["Password"].ToString(),

                };
                list.Add(seller);
            }
            return list;
        }

        public SellerModel GetSeller(int? id)
        {
            SellerModel seller;
            DAL dal = new DAL();
            string sql = $"SELECT Id, Name, Cpf_cnpj, Email, Password FROM Seller where id='{id}' order by Name asc";
            DataTable dt = dal.RetDataTable(sql);

                seller = new SellerModel
                {
                    Id = dt.Rows[0]["Id"].ToString(),
                    Name = dt.Rows[0]["Name"].ToString(),
                    Email = dt.Rows[0]["Email"].ToString(),
                    Password = dt.Rows[0]["Password"].ToString(),

                };
            return seller;
        }

        public void Save()
        {
            DAL dal = new DAL();
            string sql;
            if (Id != null)
            {
                 sql = $"UPDATE INTO SELLER SET Name='{Name}', Email='{Email}' where Id='{Id}'";
            } else
            {
                 sql = $"INSERT INTO SELLER(Name, Cpf_cnpj, Email, Password) VALUES ('{Name}', '{Email}','123456' )";
            }
            
            dal.ExecuteSQLCommand(sql);
        }

        public void Delete(int id)
        {
            DAL dal = new DAL();
            string sql = $"DELETE FROM SELLER WHERE ID='{id}'";
            dal.ExecuteSQLCommand(sql);
        }
    }
}
