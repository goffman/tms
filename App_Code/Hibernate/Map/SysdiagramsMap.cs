using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class SysdiagramsMap : ClassMap<Sysdiagrams> {
        
        public SysdiagramsMap() {
			Table("sysdiagrams");
			LazyLoad();
			Id(x => x.DiagramId).GeneratedBy.Identity().Column("diagram_id");
			Map(x => x.Name).Column("name").Not.Nullable().Unique();
			Map(x => x.PrincipalId).Column("principal_id").Not.Nullable().Unique();
			Map(x => x.Version).Column("version");
			Map(x => x.Definition).Column("definition");
        }
    }
}
