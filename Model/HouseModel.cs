using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.Model
{
    class HouseModel
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public double Price { get; set; }
        public String PictureUrl { get; set; }
        public String HostName { get; set; }
        public String HostPictureUrl { get; set; }
        public String HostLocation { get; set; }
    }
}
