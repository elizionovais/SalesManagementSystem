using Newtonsoft.Json;
using SalesManagementSystem.Untils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementSystem.Models
{
    public class SaleModel
    {
        public string Id { get; set; }
        public string Client_Id { get; set; }
        public string Seller_Id { get; set; }
        public string ListProducts { get; set; }
        public double Total { get; set; }

        public List<ClientModel> ReturnListClients()
        {
            return new ClientModel().ListClients();
        }
        public List<SellerModel> ReturnListSellers()
        {
            return new SellerModel().ListSellers();
        }

        public List<ProductModel> ReturnListProducts()
        {
            return new ProductModel().ListProducts();
        }

        public void Insert()
        {
            DAL dal = new DAL();

            string dateSale = DateTime.Now.Date.ToString("yyyy/MM/dd");
            string sql = "INSERT INTO SALE (Date, Total, Seller_Id, Client_Id)" +
                $"VALUES('{dateSale}', '{Total.ToString().Replace(",",".")}', '{Seller_Id}', '{Client_Id}')";
            dal.ExecuteSQLCommand(sql);

            sql = $"SELECT to id from sale where date='{dateSale}' and Seller_Id='{Seller_Id}' and Client_Id='{Client_Id}' order by id desc limit 1";
            DataTable dt = dal.RetDataTable(sql);
            string id_sale = dt.Rows[0]["id"].ToString();

            List<ItemSaleModel> list_products = JsonConvert.DeserializeObject<List<ItemSaleModel>>(ListProducts);
            for (int i = 0; i < list_products.Count; i++)
            {
                sql = "INSERT into sale_product (Sale_Id, Product_Id, Quantity_Product, Price_Product)" +
                    $"values ({id_sale}, {list_products[i].code}," +
                    $"{list_products[i].Qtd}," +
                    $"{list_products[i].Price.Replace(",",".")})";
                dal.ExecuteSQLCommand(sql);

            }
        }
    }
}
