using System;
using Rhapsody.Core;

namespace Rhapsody.UI
{
    internal interface IProgressUI : IProgress
    {
        string Title
        {
            get;
            set;
        }
    }
}
