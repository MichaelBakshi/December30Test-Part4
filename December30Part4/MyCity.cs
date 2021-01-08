using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December30Part4
{
    class MyCity
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long District_ID { get; set; }
        public string Mayor { get; set; }
        public int? Population { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, District_ID: {District_ID}, Mayor: {Mayor}, Population: {Population}";
        }
    }
}
