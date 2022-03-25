namespace Sokoban.Dict
{
    [System.Serializable]
    public struct Dict<Q,T>{
        public Q rep;
        public T obj;

        public Dict(Q rep, T obj){
            this.rep = rep;
            this.obj = obj;
        }
    }    

    public class DictHelp{
        public static T DictSearch<Q,T>(Dict<Q,T>[] dict, Q key){
            T ret = default(T);
            foreach(Dict<Q,T> q in dict){
                if(key.Equals(q.rep)){
                    ret = q.obj;
                }
            }
            return ret;
        }
    } 
}
