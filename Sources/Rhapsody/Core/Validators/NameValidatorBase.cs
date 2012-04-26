using System;
using System.Collections.Generic;

namespace Rhapsody.Core.Validators
{
    internal abstract class NameValidatorBase : ValidatorBase
    {
        private IEnumerable<ITextValidator> _textValidators;

        protected NameValidatorBase(IEnumerable<ITextValidator> textValidators)
        {
            _textValidators = textValidators;
        }

        public override IEnumerable<Issue> Validate()
        {
            var name = GetName();

            foreach (var textValidator in _textValidators)
            {
                var textValidationResult = textValidator.Validate(name);

                if (textValidationResult.IsValid)
                    continue;

                var validator = textValidator;

                yield return new Issue(IssueType.Warning, GetItemName(), name, textValidationResult.Description, delegate
                {
                    var newName = validator.Fix(name);
                    SetName(newName);

                    return validator.Validate(newName).IsValid;
                });
            }
        }

        protected abstract string GetItemName();

        protected abstract string GetName();

        protected abstract void SetName(string value);
    }
}
