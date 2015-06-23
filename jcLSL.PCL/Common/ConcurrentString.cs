using System.Collections.Concurrent;
using System.Linq;

namespace jcLSL.PCL.Common {
    public class ConcurrentString {
        private readonly ConcurrentQueue<string> _data;

        public ConcurrentString() {
            _data = new ConcurrentQueue<string>();
        }

        public void SetValue(string val) {
            _data.Enqueue(val);
        }

        public string GetValue() {
            return _data.LastOrDefault();
        }
    }
}