namespace Sokoban{
    public class Highlight : TileCover{
        public bool BoxOn;
        public override void StepOffEvent(TileObject to)
        {
            BoxOn = false;
        }

        public override void StepOnEvent(TileObject to)
        {
            if(to.GetType() == typeof(PlayerController)) return;
            BoxOn = true;
        }
    }
}
