using UnityEngine;

namespace Sokoban.Grid
{
    public class Tile : MonoBehaviour
    {
        public bool ground;
        public TileObject Object = null;
        public TileCover Cover = null;

        public virtual void StepOnEvent(){
            //Nothing in base class.
        }
    }
}
