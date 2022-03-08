using System.Collections.Generic;
using System;

namespace BlockPuzzle
{
    public static class ObjectStore
    {
        public static List<TileBound> AllTiles = new List<TileBound>();
    }

    public static class ListParser<T>{
        public static List<T> OfTypeInList(List<TileBound> AllTiles){
            List<T> l = new List<T>();
            foreach(TileBound t in AllTiles){
                T push = t.GetComponent<T>();
                if(push != null)
                    l.Add(push);
            }
            return l;
        }
    }
}
