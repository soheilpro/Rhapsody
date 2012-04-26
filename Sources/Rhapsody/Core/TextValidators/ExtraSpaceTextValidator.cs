using System;
using Rhapsody.Utilities;

namespace Rhapsody.Core.TextValidators
{
    internal class ExtraSpaceTextValidator : TextValidatorBase
    {
        public override TextValidationResult Validate(string text)
        {
            var hasExtraSpaces = StringHelper.HasExtraSpaces(text);

            if (hasExtraSpaces)
                return TextValidationResult.Invalid("Two or more spaces");

            return TextValidationResult.Valid();
        }

        public override string Fix(string text)
        {
            return StringHelper.RemoveExtraSpaces(text);
        }
    }
}
