using UnityEngine;

namespace BlockPuzzle{
    public class Pushable : TileBound
    {  
        public virtual bool Move(Vector3Int input){
            Vector3Int nextPos = GridPosition + input;         
            if(!ValidTile(nextPos)) return false;
            TileBound t = NextTileObject(nextPos);
            if(t){
                if(!t.GetComponent<Pushable>()) return false;
                else if(!t.GetComponent<Pushable>().Move(input)) return false;
            }
            Vector3 goTo = GoTo(nextPos);
            GridPosition = nextPos;
            transform.position = goTo;
            return true;
        }
    }
}
