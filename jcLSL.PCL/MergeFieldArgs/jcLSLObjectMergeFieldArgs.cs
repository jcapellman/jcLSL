using System.Reflection;

namespace jcLSL.PCL.MergeFieldArgs {
    public class jcLSLObjectMergeFieldArgs<T> : jcLSLBaseMergeFieldArgs {
        private readonly T _obj;

        public jcLSLObjectMergeFieldArgs(string mergeFieldString, T obj) {
            _mergeFieldString = mergeFieldString;
            _obj = obj;
        }

        public void MergeReplace() {
            var properties = _obj.GetType().GetRuntimeProperties();

            foreach (var prop in properties) {
                var attribute = prop.GetCustomAttribute<jcLSLMemberAttribute>();

                if (attribute == null) {
                    continue;
                }

                _mergeFieldString = _mergeFieldString.Replace($"{PREFIX}{prop.Name}{SUFFIX}", prop.GetValue(_obj).ToString());
            }
        }
    }
}