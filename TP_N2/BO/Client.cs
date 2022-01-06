using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_N2.BO
{
    class Client
    {
        public Client() { }
        public Client(int id,string name) { ID = id; Name = name; }
        public int ID { get; set; }
        public string Name{ get; set; }
    }
}
