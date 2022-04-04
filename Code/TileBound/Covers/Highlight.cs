namespace Sokoban
{
    public class Highlight : TileCover
    {
        public bool BoxOn;

        public override void StepOnEvent(TileObject to)
        {
            if(to && to.GetType() == typeof(Box)){
                BoxOn = true;
            }
        }

        public override void StepOffEvent(TileObject to)
        {
            if(to && to.GetType() == typeof(Box)){
                BoxOn = false;
            }
        }
    }
}