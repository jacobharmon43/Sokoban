using UnityEngine;

namespace BlockPuzzle
{
    public class Door : TileObject
    {
        public override void ContactEvent(TileBound caller, Vector3Int contactDirection)
        {
            if(caller.GetType() == typeof(Key)){
                Destroy(caller.gameObject);
                Unlock();
            }
        }

        public void Unlock(){
            Destroy(gameObject);
        }
    }
}
