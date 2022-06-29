using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace WhereInTvp.Console;

public class CustomSqlServerQuerySqlGenerator : SqlServerQuerySqlGenerator
{
    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    public CustomSqlServerQuerySqlGenerator(ISqlExpressionFactory sqlExpressionFactory, QuerySqlGeneratorDependencies dependencies) : base(dependencies)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }
    
    protected override Expression VisitIn(InExpression inExpression)
    {
        var subQuery = new SqlFragmentExpression("SELECT IntId FROM @ids");
        _sqlExpressionFactory.Select(subQuery);
        var expression = new InExpression(inExpression.Item, subQuery, inExpression.IsNegated, inExpression.TypeMapping);

        return base.VisitIn(expression);
    }
}