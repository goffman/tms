using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class NapravlenieMap : ClassMap<Napravlenie> {
        
        public NapravlenieMap() {
			Table("Napravlenie");
			LazyLoad();

            Id(x => x.IdNapravlenie).GeneratedBy.Identity().Column("IdNapravlenie");
          //  Map(x => x.IdNapravlenie).Column("ID_Napravlenie").Not.Nullable();
			Map(x => x.Napravlenieval).Column("Napravlenie").Not.Nullable();
        }
    }
}
