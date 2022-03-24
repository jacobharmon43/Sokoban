namespace Sokoban
{
    public abstract class TileCover : TileBound
    {
        public abstract void StepOnEvent();
        public abstract void StepOffEvent();
    }
}
