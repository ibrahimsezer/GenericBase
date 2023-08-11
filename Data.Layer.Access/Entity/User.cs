using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Layer.Access.Entity
{
    public class User <T> where T : class
    {
        public int Id { get; set; }
        public int InfoId { get; set; }//Product için koyuldu.
        public ICollection<Product> Products { get; set; }

        public UserInfo Info { get; set; }  
    }
}
