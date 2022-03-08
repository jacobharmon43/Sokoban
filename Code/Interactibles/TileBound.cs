using UnityEngine.Tilemaps;
using UnityEngine;

namespace BlockPuzzle{
    public class TileBound : MonoBehaviour
    {
        public Tilemap GroundTiles;
        protected LayerMask _pushableLayer;
        protected float _delay = 0.15f;
        protected float _timer = 0.0f;
        public Vector3Int GridPosition;

        private void Start(){
            _pushableLayer = LayerMask.GetMask("Pushable");
            GridPosition = GroundTiles.WorldToCell(transform.position);
            if(!GroundTiles.HasTile(GridPosition))
                throw new System.Exception($"Tilebound object: {transform.name} starting location is off the grid");
            transform.position = GroundTiles.CellToWorld(GridPosition);
        }
            
        public virtual bool Move(Vector3Int input){
            Vector3Int nextPos = GridPosition + input;         
            if(!ValidTile(nextPos)) return false;
            TileBound t = NextTileObject(nextPos);
            if(t){
                if(!t.GetComponent<Slidable>()) return false;
                else if(!t.GetComponent<Slidable>().Move(input)) return false;
            }
            Vector3 goTo = GoTo(nextPos);
            GridPosition = nextPos;
            transform.position = goTo;
            return true;
        }

        public virtual bool MoveNoPush(Vector3Int input){
            Vector3Int nextPos = GridPosition + input;   
            if(!ValidTile(nextPos)) return false;
            if(NextTileObject(nextPos)) return false;
            Vector3 goTo = GroundTiles.CellToWorld(nextPos);
            GridPosition = nextPos;
            transform.position = goTo;
            return true;
        }

        protected TileBound NextTileObject(Vector3Int tile){
            TileBound[] allTiles = GameObject.FindObjectsOfType<TileBound>();
            foreach(TileBound t in allTiles){
                if(t.GridPosition == tile) return t;
            }
            return null;
        }
        protected bool ValidTile(Vector3Int tile) => GroundTiles.HasTile(tile);
        protected Vector3 GoTo(Vector3Int tile) => GroundTiles.CellToWorld(tile);
    }
}
