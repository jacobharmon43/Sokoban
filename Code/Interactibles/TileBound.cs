using UnityEngine.Tilemaps;
using UnityEngine;

namespace BlockPuzzle{
    [System.Serializable]
    public class TileBound : MonoBehaviour
    {
        public Vector3Int GridPosition;
        private Tilemap _groundTiles;
        protected LayerMask _pushableLayer;
        protected float _delay = 0.15f;
        protected float _timer = 0.0f;

        private void Start(){
            _groundTiles = GameObject.Find("GroundTiles").GetComponent<Tilemap>();
            Vector2 pos = transform.position;
            Vector3Int gridPosition = _groundTiles.WorldToCell(new Vector2(Mathf.CeilToInt(pos.x), Mathf.CeilToInt(pos.y)));
            if(!_groundTiles.HasTile(gridPosition))
                throw new System.TypeLoadException($"{transform.name} starting position not on a tile.");
            GridPosition = gridPosition;
            _pushableLayer = LayerMask.GetMask("Pushable");
            transform.position = SetPos(gridPosition);
        }

        protected bool ValidTile(Vector3Int tile) => _groundTiles.HasTile(tile);
        protected Vector3 SetPos(Vector3Int tile) => _groundTiles.CellToWorld(tile);

        private void OnEnable(){
            if(!ObjectStore.AllTiles.Contains(this))
                ObjectStore.AllTiles.Add(this);
        }

        private void OnDisable(){
            if(ObjectStore.AllTiles.Contains(this))
                ObjectStore.AllTiles.Remove(this);
        }

        private void OnDestroy(){
            if(ObjectStore.AllTiles.Contains(this))
                ObjectStore.AllTiles.Remove(this);
        }
    }
}
