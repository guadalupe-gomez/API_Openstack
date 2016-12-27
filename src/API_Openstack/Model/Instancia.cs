using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Openstack.Model
{
    public class Instancia
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class RootInstancias 
    {
        public List<Instancia> servers { get; set; }
       
    }

   
}
