using UnityEngine;

namespace BlockPuzzle
{
    public class Flag : TileMaterial
    {
        public override void OnTopEvent(TileBound caller, Vector3Int entranceDirection)
        {
            if(caller.GetType() == typeof(PlayerController)) GameManager.Instance.LoadScene(0);
        }
    }
}
