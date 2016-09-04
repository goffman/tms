using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class LpuMap : ClassMap<Lpu> {
        
        public LpuMap() {
			Table("lpu");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("ID");
			Map(x => x.Lpuval).Column("lpu");
        }
    }
}
