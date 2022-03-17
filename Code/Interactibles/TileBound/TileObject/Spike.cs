using UnityEngine;

namespace BlockPuzzle
{
    public class Spike : TileObject
    {
        public override void ContactEvent(TileBound caller, Vector3Int contactDirection)
        {
            if(caller.GetType() == typeof(PlayerController)) GameManager.Instance.ResetScene();
        }
    }
}
