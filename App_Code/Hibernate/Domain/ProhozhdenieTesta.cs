using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Mapping;
using NHibernate.Linq;
using NHibernate.Validator.Constraints;



namespace Hibernate.Domain
{

    public class ProhozhdenieTesta
    {
        public virtual Lkabinet Lkabinet { get; set; }
        public virtual Dolzhnost Dolzhnost { get; set; }
        [NotNullNotEmpty]
        public virtual int Id { get; set; }
        public virtual int? Rezultat { get; set; }
        public virtual DateTime? Data { get; set; }
        [NotNullNotEmpty]
        public virtual int Status { get; set; }
        [NotNullNotEmpty]
        public virtual string NaimenovanieTesta { get; set; }
        public virtual int? Otpravlen { get; set; }
        public virtual int? Time { get; set; }

        public static Common.ResultExecute UpdateResultProhozhdenieTesta(int accountId, int result)
        {
            var resultReturn = new Common.ResultExecute() { StatusExecute = Common.ResultExecute.Status.Error };
            var session = DataBase.GetSession();
            if (session != null)
            {
                var s =
                    session.QueryOver<ProhozhdenieTesta>().Where(testa => testa.Lkabinet== Lkabinet.GetById(accountId))
                        .SingleOrDefault();
                if (s == null)
                {
                  
                    resultReturn.ErrorExecute = "не удалось найти результата тестирования";
                }
                else
                {
                    s.Rezultat = result;
                    DataBase.Execute.TransactionCommit(s);
                    resultReturn.StatusExecute = Common.ResultExecute.Status.Success;
              
                }
            }
            return resultReturn;
        }
    }

    public class ProhozhdenieTestaMap : ClassMap<ProhozhdenieTesta>
    {
        public ProhozhdenieTestaMap()
        {
            Table("prohozhdenie_testa");
            LazyLoad();
            References(x => x.Lkabinet).Column("ID_testiruemyj");
            References(x => x.Dolzhnost).Column("ID_dolzhnost");
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            // Map(x => x.Id).Column("ID").Not.Nullable();
            Map(x => x.Rezultat).Column("rezultat");
            Map(x => x.Data).Column("data");
            Map(x => x.Status).Column("status").Not.Nullable();
            Map(x => x.NaimenovanieTesta).Column("naimenovanie_testa").Not.Nullable();
            Map(x => x.Otpravlen).Column("otpravlen");
            Map(x => x.Time).Column("time");
        }
    }
}
