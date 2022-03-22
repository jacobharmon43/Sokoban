using UnityEngine;

namespace BlockPuzzle
{
    public class Ice : TileMaterial, IUpdate
    {
        Vector3Int dir = Vector3Int.zero;
        public override void OnTopEvent(TileBound caller, Vector3Int entranceDirection)
        {
            if(caller.GetType() == typeof(PlayerController)) return;
            Pushable p = caller.GetComponent<Pushable>();
            if(p)
                dir = entranceDirection;
        }

        public void UpdateAction()
        {
            TileObject to = ObjectOnTile(GridPosition);
            if(to){
                Pushable p = to.GetComponent<Pushable>();
                if(p && p.GetType() != typeof(PlayerController)){
                    p.Move(dir);
                }
            }
        }
    }
}
