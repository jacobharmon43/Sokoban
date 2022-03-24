namespace Sokoban
{
    public class TileObject : TileBound
    {
        public virtual void ContactEvent(){
            UnityEngine.Debug.Log($"Contact made with {transform.name}");
        }

    }
}
