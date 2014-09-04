﻿using System;
using System.Diagnostics;
using System.IO;

namespace PathEditor.ModelViews
{
    internal class PathPartViewModel : BaseViewModel
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _pathPart;

        [DebuggerStepThrough]
        public PathPartViewModel(string pathPart)
        {
            if (pathPart == null) throw new ArgumentNullException("pathPart");
            _pathPart = pathPart;
        }

        public string Path
        {
            [DebuggerStepThrough]
            get { return _pathPart; }
            [DebuggerStepThrough]
            set
            {
                if (_pathPart != value)
                {
                    _pathPart = value;
                    OnPropertyChanged();
                    OnPropertyChanged("Exists");
                }
            }
        }

        public bool Exists
        {
            [DebuggerStepThrough]
            get
            {
                try
                {
                    return Directory.Exists(Environment.ExpandEnvironmentVariables(Path));
                }
                catch
                {
                    return false;
                }
            }
        }

        [DebuggerStepThrough]
        public override string ToString()
        {
            return _pathPart;
        }
    }
}