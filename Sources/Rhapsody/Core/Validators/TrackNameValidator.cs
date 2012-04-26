using System;
using System.Collections.Generic;

namespace Rhapsody.Core.Validators
{
    internal class TrackNameValidator : NameValidatorBase
    {
        private Track _track;

        public TrackNameValidator(Track track, IEnumerable<ITextValidator> textValidators) : base(textValidators)
        {
            _track = track;
        }

        protected override string GetItemName()
        {
            return string.Format(@"Disc {0}\Track {1}", _track.Disc.Index, _track.Index);
        }

        protected override string GetName()
        {
            return _track.Name;
        }

        protected override void SetName(string value)
        {
            _track.Name = value;
            _track.OnNameChanged();
        }
    }
}
