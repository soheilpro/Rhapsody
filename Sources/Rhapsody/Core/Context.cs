using System;
using System.Collections.Generic;
using Rhapsody.Core.CoverArtProvider;
using Rhapsody.Core.Encoders;
using Rhapsody.Core.TextValidators;
using Rhapsody.Core.Validators;

namespace Rhapsody.Core
{
    internal class Context
    {
        public IEnumerable<IAlbumCoverProvider> GetAlbumCoverProviders()
        {
            yield return new LastFmAlbumCoverProvider();
        }

        public IEnumerable<IValidator> GetArtistValidators(Album album)
        {
            yield return new ArtistNameValidator(album, GetTextValidators());
        }

        public IEnumerable<IValidator> GetAlbumValidators(Album album)
        {
            yield return new AlbumNameValidator(album, GetTextValidators());
        }

        public IEnumerable<IValidator> GetDiscValidators(Disc disc)
        {
            yield return new DiscNameValidator(disc, GetTextValidators());
            yield return new DuplicateTrackNameValidator(disc);
        }

        public IEnumerable<IValidator> GetTrackValidators(Track track)
        {
            yield return new TrackNameValidator(track, GetTextValidators());
        }

        public IEncoder GetEncoder()
        {
            return new LameEncoder();
        }

        private static IEnumerable<ITextValidator> GetTextValidators()
        {
            yield return new ExtraSpaceTextValidator();
            yield return new InvalidNameCharacterTextValidator();
            yield return new NumberSignTextValidator();
            yield return new ProperCaseTextValidator();
            yield return new SlashTextValidator();
        }
    }
}
