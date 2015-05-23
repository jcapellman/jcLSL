using System;
using System.Collections.Generic;

namespace jcLSL.PCL.MergeFieldArgs {
    public class jcLSLStringMergeFieldArgs : jcLSLBaseMergeFieldArgs {
        private List<string> _mergeFields;
        
        public jcLSLStringMergeFieldArgs(string mergeFieldString) {
            _mergeFieldString = mergeFieldString;
        }

        public void MergeReplace(string mergeField, string mergeValue) {
            if (IsNull) {
                return;
            }

            _mergeFieldString = _mergeFieldString.Replace($"{PREFIX}{mergeField}{SUFFIX}", mergeValue);
        }
    }
}