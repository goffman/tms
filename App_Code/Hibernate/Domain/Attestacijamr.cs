using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Attestacijamr {
        public virtual int ID
        {
            get; set
                ; }
        public virtual Lpu Lpu { get; set; }
        public virtual Dolzhnost Dolzhnost { get; set; }
        public virtual string F { get; set; }
        public virtual string I { get; set; }
        public virtual string O { get; set; }
        public virtual DateTime? Dataattestacii { get; set; }
    }
}
