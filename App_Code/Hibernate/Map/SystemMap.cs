using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class SystemMap : ClassMap<Domain.System> {
        
        public SystemMap() {
			Table("system");
			LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            Map(x => x.Param).Column("param");
			Map(x => x.Zn).Column("zn");
        }
    }
}
