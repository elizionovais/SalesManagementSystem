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
        public DateTime Date { get; set; }
        public string Seller_Id { get; set; }
        public string ListProducts { get; set; }
        public double Total { get; set; }

        public List<SaleModel> ListSales(string FirstDate, string FinalDate)
        {
           return ReturnListSales(FirstDate, FinalDate);

        }
        public List<SaleModel> ListSales()
        {
            return ReturnListSales("1900/01/01", "2222/01/01");
        }
        public List<SaleModel> ReturnListSales(string FirstDate, string FinalDate)
        {
            List<SaleModel> salelist = new List<SaleModel>();
            SaleModel sale;
            DAL dal = new DAL();
            string sql = "select v1.id, v1.date, vi1.total, v2.name as seller, c.name as client from" +
                "sale v1 inner join seller v2 on v1.seller_id = v2.id inner join client c" +
                "on v1.client_id = c.id" +
                $"where v1.date >= '{FirstDate}' and v1.date <= '{FinalDate}'" +
                "order by date, total";
            DataTable dt = dal.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sale = new SaleModel
                {
                    Id = dt.Rows[i]["Id"].ToString(),
                    Date = DateTime.Parse(dt.Rows[i]["Date"].ToString()),
                    Total = double.Parse(dt.Rows[i]["Total"].ToString().Replace(",", ".")),
                    Client_Id = dt.Rows[i]["Client_Id"].ToString(),
                    Seller_Id = dt.Rows[i]["Seller_Id"].ToString(),

                };
                salelist.Add(sale);
            }
            return salelist;
        }

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


                //Update stock
                sql = "update Product" +
                    $"set Quantity_inStock = (Quantity_inStock - " + int.Parse(list_products[i].Qtd) + ")" +
                    $"where id = {list_products[i].code}";
                dal.ExecuteSQLCommand(sql);


            }
        }
    }
}
