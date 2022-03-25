namespace Sokoban
{
    public class Gate : TileObject, ICheck
    {
        public Switch[] Switches;

        public void Check()
        {
            bool allDown = true;
            foreach(Switch s in Switches){
                allDown &= s.Active;
            }
            blocking = !allDown;
        }
    }
}
