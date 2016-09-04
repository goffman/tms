using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class NapravleniespecialnostMap : ClassMap<Napravleniespecialnost> {
        
        public NapravleniespecialnostMap() {
			Table("napravlenie-specialnost");
			LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            Map(x => x.IdNapravlenie).Column("id_Napravlenie").Not.Nullable();
			Map(x => x.IdSpecialnost).Column("id_specialnost").Not.Nullable();
        }
    }
}
