using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class AttestacijaMap : ClassMap<Attestacija> {
        
        public AttestacijaMap() {
			Table("attestacija");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("ID");
			References(x => x.Dolzhnost).Column("dolzhnost");
			Map(x => x.Data).Column("data").Not.Nullable();
        }
    }
}
