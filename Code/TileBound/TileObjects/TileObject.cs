namespace Sokoban
{
    public class TileObject : TileBound
    {
        public bool blocking = true;

        public virtual void ContactEvent(){
            UnityEngine.Debug.Log($"Contact made with {transform.name}");
        }
    }
}
