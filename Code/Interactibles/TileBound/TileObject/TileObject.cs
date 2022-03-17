namespace BlockPuzzle
{
    public abstract class TileObject : TileBound
    {
        public virtual void ContactEvent(TileBound caller){}
    }
}
