using UnityEngine;

namespace BlockPuzzle{
    public class Pushable : Physical
    {  
        public virtual bool Move(Vector3Int input){
            Vector3Int nextPos = GridPosition + input;         
            if(!ValidTile(nextPos)) return false;
            Physical p = NextPhysicalTileObject(nextPos);
            if(p && p.active){
                return false;  
            }
            GridPosition = nextPos;
            transform.position = SetPos(nextPos);
            return true;
        }

        protected Physical NextPhysicalTileObject(Vector3Int tile){
            foreach(Physical p in (ObjectStore.OfTypeInList<Physical>())){
                if(p.GridPosition == tile) return p;
            }
            return null;
        }

        protected TileBound NextTileObject(Vector3Int tile){
            foreach(TileBound p in (ObjectStore.AllTiles)){
                if(p.GridPosition == tile) return p;
            }
            return null;
        }


    }
}
