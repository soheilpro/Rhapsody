using System;
using System.IO;

namespace Rhapsody.Core
{
    internal class Session
    {
        public Album Album
        {
            get;
            set;
        }

        public DirectoryInfo SourceDirectory
        {
            get;
            set;
        }

        public DirectoryInfo DestinationDirectory
        {
            get;
            set;
        }

        public bool IgnoreDamagedFiled
        {
            get;
            set;
        }

        public bool IgnoreLowQualityFiles
        {
            get;
            set;
        }

        public bool IgnoreInconsistencies
        {
            get;
            set;
        }

        public bool ReEncodeFiles
        {
            get;
            set;
        }
    }
}
