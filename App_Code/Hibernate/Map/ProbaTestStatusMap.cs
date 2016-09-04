using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class ProbaTestStatusMap : ClassMap<ProbaTestStatus> {
        
        public ProbaTestStatusMap() {
			Table("proba_test_status");
			LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            Map(x => x.IdLKabinet).Column("ID_l_kabinet");
			Map(x => x.ProbaTest).Column("proba_test");
        }
    }
}
