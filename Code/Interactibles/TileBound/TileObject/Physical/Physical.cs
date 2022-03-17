namespace BlockPuzzle
{
    public abstract class Physical : TileObject
    {
        public bool active = true;

        public abstract void ContactEvent(TileBound caller);
    }
}
