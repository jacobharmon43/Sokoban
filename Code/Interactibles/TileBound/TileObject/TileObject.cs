using UnityEngine;

namespace BlockPuzzle
{
    public abstract class TileObject : TileBound, ISwitchable
    {
        public bool blocking = true;
        public virtual void ContactEvent(TileBound caller, Vector3Int contactDirection){}

        public void SwitchDown()
        {
            blocking = false;
        }

        public void SwitchUp()
        {
            blocking = true;
        }
    }
}
