using System;
using System.Collections.Generic;

namespace Rhapsody.Core.Validators
{
    internal class AlbumNameValidator : NameValidatorBase
    {
        private Album _album;

        public AlbumNameValidator(Album album, IEnumerable<ITextValidator> textValidators) : base(textValidators)
        {
            _album = album;
        }

        protected override string GetItemName()
        {
            return "Album";
        }

        protected override string GetName()
        {
            return _album.Name;
        }

        protected override void SetName(string value)
        {
            _album.Name = value;
            _album.OnNameChanged();
        }
    }
}
