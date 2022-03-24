namespace Sokoban
{
    public class Switch : TileCover
    {
        public bool Active;
        public override void StepOffEvent()
        {
            Active = false;
            UnityEngine.Debug.Log("Switch stepped off!");
        }

        public override void StepOnEvent()
        {
            Active = true;
            UnityEngine.Debug.Log("Switch stepped on!");
        }
    }
}
