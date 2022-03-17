using UnityEngine;

namespace BlockPuzzle{
    public class Pushable : TileObject
    {  
        public virtual void Move(Vector3Int input){
            Vector3Int nextPos = GridPosition + input;         
            if(!ValidTile(nextPos)) return;
            TileObject to = NextTileObject(nextPos);
            if(to){
                if(to && to.blocking){
                    return;
                }
            }
            GridPosition = nextPos;
            transform.position = SetPos(nextPos);
        }

        protected TileObject NextTileObject(Vector3Int tile){
            foreach(TileObject to in (ObjectStore.OfTypeInList<TileObject>())){
                if(to.GridPosition == tile) return to;
            }
            return null;
        }

        public override void ContactEvent(TileBound caller, Vector3Int contactDirection)
        {
            if(caller.GetType() == typeof(PlayerController)){
                Move(contactDirection);
            }
        }
    }
}
