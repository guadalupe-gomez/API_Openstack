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
       // public string status { get; set; }
    }

    public class RootInstancias 
    {
        public List<Instancia> servers { get; set; }        
       
    }

    public class UnaInstancia
    {
        public Instancia2 server { get; set; }
    }

    public class Instancia2
    {
        public string name { get; set; }
        public string id { get; set; }
        public string status { get; set; }
        public string created { get; set; }
        public FlavorID flavor { get; set; }
    }

    public class FlavorID
    {
        public string id { get; set; }
        public Flavor flavor { get; set; }
              
    }

    public class Flavor
    {
        public string name { get; set; } 
        public string ram { get; set; }
        public string vcpus { get; set; }
        public string disk { get; set; }
    }
    
   
}
