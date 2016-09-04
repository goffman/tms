using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class GuideblockreasonsMap : ClassMap<Guideblockreasons> {
        
        public GuideblockreasonsMap() {
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            Table("GuideBlockReasons");
			LazyLoad();
			Map(x => x.Reasons).Column("Reasons");
        }
    }
}
