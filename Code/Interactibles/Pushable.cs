using UnityEngine;

namespace BlockPuzzle{
    public class Pushable : Physical
    {  
        public virtual bool Move(Vector3Int input){
            Vector3Int nextPos = GridPosition + input;         
            if(!ValidTile(nextPos)) return false;
            Physical p = NextTileObject(nextPos);
            if(p && p.active){
                return false;  
            }
            GridPosition = nextPos;
            transform.position = SetPos(nextPos);
            return true;
        }

        protected Physical NextTileObject(Vector3Int tile){
            foreach(Physical p in (ObjectStore.OfTypeInList<Physical>())){
                if(p.GridPosition == tile) return p;
            }
            return null;
        }

        public TileMaterial NextTileMaterial(Vector3Int tile){
            foreach(TileMaterial tm in ObjectStore.OfTypeInList<TileMaterial>()){
                if(tm.GridPosition == tile){
                    return tm;
                }
            }
            return null;
        }
    }
}
