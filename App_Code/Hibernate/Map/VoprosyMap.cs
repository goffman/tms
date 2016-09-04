using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class VoprosyMap : ClassMap<Voprosy> {
        
        public VoprosyMap() {
			Table("voprosy");
			LazyLoad();
			Id(x => x.IdVoprosy).GeneratedBy.Identity().Column("id_voprosy");
			Map(x => x.Specialnost).Column("specialnost");
			Map(x => x.Vopros).Column("vopros");
			Map(x => x.Kategoria).Column("kategoria");
        }
    }
}
