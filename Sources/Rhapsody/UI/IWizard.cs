using System;
using System.Threading;

namespace Rhapsody.UI
{
    internal interface IWizard
    {
        void GoBack();

        void GoNext();

        void FocusNextButton();

        IProgressUI StartProgress();

        IProgressUI StartProgress(CancellationTokenSource cancellationTokenSource);

        void StopProgress(IProgressUI progressUI);
    }
}
