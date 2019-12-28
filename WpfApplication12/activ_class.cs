using System.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication12
{
    public class activ_class
    {
            
        private int id;
        private string designation;
        private string type;
        private int id_user;
        public activ_class(int id, string designation, string type, int id_user)
        {
            this.id = id;
            this.designation = designation;
            this.type = type;
            this.id_user = id_user;
        }
        public int get_id()
        {
            return (id);
        }
        public string get_designation()
        {
            return (this.designation);
        }
        public string get_type()
        {
            return (this.type);
        }

        public void set_designation(string designation)
        {
            this.designation = designation;
        }
        public void set_type(string type)
        {
            this.type = type;
        }
        public int get_id_user()
        {
            return (id_user);
        }
        
    }
}

