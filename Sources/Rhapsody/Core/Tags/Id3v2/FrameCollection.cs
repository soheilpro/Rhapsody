using System;
using System.Collections.Generic;
using System.Linq;

namespace Rhapsody.Core.Tags.Id3v2
{
    internal class FrameCollection : List<Frame>
    {
        public IEnumerable<Frame> this[string id]
        {
            get
            {
                return this.Where(frame => frame.Id == id);
            }
        }
    }
}
