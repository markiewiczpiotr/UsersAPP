using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastStart.Entities
{
    public class Roles
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int? UsersId { get; set; }
        public virtual Users Users { get; set; }
    }
}

