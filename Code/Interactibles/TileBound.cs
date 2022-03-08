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
            Vector3Int nextPos = GridPosition + input; // Calculate next gridposition

            /* Check if there is a valid position on the next tile */            
            if(!ValidTile(nextPos)) return false;

            /* Section for checking if there exists an object on the next tile
            *  This allows for the pushing to be translated through many many objects
            *  If the next object cannot move, then this one will not move either.
            */
            TileBound[] allSlides = GameObject.FindObjectsOfType<TileBound>();
            foreach(TileBound t in allSlides){
                Slidable s = t.GetComponent<Slidable>();
                if(t.GridPosition == nextPos && !s) return false;
                if(s && !s.Move(input)) return false;
            }

            /* Movement calculations considering valid tiles */
            Vector3 goTo = GoTo(nextPos);
            GridPosition = nextPos;
            transform.position = goTo;
            return true;
        }

        public virtual bool MoveNoPush(Vector3Int input){
            Vector3Int nextPos = GridPosition + input; // Calculate next gridposition

            /* Check if there is a valid position on the next tile */            
            if(!GroundTiles.HasTile(nextPos)) return false;

            /* Section for checking if there exists an object on the next tile
            *  This allows for the pushing to be translated through many many objects
            *  If the next object cannot move, then this one will not move either.
            */
            Slidable[] allSlides = GameObject.FindObjectsOfType<Slidable>();
            foreach(Slidable s in allSlides){
                if(s.GridPosition == nextPos) return false;
            }

            /* Movement calculations considering valid tiles */
            Vector3 goTo = GroundTiles.CellToWorld(nextPos);
            GridPosition = nextPos;
            transform.position = goTo;
            return true;
        }

        protected bool ValidTile(Vector3Int tile) => GroundTiles.HasTile(tile);
        protected Vector3 GoTo(Vector3Int tile) => GroundTiles.CellToWorld(tile);
    }
}
