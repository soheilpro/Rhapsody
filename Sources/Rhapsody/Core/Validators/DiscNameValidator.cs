using System;
using System.Collections.Generic;

namespace Rhapsody.Core.Validators
{
    internal class DiscNameValidator : NameValidatorBase
    {
        private Disc _disc;

        public DiscNameValidator(Disc disc, IEnumerable<ITextValidator> textValidators) : base(textValidators)
        {
            _disc = disc;
        }

        protected override string GetItemName()
        {
            return string.Format(@"Disc {0}", _disc.Index);
        }

        protected override string GetName()
        {
            return _disc.Name;
        }

        protected override void SetName(string value)
        {
            _disc.Name = value;
            _disc.OnNameChanged();
        }
    }
}
