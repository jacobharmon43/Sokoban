namespace BlockPuzzle
{
    public class Gate : Physical, ISwitchable
    {
        public void SwitchDown()
        {
            Open();
        }

        public void SwitchUp()
        {
            Close();
        }

        private void Open(){
            active = false;
        }

        private void Close(){
            active = true;
        }
    }
}
