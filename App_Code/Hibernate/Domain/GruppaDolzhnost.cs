using System;
using System.Text;
using System.Collections.Generic;
using FluentNHibernate.Mapping;
using NHibernate.Validator.Constraints;


namespace Hibernate.Domain {
    
    public class GruppaDolzhnost {
        public GruppaDolzhnost() { }
        public virtual int Id { get; set; }
        public virtual string Gruppa { get; set; }
    }

    public class GruppaDolzhnostMap : ClassMap<GruppaDolzhnost>
    {

        public GruppaDolzhnostMap()
        {
            Table("gruppa_dolzhnost");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            Map(x => x.Gruppa).Column("gruppa");
        }
    }
}
