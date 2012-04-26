using System;

namespace Rhapsody.Core
{
    internal class TextValidationResult
    {
        public bool IsValid
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        private TextValidationResult(bool isValid, string description = null)
        {
            IsValid = isValid;
            Description = description;
        }

        public static TextValidationResult Valid()
        {
            return new TextValidationResult(true);
        }

        public static TextValidationResult Invalid(string description)
        {
            return new TextValidationResult(false, description);
        }
    }
}
