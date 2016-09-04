using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class ApplicationnullingtestresultMap : ClassMap<Applicationnullingtestresult> {
        
        public ApplicationnullingtestresultMap() {
			Table("ApplicationNullingTestResult");
			LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
           // Map(x => x.Id).Column("ID").Not.Nullable();
			Map(x => x.Date).Column("date").Not.Nullable();
			Map(x => x.Idaccount).Column("IDAccount").Not.Nullable();
			Map(x => x.Rationale).Column("rationale").Not.Nullable();
			Map(x => x.Status).Column("status");
			Map(x => x.Datedecision).Column("datedecision");
        }
    }
}
