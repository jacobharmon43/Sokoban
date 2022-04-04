namespace Sokoban
{
    public abstract class TileCover : TileBound
    {
        public abstract void StepOnEvent(TileObject to);

        public abstract void StepOffEvent(TileObject to);
    }
}