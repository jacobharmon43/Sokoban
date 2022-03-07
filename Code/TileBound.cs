using UnityEngine.Tilemaps;
using UnityEngine;

namespace BlockPuzzle{
    public class TileBound : MonoBehaviour
    {
        [SerializeField] private Tilemap _groundTiles;
        protected LayerMask _pushableLayer;
        protected float _delay = 0.1f;
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
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(input.x, input.y), 1, _pushableLayer);
            if(hit){
                Slidable s = hit.transform.GetComponent<Slidable>();
                s.Move(input);
            }
            if(!_groundTiles.HasTile(nextPos)){
                return false;
            }
            Vector3 goTo = _groundTiles.CellToWorld(nextPos);
            TileBound[] set = GameObject.FindObjectsOfType<Slidable>();
            foreach(TileBound obj in set){
                if(obj.GridPosition == nextPos){
                    return false;
                }
            }
            GridPosition = nextPos;
            transform.position = goTo;
            return true;
        }
    }
}
