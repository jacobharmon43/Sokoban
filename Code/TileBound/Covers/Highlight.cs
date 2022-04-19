using UnityEngine;

namespace Sokoban
{
    public class Highlight : TileCover
    {
        public bool BoxOn;

        public override void StepOnEvent(TileObject to)
        {
            if(to && to.GetType() == typeof(Box)){
                BoxOn = true;
                to.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }

        public override void StepOffEvent(TileObject to)
        {
            BoxOn = false;
            to.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}