using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class DolzhnostspecialnostMap : ClassMap<Dolzhnostspecialnost> {
        
        public DolzhnostspecialnostMap() {
			Table("dolzhnost-specialnost");
			LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            Map(x => x.Dolzhnost).Column("dolzhnost");
			Map(x => x.Specialnost).Column("specialnost");
        }
    }
}
