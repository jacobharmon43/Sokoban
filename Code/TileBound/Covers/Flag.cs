namespace Sokoban
{
    public class Flag : TileCover
    {
        public bool PlayerOn;

        public override void StepOnEvent(TileObject to)
        {
            if(to && to.GetType() == typeof(Player)){
                PlayerOn = true;
            }
        }

        public override void StepOffEvent(TileObject to)
        {
            if(to && to.GetType() == typeof(Player)){
                PlayerOn = false;
            }
        }
    }
}