using UnityEngine;

namespace BlockPuzzle
{
    public abstract class TileMaterial : TileBound{
        public abstract void OnTopEvent(TileBound caller, Vector3Int entranceDirection);
    }
}
