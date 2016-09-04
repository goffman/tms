using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Applicationnullingtestresult {
        [NotNullNotEmpty]
        public virtual int Id { get; set; }
        [NotNullNotEmpty]
        public virtual DateTime Date { get; set; }
        [NotNullNotEmpty]
        public virtual int Idaccount { get; set; }
        [NotNullNotEmpty]
        public virtual string Rationale { get; set; }
        public virtual int? Status { get; set; }
        public virtual DateTime? Datedecision { get; set; }
    }
}
