using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class GruppaDolzhnostMap : ClassMap<GruppaDolzhnost> {
        
        public GruppaDolzhnostMap() {
			Table("gruppa_dolzhnost");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("ID");
			Map(x => x.Gruppa).Column("gruppa");
        }
    }
}
