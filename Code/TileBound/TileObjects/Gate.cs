using UnityEngine;

namespace Sokoban
{
    public class Gate : Switchable
    {
        public override void SwitchesDown()
        {
            blocking = false;
            _tiles.GetTile(GridPosition).Object = this;
            GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);
        }

        public override void SwitchesUp()
        {
            blocking = false;
            _tiles.GetTile(GridPosition).Object = null;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
