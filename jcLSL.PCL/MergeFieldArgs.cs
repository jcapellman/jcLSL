using System;

namespace jcLSL.PCL {
    public class MergeFieldArgs : EventArgs {
        private const string PREFIX = "{";
        private const string SUFFIX = "}";

        private string _mergeFieldString { get; set; }

        public MergeFieldArgs(string mergeFieldString) {
            _mergeFieldString = mergeFieldString;
        }

        internal string GetMergedString() {
            return _mergeFieldString;
        }

        public void MergeReplace(string mergeField, string mergeValue) {
            _mergeFieldString = _mergeFieldString.Replace($"{PREFIX}{mergeField}{SUFFIX}", mergeValue);
        }
    }
}