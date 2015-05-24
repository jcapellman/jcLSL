using System.Reflection;

namespace jcLSL.PCL.MergeFieldArgs {
    public class jcLSLObjectMergeFieldArgs<T> : jcLSLBaseMergeFieldArgs {
        private readonly T _obj;
        private readonly bool _parseOnlyDecoratedProperties;

        public jcLSLObjectMergeFieldArgs(string mergeFieldString, T obj, bool parseOnlyDecoratedProperites = true) {
            _mergeFieldString = mergeFieldString;
            _obj = obj;
            _parseOnlyDecoratedProperties = parseOnlyDecoratedProperites;
        }

        public void MergeReplace() {
            if (IsNull) {
                return;
            }

            var properties = _obj.GetType().GetRuntimeProperties();

            foreach (var prop in properties) {
                if (_parseOnlyDecoratedProperties) {
                    var attribute = prop.GetCustomAttribute<jcLSLMemberAttribute>();

                    if (attribute == null) {
                        continue;
                    }
                }

                _mergeFieldString = _mergeFieldString.Replace($"{PREFIX}{prop.Name}{SUFFIX}", prop.GetValue(_obj).ToString());
            }
        }
    }
}