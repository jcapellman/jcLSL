using jcLSL.PCL.MergeFieldArgs;

namespace jcLSL.PCL {
    public class jcLSLStringParser : jcLSLBaseParser {
        public delegate void StringMergeFieldEventHandler(object sender, jcLSLStringMergeFieldArgs args);
        public event StringMergeFieldEventHandler OnStringMergeField;

        protected virtual void OnInternalStringMergeField(jcLSLStringMergeFieldArgs e) {
            OnStringMergeField?.Invoke(this, e);
        }

        public string Run(string stringToParse) {
            var fieldHandler = new jcLSLStringMergeFieldArgs(stringToParse);

            OnInternalStringMergeField(fieldHandler);

            return fieldHandler.GetMergedString();
        }
    }
}