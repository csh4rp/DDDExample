using System.Collections.Generic;
using System.Linq;

namespace DDDExample.Core.Domain.Abstract
{
    public sealed class RuleValidationResult
    {
        private readonly List<string> _errors = new();
        public static readonly RuleValidationResult Valid = new();
        
        public bool IsValid => _errors.Any();

        public IReadOnlyList<string> Errors =>  _errors.AsReadOnly();

        private RuleValidationResult()
        {
        }
        
        private RuleValidationResult(IEnumerable<string> errors)
        {
            _errors = errors.ToList();
        }

        public static RuleValidationResult Invalid(IEnumerable<string> errors) => new(errors);
        public static RuleValidationResult Invalid(params string[] errors) => new(errors);
    }
}