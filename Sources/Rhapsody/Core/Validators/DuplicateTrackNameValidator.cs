using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Rhapsody.Core.Validators
{
    internal class DuplicateTrackNameValidator : ValidatorBase
    {
        private Disc _disc;

        public DuplicateTrackNameValidator(Disc disc)
        {
            _disc = disc;
        }

        public override IEnumerable<Issue> Validate()
        {
            foreach (var duplicateTracks in _disc.Tracks.GroupBy(track => track.Name).Where(group => group.Count() > 1))
                yield return new Issue(IssueType.Warning, string.Format(@"Disc {0}\Tracks {1}", _disc.Index, string.Join(", ", duplicateTracks.Select(track => track.Index.ToString(CultureInfo.InvariantCulture)))), duplicateTracks.FirstOrDefault().Name, "Have the same name");
        }
    }
}
