using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class RecoveryPassword {
        public virtual int ID
        {
            get; set
                ; }
        public virtual int? IdUser { get; set; }
        public virtual string Hash { get; set; }
        public virtual DateTime? DateRecovery { get; set; }
    }
}
