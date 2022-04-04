using UnityEngine;

namespace Sokoban{
    public class Highlight : TileCover{
        public bool BoxOn;
        public override void StepOffEvent(TileObject to)
        {
            if(to.GetType() == typeof(Player)) return;
            to.transform.GetComponent<SpriteRenderer>().color = Color.white;
            BoxOn = false;
        }

        public override void StepOnEvent(TileObject to)
        {
            if(to.GetType() == typeof(Player)) return;
            to.transform.GetComponent<SpriteRenderer>().color = Color.green;
            BoxOn = true;
        }
    }
}
