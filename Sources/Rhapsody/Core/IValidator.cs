using System;
using System.Collections.Generic;

namespace Rhapsody.Core
{
    internal interface IValidator
    {
        IEnumerable<Issue> Validate();
    }
}
