using SalesManagementSystem.Untils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementSystem.Models
{
    public class ProductModel
    {
        public string  Id { get; set; }

        [Required(ErrorMessage = "Inform a name")]
        public string  Name { get; set; }

        [Required(ErrorMessage = "Inform a description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Inform a Price")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Inform a Quantity in Stock")]
        public decimal? Quantity_inStock { get; set; }
        [Required(ErrorMessage = "Inform a Unit")]
        public string Unit { get; set; }
        [Required(ErrorMessage = "Inform a Image")]
        public string Image { get; set; }


        public List<ProductModel> ListProducts()
        {
            List<ProductModel> productlist = new List<ProductModel>();
            ProductModel product;
            DAL dal = new DAL();
            string sql = "SELECT Id, Name, Description, Price, Quantity_inStock, Unit, Image FROM Product order by Name asc";
            DataTable dt = dal.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                product = new ProductModel
                {
                    Id = dt.Rows[i]["Id"].ToString(),
                    Name = dt.Rows[i]["Name"].ToString(),
                    Description = dt.Rows[i]["Description"].ToString(),
                    Price = decimal.Parse(dt.Rows[i]["Price"].ToString().Replace(",",".")),
                    Quantity_inStock = decimal.Parse(dt.Rows[i]["Quantity_inStock"].ToString()),
                    Unit = dt.Rows[i]["Unit"].ToString(),
                    Image = dt.Rows[i]["Image"].ToString(),

                };
                productlist.Add(product);
            }
            return productlist;
        }

        public ProductModel GetProduct(int? id)
        {
            ProductModel product;
            DAL dal = new DAL();
            string sql = $"SELECT Id, Name, Description, Price, Quantity_inStock, Unit, Image FROM Product where id='{id}' order by Name asc";
            DataTable dt = dal.RetDataTable(sql);

            product = new ProductModel
                {
                    Id = dt.Rows[0]["Id"].ToString(),
                    Name = dt.Rows[0]["Name"].ToString(),
                    Description = dt.Rows[0]["Description"].ToString(),
                    Price = decimal.Parse(dt.Rows[0]["Price"].ToString().Replace(",", ".")),
                    Quantity_inStock = decimal.Parse(dt.Rows[0]["Quantity_inStock"].ToString()),
                    Unit = dt.Rows[0]["Unit"].ToString(),
                    Image = dt.Rows[0]["Image"].ToString(),

            };
            return product;
        }

        public void Save()
        {
            DAL dal = new DAL();
            string sql;
            if (Id != null)
            {
                 sql = $"UPDATE INTO PRODUCT SET Name='{Name}',"+
                    $"Description='{Description}'" +
                    $"Price='{Price}'" +
                    $"Quantity_inStock='{Quantity_inStock}'" +
                    $"Unit='{Unit}'" +
                    $"Image='{Image}'" +
                    $"where Id='{Id}'";
            } else
            {
                 sql = $"INSERT INTO PRODUCT(Name, Description, Price, Quantity_inStock, Unit, Image ) VALUES ('{Name}', '{Description}', '{Price}', '{Quantity_inStock}', '{Unit}', '{Image}')";
            }
            
            dal.ExecuteSQLCommand(sql);
        }

        public void Delete(int id)
        {
            DAL dal = new DAL();
            string sql = $"DELETE FROM PRODUCT WHERE ID='{id}'";
            dal.ExecuteSQLCommand(sql);
        }
    }
}
