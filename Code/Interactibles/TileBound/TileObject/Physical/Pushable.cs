using UnityEngine;

namespace BlockPuzzle{
    public class Pushable : Physical
    {  
        public virtual bool Move(Vector3Int input){
            Vector3Int nextPos = GridPosition + input;         
            if(!ValidTile(nextPos)) return false;
            TileObject to = NextTileObject(nextPos);
            if(to){
                to.ContactEvent(this);
                Physical p = to.GetComponent<Physical>();
                if(p && p.active){
                    return false;
                }
            }
            GridPosition = nextPos;
            transform.position = SetPos(nextPos);
            return true;
        }

        protected TileObject NextTileObject(Vector3Int tile){
            foreach(TileObject to in (ObjectStore.OfTypeInList<TileObject>())){
                if(to.GridPosition == tile) return to;
            }
            return null;
        }

        public override void ContactEvent(TileBound caller)
        {
            //Nothing
        }
    }
}
