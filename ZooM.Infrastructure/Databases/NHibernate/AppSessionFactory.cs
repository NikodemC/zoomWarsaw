using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using ZooM.Infrastructure.Databases.NHibernate.Entities.Mappings;
using ZooM.Infrastructure.Options;

namespace ZooM.Infrastructure.Databases.NHibernate
{
    internal sealed class AppSessionFactory
    {
        private readonly ISessionFactory _sessionFactory;

        public AppSessionFactory(DatabaseOptions options)
        {
            var mapper = new ModelMapper();
            mapper.AddZooMappings();
            var domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            var configuration = new Configuration();
            configuration.SessionFactoryName(options.InstanceName);
            configuration.DataBaseIntegration(db =>
                {
                    db.ConnectionString = options.ConnectionString;
                    db.Dialect<MsSql2012Dialect>();
                    db.Driver<SqlClientDriver>();
                    db.LogFormattedSql = true;
                    db.LogSqlInConsole = true;
                    db.AutoCommentSql = true;
                })
                .AddMapping(domainMapping);
            configuration.SessionFactory().GenerateStatistics();
            _sessionFactory = configuration.BuildSessionFactory();

            new SchemaUpdate(configuration).Execute(false, true);
        }

        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}