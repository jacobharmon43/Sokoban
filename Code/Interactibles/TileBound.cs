using UnityEngine.Tilemaps;
using UnityEngine;

namespace BlockPuzzle{
    [System.Serializable]
    public class TileBound : MonoBehaviour
    {
        public Vector3Int GridPosition;
        public Tilemap GroundTiles;
        protected LayerMask _pushableLayer;
        protected float _delay = 0.15f;
        protected float _timer = 0.0f;

        private void Start(){
            _pushableLayer = LayerMask.GetMask("Pushable");
        }

        protected bool ValidTile(Vector3Int tile) => GroundTiles.HasTile(tile);
        protected Vector3 SetPos(Vector3Int tile) => GroundTiles.CellToWorld(tile);

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
