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
            if(!GroundTiles) GroundTiles = GameObject.Find("GroundTiles").GetComponent<Tilemap>();
            _pushableLayer = LayerMask.GetMask("Pushable");
            GridPosition = GroundTiles.WorldToCell(transform.position);
            if(!ValidTile(GridPosition))
                throw new System.Exception($"Tilebound object: {transform.name} starting location is off the grid");
            transform.position = GroundTiles.CellToWorld(GridPosition);
        }

        protected bool ValidTile(Vector3Int tile) => GroundTiles.HasTile(tile);

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
