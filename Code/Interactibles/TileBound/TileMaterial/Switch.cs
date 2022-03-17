using UnityEngine;

namespace BlockPuzzle
{
    public class Switch : TileMaterial, IUpdate
    {
        public ISwitchable toSwitch;
        public bool Activated = false;

        private void Awake(){
            Activated = ObjectOnSwitch();
        }
        
        private bool ObjectOnSwitch(){
            foreach(Pushable p in ObjectStore.OfTypeInList<Pushable>()){
                if(p.GridPosition == GridPosition){
                    return true;
                }
            }
            return false;
        }

        public void UpdateAction(){
            if(Activated && !ObjectOnSwitch()){
                toSwitch.SwitchUp();
                Activated = false;
            }
            else if(!Activated && ObjectOnSwitch()){
                toSwitch.SwitchDown();
                Activated = true;
            }
        }

        public override void OnTopEvent(TileBound caller, Vector3Int entranceDirection)
        {
            //Will put something here eventually, just can't really decide if this structure is better or worse.
        }
    }
}
