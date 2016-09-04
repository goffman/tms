using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class SpecialnostMap : ClassMap<Specialnost> {
        
        public SpecialnostMap() {
			Table("specialnost");
			LazyLoad();

			Id(x => x.IdSpecialnost).GeneratedBy.Identity().Column("id_specialnost");
			Map(x => x.Naimenovanie).Column("naimenovanie");
        }
    }
}
