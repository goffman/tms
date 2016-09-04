using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Hibernate.Domain;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Hibernate
{
    /// <summary>
    /// Сводное описание для DataBase
    /// </summary>
    public static class DataBase
    {
        private static ISessionFactory sessionFactory = null;
        public static void OpenConnection()
        {
            ISessionFactory Factory = Fluently.Configure()
.Database(MsSqlConfiguration.MsSql2012.ConnectionString(builder =>
builder.Database("tms").
Password("root").
Server("GOFFMAN").
Username("sa")).ShowSql()).
Mappings(m => m.FluentMappings.AddFromAssemblyOf<Lkabinet>())
       .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
       .BuildSessionFactory();
            sessionFactory = Factory;
        }


        public static ISession GetSession()
        {
            if (sessionFactory==null)
            {
                OpenConnection();
                if (sessionFactory != null) return sessionFactory.OpenSession();
                else return null;
            }
            else
            {
                sessionFactory.OpenSession();
            }
            return null;
        }
    }
}