using UnityEngine.Tilemaps;
using UnityEngine;

namespace BlockPuzzle{
    public class TileBound : MonoBehaviour
    {
        
        private Tilemap _groundTiles;
        protected float _delay = 0.1f;
        protected float _timer = 0.0f;
        public Vector3Int _gridPosition;
        private void Start(){
            _gridPosition = _groundTiles.WorldToCell(transform.position);
            if(!_groundTiles.HasTile(_gridPosition)){
                throw new System.Exception("Player spawned off ground tile grid");
            }
            
            public virtual void Move(Vector3Int input){
                Vector3Int nextPos = _gridPosition + input;
                if(_groundTiles.HasTile(nextPos)){
                    _gridPosition = nextPos;
                    transform.position = _groundTiles.CellToWorld(nextPos);
                }
            }
        }
    }
}
