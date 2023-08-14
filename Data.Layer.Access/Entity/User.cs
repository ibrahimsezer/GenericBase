using Data.Layer.Access.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Layer.Access.Entity
{
    public class User
    {
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; }
        public int Information { get; set; }
        public UserInfo UserInformation { get; set; }
    }
}
