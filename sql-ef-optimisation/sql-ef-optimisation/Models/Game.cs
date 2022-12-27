using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_ef_optimisation.Models
{
    public class Game
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public  bool IsDeleted { get; set; }
        public double Cost { get; set; }
        public int ActionPercent { get; set; }
        public bool IsAction { get; set; }
    }
}
