namespace BlockPuzzle
{
    public class Spike : Physical
    {
        public override void ContactEvent(TileBound caller)
        {
            if(caller.GetType() == typeof(PlayerController)) GameManager.Instance.ResetScene();
        }
    }
}
