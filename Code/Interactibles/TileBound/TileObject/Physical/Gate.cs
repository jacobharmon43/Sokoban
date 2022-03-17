using UnityEngine;

namespace BlockPuzzle
{
    public class Gate : Physical, ISwitchable
    {
        private SpriteRenderer sp;
        
        private void Awake(){
            sp = GetComponent<SpriteRenderer>();
        }

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
            sp.color = sp.color - new Color32(0,0,0,100);
        }

        private void Close(){
            active = true;
            sp.color = sp.color + new Color32(0,0,0,100);
        }

        public override void ContactEvent(TileBound caller)
        {
            //Nothing
        }
    }
}
