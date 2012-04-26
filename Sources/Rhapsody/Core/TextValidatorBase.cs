using System;

namespace Rhapsody.Core
{
    internal abstract class TextValidatorBase : ITextValidator
    {
        public abstract TextValidationResult Validate(string text);

        public abstract string Fix(string text);
    }
}
