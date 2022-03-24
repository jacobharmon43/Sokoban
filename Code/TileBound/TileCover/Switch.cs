namespace Sokoban
{
    public class Switch : TileCover
    {
        public override void StepOnEvent()
        {
            UnityEngine.Debug.Log("Switch stepped on!");
        }
    }
}
