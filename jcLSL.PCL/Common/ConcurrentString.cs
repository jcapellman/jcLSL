using System.Collections.Concurrent;
using System.Linq;
using System.Numerics;

namespace jcLSL.PCL.Common {
    public class ConcurrentString {
        private readonly ConcurrentQueue<string> _data;

        public ConcurrentString() {
            _data = new ConcurrentQueue<string>();
        }

        public ConcurrentString(string val) : this() {
            _data.Enqueue(val);
        }

        public static ConcurrentString operator + (ConcurrentString c1, ConcurrentString c2) {
            return new ConcurrentString(c1.GetValue() + c2.GetValue());
        }

        public void SetValue(string val) {
            _data.Enqueue(val);
        }

        public string GetValue() {
            return _data.LastOrDefault();
        }
    }
}