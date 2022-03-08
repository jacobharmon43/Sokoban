using UnityEngine;

namespace BlockPuzzle{
    public class Pushable : Physical
    {  
        public virtual bool Move(Vector3Int input){
            Vector3Int nextPos = GridPosition + input;         
            if(!ValidTile(nextPos)) return false;
            Physical p = NextTileObject(nextPos);
            if(p){
                Pushable push = p.GetComponent<Pushable>();
                if(!push) return false;
                else if(!push.Move(input)) return false;
            }
            Vector3 goTo = GoTo(nextPos);
            GridPosition = nextPos;
            transform.position = goTo;
            return true;
        }

        protected Physical NextTileObject(Vector3Int tile){
            Physical[] allTiles = GameObject.FindObjectsOfType<Physical>();
            foreach(Physical p in allTiles){
                if(p.GridPosition == tile) return p;
            }
            return null;
        }
        protected Vector3 GoTo(Vector3Int tile) => GroundTiles.CellToWorld(tile);
    }
}
