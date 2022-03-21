using UnityEngine;

namespace BlockPuzzle{
    public class Pushable : TileObject
    {  
        public virtual bool Move(Vector3Int input){
            Vector3Int nextPos = GridPosition + input;         
            if(!ValidTile(nextPos)) return false;
            TileObject to = ObjectOnTile(nextPos);
            if(!to || (to && !to.blocking)){
                GridPosition = nextPos;
                transform.position = SetPos(nextPos);   
                TileMaterial tm = MaterialOfTile(nextPos);
                if(tm){
                    tm.OnTopEvent(this, input);
                }
                return true;
            }
            return false;
        }

        public override void ContactEvent(TileBound caller, Vector3Int contactDirection)
        {
            if(caller.GetType() == typeof(PlayerController) && this.blocking){
                Move(contactDirection);
            }
        }
    }
}
