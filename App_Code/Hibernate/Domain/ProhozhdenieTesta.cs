using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class ProhozhdenieTesta {
        public virtual Lkabinet Lkabinet { get; set; }
        public virtual Dolzhnost Dolzhnost { get; set; }
        [NotNullNotEmpty]
        public virtual int Id { get; set; }
        public virtual int? Rezultat { get; set; }
        public virtual DateTime? Data { get; set; }
        [NotNullNotEmpty]
        public virtual int Status { get; set; }
        [NotNullNotEmpty]
        public virtual string NaimenovanieTesta { get; set; }
        public virtual int? Otpravlen { get; set; }
        public virtual int? Time { get; set; }
    }
}
