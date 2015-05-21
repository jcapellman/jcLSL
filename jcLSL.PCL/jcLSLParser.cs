namespace jcLSL.PCL {
    public class jcLSLParser {
        public delegate void MergeFieldEventHandler(object sender, MergeFieldArgs args);

        public event MergeFieldEventHandler OnMergeField;

        protected virtual void OnInternalMergeField(MergeFieldArgs e) {
            OnMergeField?.Invoke(this, e);
        }

        public string Run(string stringToParse) {
            var fieldHandler = new MergeFieldArgs(stringToParse);

            OnInternalMergeField(fieldHandler);

            return fieldHandler.GetMergedString();
        }
    }
}