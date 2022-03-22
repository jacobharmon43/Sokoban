using UnityEngine;
using System.Collections;

namespace BlockPuzzle{
    public class Pushable : TileObject
    {
        private bool _moving = false;

        public virtual bool Move(Vector3Int input){
            if(_moving) return false;
            Vector3Int nextPos = GridPosition + input;         
            if(!ValidTile(nextPos)) return false;
            TileObject to = ObjectOnTile(nextPos);
            if(!to || (to && !to.blocking)){
                GridPosition = nextPos;
                StartCoroutine(MoveTo(SetPos(nextPos), input));
                return true;
                }
            return false;
        }

        public bool PlayerPush(Vector3Int input){
            if(_moving) return false;
            Vector3Int nextPos = GridPosition + input;         
            if(!ValidTile(nextPos)) return false;
            TileObject to = ObjectOnTile(nextPos);
            if(!to || (to && !to.blocking)){
                GridPosition = nextPos;
                transform.position = SetPos(nextPos);
                TileMaterial tm = MaterialOfTile(GridPosition);
                if(!tm) return true;
                tm.OnTopEvent(this, input);
                return true;
                }
            return false;
        }

        public override void ContactEvent(TileBound caller, Vector3Int contactDirection)
        {
            if(caller.GetType() == typeof(PlayerController) && this.blocking){
                PlayerPush(contactDirection);
            }
        }

        private IEnumerator MoveTo(Vector3 position, Vector3Int input){
            _moving = true;
            while(transform.position != position){
                transform.position = Vector3.MoveTowards(transform.position, position, Time.fixedDeltaTime * 6);
                yield return new WaitForFixedUpdate();
            }
            TileMaterial tm = MaterialOfTile(GridPosition);
            _moving = false;
            if(!tm) yield break;
            tm.OnTopEvent(this, input);
        }
    }
}
