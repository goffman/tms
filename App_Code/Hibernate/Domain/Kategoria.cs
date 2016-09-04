using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Kategoria {
        [NotNullNotEmpty]
        public virtual int Id { get; set; }
        public virtual string Kategoriaval { get; set; }
    }
}
