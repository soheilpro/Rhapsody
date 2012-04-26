using System;
using System.Collections.Generic;

namespace Rhapsody.Core.Validators
{
    internal class ArtistNameValidator : NameValidatorBase
    {
        private Album _album;

        public ArtistNameValidator(Album album, IEnumerable<ITextValidator> textValidators) : base(textValidators)
        {
            _album = album;
        }

        protected override string GetItemName()
        {
            return "Artist";
        }

        protected override string GetName()
        {
            return _album.ArtistName;
        }

        protected override void SetName(string value)
        {
            _album.ArtistName = value;
            _album.OnArtistNameChanged();
        }
    }
}
