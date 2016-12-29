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
        public ip addresses { get; set; }
    }

    public class ip
    {
        public ip_interna interna { get; set; }
    }
    public class ip_interna
    {
        public string addr { get; set; }
    }
    
   
}
