using SalesManagementSystem.Untils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementSystem.Models
{
    public class LoginModel
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        [Required(ErrorMessage="Type user email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Type your password")]
        public string Password { get; set; }

        public bool ValidateLogin()
        {
            string sql = $"SELECT ID FROM SELLER WHERE EMAIL='{Email}' AND PASSWORD='{Password}'";

            DAL dal = new DAL();
            DataTable dt = dal.RetDataTable(sql);
            if(dt.Rows.Count == 1)
            {

                Id = dt.Rows[0]["ID"].ToString();
                Nome = dt.Rows[0]["NAME"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
