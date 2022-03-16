using UnityEngine.Tilemaps;
using UnityEngine;

namespace BlockPuzzle{
    [System.Serializable]
    public class TileBound : MonoBehaviour
    {
        public Vector3Int GridPosition;
<<<<<<< HEAD
        private Tilemap _groundTiles;
        protected float _delay = 0.15f;
        protected float _timer = 0.0f;
=======
        protected Tilemap _groundTiles;
        protected LayerMask _pushableLayer;
>>>>>>> 266c47b3a2a0e4aabe8f98f641395f8a7b7f3597

        private void Start(){
            _groundTiles = GameObject.Find("GroundTiles").GetComponent<Tilemap>();
            Vector2 pos = transform.position;
            Vector3Int gridPosition = _groundTiles.WorldToCell(new Vector2(Mathf.CeilToInt(pos.x), Mathf.CeilToInt(pos.y)));
            if(!ValidTile(gridPosition))
                throw new System.TypeLoadException($"{transform.name} starting position not on a tile.");
            GridPosition = gridPosition;
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
