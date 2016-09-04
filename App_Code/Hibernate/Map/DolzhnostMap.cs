using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class DolzhnostMap : ClassMap<Dolzhnost> {
        
        public DolzhnostMap() {
			Table("dolzhnost");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("ID");
			References(x => x.GruppaDolzhnost).Column("gruppa");
			Map(x => x.Dolzhnostval).Column("dolzhnost").Not.Nullable();
			Map(x => x.Correctly).Column("correctly");
        }
    }
}
