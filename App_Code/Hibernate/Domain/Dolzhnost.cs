using System;
using System.Text;
using System.Collections.Generic;
using FluentNHibernate.Mapping;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class Dolzhnost {
        public Dolzhnost() { }
        public virtual int Id { get; set; }
        public virtual GruppaDolzhnost GruppaDolzhnost { get; set; }
        [NotNullNotEmpty]
        public virtual string Dolzhnostval { get; set; }
        public virtual int? Correctly { get; set; }
    }

    public class DolzhnostMap : ClassMap<Dolzhnost>
    {

        public DolzhnostMap()
        {
            Table("dolzhnost");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            References(x => x.GruppaDolzhnost).Column("gruppa");
            Map(x => x.Dolzhnostval).Column("dolzhnost").Not.Nullable();
            Map(x => x.Correctly).Column("correctly");
        }
    }
}
