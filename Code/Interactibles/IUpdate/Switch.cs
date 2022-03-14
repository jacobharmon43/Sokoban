using UnityEngine.Events;
using UnityEngine;

namespace BlockPuzzle
{
    public class Switch : TileBound, IUpdate
    {
        public ISwitchable toSwitch;
        private bool _activated = false;

        private void Awake(){
            _activated = ObjectOnSwitch();
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
            if(_activated && !ObjectOnSwitch()){
                toSwitch.SwitchUp();
                _activated = false;
            }
            else if(!_activated && ObjectOnSwitch()){
                toSwitch.SwitchDown();
                _activated = true;
            }
        }
    }
}
