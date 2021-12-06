using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGenericType.Data
{
    public class DataStored<T>
    {
        public T Value { get; set; }
        public List<T> MyLists = new List<T>();
        public IReadOnlyDictionary<int, T> MyDictionaries { 
                get 
                { 
                    return (IReadOnlyDictionary<int, T>)_dictionaries; 
                } 
        }

        private IDictionary<int, T> _dictionaries = new Dictionary<int, T>();
        public void AddOrUpdateDictionaries(int key, T value)
        {
            if (_dictionaries.ContainsKey(key))
            {
                _dictionaries[key] = value;
                return;
            }
            _dictionaries.Add(key, value);
        }
        public bool DeleteDictionaries(int key)
        {
            if (!_dictionaries.ContainsKey(key))
            {
                return false;
            }
            _dictionaries.Remove(key);
            return true;
        }
        public T GetDataInDictionaries(int key)
        {
            if (!_dictionaries.ContainsKey(key))
            {
                throw new Exception("Key not exist");
            }
            return _dictionaries[key];
        }
    }
}
