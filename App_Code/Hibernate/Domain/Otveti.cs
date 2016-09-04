using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Otveti {
        public virtual int Id { get; set; }
        public virtual string Otvet { get; set; }
        [NotNullNotEmpty]
        public virtual int Vernyj { get; set; }
        public virtual int? IdVoprosy { get; set; }
    }
}
