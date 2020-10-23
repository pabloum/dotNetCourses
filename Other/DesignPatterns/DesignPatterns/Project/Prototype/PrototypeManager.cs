using System.Collections.Generic;

namespace Prototype_Pattern
{
    public class PrototypeManager
    {
        private Dictionary<string, Prototype> _protypeLibrary = new Dictionary<string, Prototype>();

        public Prototype this[string key]
        {
            get { return _protypeLibrary[key]; }
            set { _protypeLibrary.Add(key, value); }
        }
    }
}
