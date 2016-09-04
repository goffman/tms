using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class OtvetiMap : ClassMap<Otveti> {
        
        public OtvetiMap() {
			Table("otveti");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id");
			Map(x => x.Otvet).Column("otvet");
			Map(x => x.Vernyj).Column("vernyj").Not.Nullable();
			Map(x => x.IdVoprosy).Column("ID_voprosy");
        }
    }
}
