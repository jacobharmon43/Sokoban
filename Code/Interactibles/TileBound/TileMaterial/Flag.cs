using UnityEngine;

namespace BlockPuzzle
{
    public class Flag : TileMaterial
    {
        public override void OnTopEvent(TileBound caller, Vector3Int entranceDirection)
        {
            GameManager.Instance.LoadScene(0);
        }
    }
}
