using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Voprosy {
        public virtual int IdVoprosy { get; set; }
        public virtual int? Specialnost { get; set; }
        public virtual string Vopros { get; set; }
        public virtual int? Kategoria { get; set; }
    }
}
