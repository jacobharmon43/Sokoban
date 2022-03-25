namespace Sokoban
{
    public abstract class Switchable : TileObject, ICheck
    {
        public Switch[] Switches;

        public void Check()
        {
            CheckFunc();
        }

        public virtual void CheckFunc(){
            bool allDown = true;
            foreach(Switch s in Switches){
                allDown &= s.Active;
            }
            if(allDown) SwitchesDown();
            else SwitchesUp();
        }

        public abstract void SwitchesDown();
        public abstract void SwitchesUp();
    }
}
