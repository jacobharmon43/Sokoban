namespace Sokoban
{
    public class TileObject : TileBound
    {
        public bool blocking = true;
        public bool glass = false;

        public virtual void ContactEvent(){
            
        }
    }
}
