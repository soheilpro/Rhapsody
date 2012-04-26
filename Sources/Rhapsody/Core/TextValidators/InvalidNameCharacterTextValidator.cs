using System;
using System.Linq;
using Rhapsody.Utilities;

namespace Rhapsody.Core.TextValidators
{
    internal class InvalidNameCharacterTextValidator : TextValidatorBase
    {
        public override TextValidationResult Validate(string text)
        {
            var invalidNameCharacters = StringHelper.GetInvalidNameCharacters(text).ToArray();

            if (invalidNameCharacters.Length > 0)
                return TextValidationResult.Invalid(string.Format("Invalid characters: {0}", string.Join(" ", invalidNameCharacters)));

            return TextValidationResult.Valid();
        }

        public override string Fix(string text)
        {
            text = StringHelper.RemoveDiacritics(text);
            text = StringHelper.ReplaceCommonWrongChars(text);

            return text;
        }
    }
}
