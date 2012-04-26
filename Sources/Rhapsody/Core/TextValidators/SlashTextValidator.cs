using System;
using Rhapsody.Utilities;

namespace Rhapsody.Core.TextValidators
{
    internal class SlashTextValidator : TextValidatorBase
    {
        public override TextValidationResult Validate(string text)
        {
            var areSlashesNotSurroundedBySpace = StringHelper.AreSlashesNotSurroundedBySpace(text);

            if (areSlashesNotSurroundedBySpace)
                return TextValidationResult.Invalid("/ not surrounded by space");

            return TextValidationResult.Valid();
        }

        public override string Fix(string text)
        {
            return StringHelper.SurroundSlashesBySpace(text);
        }
    }
}
