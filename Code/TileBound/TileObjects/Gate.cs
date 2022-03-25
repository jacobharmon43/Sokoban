using UnityEngine;

namespace Sokoban
{
    public class Gate : TileObject, ICheck
    {
        public Switch[] Switches;

        public void Check()
        {
            bool allDown = true;
            foreach(Switch s in Switches){
                allDown &= s.Active;
            }
            blocking = !allDown;
            transform.GetComponent<SpriteRenderer>().color = allDown ? new Color(1,1,1,0.5f) : Color.white;
        }
    }
}
