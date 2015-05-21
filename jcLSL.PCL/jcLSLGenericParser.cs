﻿using jcLSL.PCL.MergeFieldArgs;

namespace jcLSL.PCL {
    public class jcLSLGenericParser<T> {
        public delegate void ObjectMergeFieldEventHandler(object sender, jcLSLObjectMergeFieldArgs<T> args);

        public event ObjectMergeFieldEventHandler OnObjectMergeField;

        protected virtual void OnInternalObjectMergeField(jcLSLObjectMergeFieldArgs<T> e) {
            OnObjectMergeField?.Invoke(this, e);
        }

        public string Run(string stringToParse, T obj) {
            var fieldHandler = new jcLSLObjectMergeFieldArgs<T>(stringToParse, obj);

            OnObjectMergeField(this, fieldHandler);

            return fieldHandler.GetMergedString();
        }
    }
}