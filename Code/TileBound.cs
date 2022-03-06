using UnityEngine.Tilemaps;
using UnityEngine;

namespace BlockPuzzle{
    public class TileBound : MonoBehaviour
    {
        [SerializeField] private Tilemap _groundTiles;
        protected float _delay = 0.1f;
        protected float _timer = 0.0f;
        public Vector3Int GridPosition;

        private void Start(){
            GridPosition = _groundTiles.WorldToCell(transform.position);
            if(!_groundTiles.HasTile(GridPosition))
                throw new System.Exception("Player spawned off ground tile grid");
            transform.position = _groundTiles.CellToWorld(GridPosition);
        }
            
        public virtual void Move(Vector3Int input){
            Vector3Int nextPos = GridPosition + input;
            if(_groundTiles.HasTile(nextPos)){
                Vector3 goTo = _groundTiles.CellToWorld(nextPos);
                TileBound[] set = GameObject.FindObjectsOfType<Slidable>();
                foreach(TileBound obj in set){
                    if(obj.GridPosition == nextPos){
                        return;
                    }
                }
                GridPosition = nextPos;
                transform.position = goTo;
            }
        }
    }
}
