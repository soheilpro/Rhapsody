using System;
using Rhapsody.Utilities;

namespace Rhapsody.Core.TextValidators
{
    internal class NumberSignTextValidator : TextValidatorBase
    {
        public override TextValidationResult Validate(string text)
        {
            var areNumberSignsNotFollowedByADigit = StringHelper.AreNumberSignsNotFollowedByADigit(text);

            if (areNumberSignsNotFollowedByADigit)
                return TextValidationResult.Invalid("# not followed by a digit");

            return TextValidationResult.Valid();
        }

        public override string Fix(string text)
        {
            return StringHelper.RemoveSpacesAfterNumberSigns(text);
        }
    }
}
