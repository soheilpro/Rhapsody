using System;

namespace Rhapsody.Core
{
    internal interface ITextValidator
    {
        TextValidationResult Validate(string text);

        string Fix(string text);
    }
}
