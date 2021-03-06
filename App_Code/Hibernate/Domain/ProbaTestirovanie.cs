using System;
using System.Text;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class ProbaTestirovanie {
        public virtual int ID { get; set; }
        public virtual Lkabinet Lkabinet { get; set; }
        [NotNullNotEmpty]
        public virtual int IdVopros { get; set; }
        public virtual int? IdOtvet { get; set; }
    }
}
