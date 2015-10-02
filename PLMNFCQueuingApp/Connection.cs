using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLMNFCQueuingApp
{
    class Connection
    {

        public string Connect = @"Data Source=GERARD-PC\SQL2012;Initial Catalog=NFCProject;Persist Security Info=True;User ID=sa;Password=admin@sql2012";
        
        public string ConnectionString
        {
            get { return Connect; }
        }
    }
}
