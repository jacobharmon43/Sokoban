using UnityEngine.Tilemaps;
using UnityEngine;

namespace BlockPuzzle{
    public class TileBound : MonoBehaviour
    {
        [SerializeField] private Tilemap _groundTiles;
        protected LayerMask _pushableLayer;
        protected float _delay = 0.15f;
        protected float _timer = 0.0f;
        public Vector3Int GridPosition;

        private void Start(){
            _pushableLayer = LayerMask.GetMask("Pushable");
            GridPosition = _groundTiles.WorldToCell(transform.position);
            if(!_groundTiles.HasTile(GridPosition))
                throw new System.Exception($"Tilebound object: {transform.name} starting location is off the grid");
            transform.position = _groundTiles.CellToWorld(GridPosition);
        }
            
        public virtual bool Move(Vector3Int input){
            Vector3Int nextPos = GridPosition + input; // Calculate next gridposition

            /* Check if there is a valid position on the next tile */            
            if(!_groundTiles.HasTile(nextPos)) return false;

            /* Section for checking if there exists an object on the next tile
            *  This allows for the pushing to be translated through many many objects
            *  If the next object cannot move, then this one will not move either.
            */
            Slidable[] allSlides = GameObject.FindObjectsOfType<Slidable>();
            foreach(Slidable s in allSlides){
                if(s.GridPosition == nextPos && !s.Move(input)) return false;
            }

            /* Movement calculations considering valid tiles */
            Vector3 goTo = _groundTiles.CellToWorld(nextPos);
            GridPosition = nextPos;
            transform.position = goTo;
            return true;
        }
    }
}
