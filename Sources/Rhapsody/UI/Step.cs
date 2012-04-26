using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using Rhapsody.Core;

namespace Rhapsody.UI
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    internal class Step : UserControl
    {
        private bool _backEnabled = true;
        private bool _nextEnabled = true;

        public event EventHandler BackEnabledChanged;
        public event EventHandler NextEnabledChanged;

        public IWizard Wizard
        {
            get;
            set;
        }

        public Context Context
        {
            get;
            set;
        }

        public Session Session
        {
            get;
            set;
        }

        [DefaultValue(true)]
        public bool BackEnabled
        {
            get
            {
                return _backEnabled;
            }
            set
            {
                if (_backEnabled == value)
                    return;

                _backEnabled = value;
                OnBackEnabledChanged();
            }
        }

        [DefaultValue(true)]
        public bool NextEnabled
        {
            get
            {
                return _nextEnabled;
            }
            set
            {
                if (_nextEnabled == value)
                    return;

                _nextEnabled = value;
                OnNextEnabledChanged();
            }
        }

        public string NextText
        {
            get;
            set;
        }

        public string CancelText
        {
            get;
            set;
        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            return (ProcessKeyEventArgs(ref m) || base.ProcessKeyPreview(ref m));
        }

        public virtual void InitializeStep()
        {
        }

        public virtual void OnActivating()
        {
        }

        public virtual void OnActivated()
        {
        }

        public virtual void OnDeactivating()
        {
        }

        public virtual void OnDeactivated()
        {
        }

        public virtual void OnBackClick()
        {
            Wizard.GoBack();
        }

        public virtual void OnNextClick()
        {
            Wizard.GoNext();
        }

        private void OnBackEnabledChanged()
        {
            if (BackEnabledChanged != null)
                BackEnabledChanged(this, EventArgs.Empty);
        }

        private void OnNextEnabledChanged()
        {
            if (NextEnabledChanged != null)
                NextEnabledChanged(this, EventArgs.Empty);
        }
    }
}
