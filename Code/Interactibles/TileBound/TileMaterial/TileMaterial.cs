using UnityEngine;

namespace BlockPuzzle
{
    public abstract class TileMaterial : TileBound{
        public abstract void AugmentMovement(Pushable p, Vector3Int direction);
    }
}
