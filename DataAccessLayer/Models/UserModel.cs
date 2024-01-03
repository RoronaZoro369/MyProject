using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
    }
}
