using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Hibernate.Domain; 

namespace Hibernate.Map {
    
    
    public class CancellationresultsMap : ClassMap<Cancellationresults> {
        
        public CancellationresultsMap() {
			Table("CancellationResults");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("ID");
			Map(x => x.Accountid).Column("AccountID").Not.Nullable();
			Map(x => x.Date).Column("date").Not.Nullable();
			Map(x => x.Idadmin).Column("IDAdmin").Not.Nullable();
			Map(x => x.Reason).Column("Reason").Not.Nullable();
			Map(x => x.Resulttest).Column("ResultTest");
        }
    }
}
