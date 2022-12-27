using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_ef_optimisation.Models
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public List<Game> Games { get; set; }
    }
}
