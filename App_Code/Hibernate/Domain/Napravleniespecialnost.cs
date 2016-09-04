using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Napravleniespecialnost {
        public virtual  int ID { get; set; }
        [NotNullNotEmpty]
        public virtual int IdNapravlenie { get; set; }
        [NotNullNotEmpty]
        public virtual int IdSpecialnost { get; set; }
    }
}
