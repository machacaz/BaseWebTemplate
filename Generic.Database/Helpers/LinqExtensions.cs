namespace Generic.Database.Helpers
{
    using Generic.Database.Entities.BaseEntities;
    using System.Linq.Expressions;
    public static class LinqExtensions
    {
        #region Refactor
        /*
        TODO: refactor this to use library from nugget when available 
         */

        class ParameterRebinder : ExpressionVisitor
        {
            readonly Dictionary<ParameterExpression, ParameterExpression> map;

            ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
            {
                this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
            }

            public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
            {
                return new ParameterRebinder(map).Visit(exp);
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                ParameterExpression replacement;

                if (map.TryGetValue(node, out replacement))
                {
                    node = replacement;
                }

                return base.VisitParameter(node);
            }
        }

        static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // zip parameters (map from parameters of second to parameters of first)    
            var map = first.Parameters
                .Select((f, i) => new { f, s = second.Parameters[i] })
                .ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with the parameters in the first    
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // create a merged lambda expression with parameters from the first expression    
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        public static Expression<Func<T, bool>> True<T>() { return param => true; }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.AndAlso);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.OrElse);
        }

        #endregion

        public static Expression<Func<T, bool>> GenerateExpressionForList<T>(List<int> idsList) where T : BaseEntity
        {
            var predicate = True<T>();

            foreach (var idValue in idsList)
            {
                //If it is the first predicate, you should apply "And"
                if (predicate.Body.NodeType == ExpressionType.Constant)
                {
                    predicate = predicate.And(obj => obj.Id == idValue);
                    continue;
                }
                predicate = predicate.Or(obj => obj.Id == idValue);
            }

            return predicate;
        }
    }
}