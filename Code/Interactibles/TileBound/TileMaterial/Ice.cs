using UnityEngine;

namespace BlockPuzzle
{
    public class Ice : TileMaterial
    {
        public override void OnTopEvent(TileBound caller, Vector3Int entranceDirection)
        {
            if(caller.GetType() == typeof(PlayerController)) return;
            Pushable p = caller.GetComponent<Pushable>();
            p.Move(entranceDirection);
        }
    }
}
