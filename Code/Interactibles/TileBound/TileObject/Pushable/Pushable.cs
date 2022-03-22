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
                GameManager.Instance.TurnActions.Add(() => MoveEvent(SetPos(nextPos), input));
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

        private void MoveEvent(Vector3 toPos, Vector3Int input){
            transform.position = toPos;
        }
    }
}
