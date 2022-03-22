using UnityEngine;

namespace BlockPuzzle
{
    public class Ice : TileMaterial
    {
        Vector3Int dir = Vector3Int.zero;
        public override void OnTopEvent(TileBound caller, Vector3Int entranceDirection)
        {
            if(caller.GetType() == typeof(PlayerController)) return;
            Pushable p = caller.GetComponent<Pushable>();
            if(!p) return;
            p.Move(entranceDirection);
        }
    }
}
