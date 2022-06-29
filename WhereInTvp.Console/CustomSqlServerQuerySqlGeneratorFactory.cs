using Microsoft.EntityFrameworkCore.Query;

namespace WhereInTvp.Console;

public class CustomSqlServerQuerySqlGeneratorFactory : IQuerySqlGeneratorFactory
{
    private readonly RelationalMethodCallTranslatorProviderDependencies _methodCallTranslatorProviderDependencies;
    private readonly QuerySqlGeneratorDependencies _sqlGeneratorDependencies;

    public CustomSqlServerQuerySqlGeneratorFactory(RelationalMethodCallTranslatorProviderDependencies methodCallTranslatorProviderDependencies, QuerySqlGeneratorDependencies sqlGeneratorDependencies)
    {
        _methodCallTranslatorProviderDependencies = methodCallTranslatorProviderDependencies;
        _sqlGeneratorDependencies = sqlGeneratorDependencies;
    }

    public virtual QuerySqlGenerator Create()
        => new CustomSqlServerQuerySqlGenerator(_methodCallTranslatorProviderDependencies.SqlExpressionFactory, _sqlGeneratorDependencies);
}
