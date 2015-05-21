using System;

namespace jcLSL.PCL.MergeFieldArgs {
    public abstract class jcLSLBaseMergeFieldArgs : EventArgs {
        protected const string PREFIX = "{";
        protected const string SUFFIX = "}";

        internal string _mergeFieldString { get; set; }

        internal string GetMergedString() {
            return _mergeFieldString;
        }
    }
}