using Microsoft.EntityFrameworkCore.Query;

namespace WhereInTvp.Console;

public class CustomSqlServerQuerySqlGeneratorFactory : IQuerySqlGeneratorFactory
{
    public CustomSqlServerQuerySqlGeneratorFactory(QuerySqlGeneratorDependencies dependencies) =>
        _dependencies = dependencies;

    private QuerySqlGeneratorDependencies _dependencies { get; }

    public virtual QuerySqlGenerator Create()
        => new CustomSqlServerQuerySqlGenerator(_dependencies);
}
