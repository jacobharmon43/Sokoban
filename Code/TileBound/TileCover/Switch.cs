namespace Sokoban
{
    public class Switch : TileCover
    {
        public bool Active;
        public override void StepOffEvent(TileObject to)
        {
            Active = false;
        }

        public override void StepOnEvent(TileObject to)
        {
            Active = true;
        }
    }
}
