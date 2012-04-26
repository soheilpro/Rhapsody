using System;

namespace Rhapsody.Core
{
    internal class Issue
    {
        public IssueType Type
        {
            get;
            set;
        }

        public string Item
        {
            get;
            set;
        }

        public string ItemValue
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public IssueFixer Fixer
        {
            get;
            set;
        }

        public Issue(IssueType type, string item, string itemValue, string description)
        {
            Type = type;
            Item = item;
            ItemValue = itemValue;
            Description = description;
        }

        public Issue(IssueType type, string item, string itemValue, string description, IssueFixer fixer) : this(type, item, itemValue, description)
        {
            Fixer = fixer;
        }
    }
}
