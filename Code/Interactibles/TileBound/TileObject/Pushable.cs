using UnityEngine;

namespace BlockPuzzle{
    public class Pushable : TileObject
    {  
        public virtual void Move(Vector3Int input){
            Vector3Int nextPos = GridPosition + input;         
            if(!ValidTile(nextPos)) return;
            TileObject to = ObjectOnTile(nextPos);
            if(to){
                if(to && to.blocking){
                    return;
                }
            }
            GridPosition = nextPos;
            transform.position = SetPos(nextPos);
        }

        public override void ContactEvent(TileBound caller, Vector3Int contactDirection)
        {
            if(caller.GetType() == typeof(PlayerController)){
                Move(contactDirection);
            }
        }
    }
}
