using System;
using Rhapsody.Utilities;

namespace Rhapsody.Core.TextValidators
{
    internal class ProperCaseTextValidator : TextValidatorBase
    {
        public override TextValidationResult Validate(string text)
        {
            var isProperlyCased = StringHelper.IsProperlyCased(text);

            if (!isProperlyCased)
                return TextValidationResult.Invalid("Improper case");

            return TextValidationResult.Valid();
        }

        public override string Fix(string text)
        {
            return StringHelper.MakeProperCase(text);
        }
    }
}
