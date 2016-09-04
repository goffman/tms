using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class AttestacijamrMap : ClassMap<Attestacijamr> {
        
        public AttestacijamrMap() {
			Table("AttestacijaMR");
			LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            References(x => x.Lpu).Column("LPU");
			References(x => x.Dolzhnost).Column("Dolzhnost");
			Map(x => x.F).Column("F");
			Map(x => x.I).Column("I");
			Map(x => x.O).Column("O");
			Map(x => x.Dataattestacii).Column("DataAttestacii");
        }
    }
}
