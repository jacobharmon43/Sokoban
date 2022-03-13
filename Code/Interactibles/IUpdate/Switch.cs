using UnityEngine.Events;
using UnityEngine;

namespace BlockPuzzle
{
    public class Switch : TileBound, IUpdate
    {
        public GameObject toSwitch;
        private ISwitchable s;
        [SerializeField] private bool _activated;

        private void Awake(){
            _activated = ObjectOnSwitch();
            s = toSwitch.GetComponent<ISwitchable>();
            if(s == null){
                throw new System.Exception("toSwitch not of type ISwitchable");
            }
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
                s.SwitchUp();
                _activated = false;
            }
            else if(!_activated && ObjectOnSwitch()){
                s.SwitchDown();
                _activated = true;
            }
        }
    }
}
