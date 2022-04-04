using UnityEngine;
using System.Collections.Generic;

namespace Sokoban.Dict
{
    [System.Serializable]
    public struct Dict<Q,T>{
        [SerializeField] private List<Q> _keys;
        [SerializeField] private List<T> _values;

        public Dict(List<Q> keys, List<T> values){
            _keys = keys;
            _values = values;
        }

        public T this[Q key]{
            get{
                if(_keys.Contains(key)){
                    return _values[_keys.IndexOf(key)];
                }
                return default(T);
            }
        }
    }
}
