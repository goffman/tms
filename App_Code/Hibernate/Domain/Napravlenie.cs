using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Napravlenie {

        [NotNullNotEmpty]
        public virtual int IdNapravlenie { get; set; }
        [NotNullNotEmpty]
        public virtual string Napravlenieval { get; set; }
    }
}
