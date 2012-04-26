using System;

namespace Rhapsody.Core
{
    internal interface IProgress
    {
        void Begin(int totalItems);

        void Advance(string itemName);
    }
}
