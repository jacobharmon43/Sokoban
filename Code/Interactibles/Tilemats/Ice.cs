using UnityEngine;

namespace BlockPuzzle
{
    public class Ice : TileMaterial
    {
        public override void AugmentMovement(Pushable p, Vector3Int direction)
        {
            do{
                p.Move(direction);
            }while(p.NextTileMaterial(direction).GetComponent<Ice>());
        }
    }
}
