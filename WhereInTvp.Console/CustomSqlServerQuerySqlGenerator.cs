using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace WhereInTvp.Console;

public class CustomSqlServerQuerySqlGenerator : SqlServerQuerySqlGenerator
{
    public CustomSqlServerQuerySqlGenerator(QuerySqlGeneratorDependencies dependencies) : base(dependencies)
    {
    }

    protected override Expression VisitIn(InExpression inExpression)
    {
        System.Console.WriteLine("Visiting!");
        return base.VisitIn(inExpression);
    }
}