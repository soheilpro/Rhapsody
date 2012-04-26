using System;
using System.Collections.Generic;

namespace Rhapsody.Core
{
    internal abstract class ValidatorBase : IValidator
    {
        public abstract IEnumerable<Issue> Validate();
    }
}
