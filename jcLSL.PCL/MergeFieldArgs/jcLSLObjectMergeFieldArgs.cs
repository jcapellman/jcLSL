using System.Collections.Concurrent;
using System.Reflection;
using System.Threading.Tasks;
using jcLSL.PCL.Common;

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

            var val = new ConcurrentString();

            Parallel.ForEach(properties, prop => {
                if (_parseOnlyDecoratedProperties) {
                    var attribute = prop.GetCustomAttribute<jcLSLMemberAttribute>();

                    if (attribute == null) {
                        return;
                    }
                }
                
                val.SetValue(val.GetValue().Replace($"{PREFIX}{prop.Name}{SUFFIX}", prop.GetValue(_obj).ToString()));
            });

            _mergeFieldString = val.GetValue();
        }
    }
}