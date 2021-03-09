namespace DDDExample.Core.Domain.Abstract
{
    public interface IBusinessRule<in TEntity>
    {
        RuleValidationResult Validate(TEntity entity);
    }
}