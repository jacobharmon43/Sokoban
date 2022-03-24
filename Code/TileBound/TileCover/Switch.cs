namespace Sokoban
{
    public class Switch : TileCover
    {
        public bool Active;
        public override void StepOffEvent(TileObject to)
        {
            Active = false;
            UnityEngine.Debug.Log("Switch stepped off!");
        }

        public override void StepOnEvent(TileObject to)
        {
            Active = true;
            UnityEngine.Debug.Log("Switch stepped on!");
        }
    }
}
