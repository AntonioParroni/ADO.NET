using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCodeFirst
{
    public class Task
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string Deadline { get; set; }
        public string Author { get; set; }
        public string Priority { get; set; }
    }
}
