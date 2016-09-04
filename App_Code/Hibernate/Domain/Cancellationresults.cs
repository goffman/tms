using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Cancellationresults {
        public virtual int Id { get; set; }
        [NotNullNotEmpty]
        public virtual int Accountid { get; set; }
        [NotNullNotEmpty]
        public virtual DateTime Date { get; set; }
        [NotNullNotEmpty]
        public virtual int Idadmin { get; set; }
        [NotNullNotEmpty]
        public virtual string Reason { get; set; }
        public virtual int? Resulttest { get; set; }
    }
}
