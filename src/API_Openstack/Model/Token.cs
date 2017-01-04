using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Openstack.Model
{
    public class Token
    {
        public auth auth { get; set; }

        public Token(string user, string password, string project_id)
        {
            this.auth = new auth(user, password, project_id);
        }        
    }

    public class auth
    {
        public identity identity { get; set; }
        public scope scope { get; set; }

        internal auth(string user, string password, string project_id)
        {
            this.identity = new identity(user, password);
            this.scope = new scope(project_id);
        }
                
    }

   
    public class identity
    {
        public string[] methods { get; set; }
        public password password { get; set; }

        internal identity(string user,string password)
        {
            this.methods = new string[1];
            this.methods[0] = "password";
            this.password = new password(user, password); 
        }
    } 

    public class password
    {
        public user user;
        internal password(string user, string password)
        {
            this.user = new user(user, password);
        }

    }

    public class user
    {
        public string name { get; set; }
        public domain domain { get; set; }
        public string password { get; set; }

        internal user(string user, string password)
        {
            this.name = user;
            this.domain = new domain();
            this.password = password;
        }
    } 

    public class domain
    {
        public string name { get; set; }
        internal domain()
        {
            this.name = "default";
        }
    }

    public class scope
    {
        public project project { get; set; }
        internal scope(string project_id)
        {
            this.project = new project(project_id);
        }
    }

    public class project
    {
        public string id { get; set; }
        internal project(string project_id)
        {
            this.id = project_id;
        }
    }
}
