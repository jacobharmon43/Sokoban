using UnityEngine;

namespace BlockPuzzle
{
    public abstract class TileObject : TileBound
    {
        public bool blocking = true;
        public virtual void ContactEvent(TileBound caller, Vector3Int contactDirection){}
    }
}
