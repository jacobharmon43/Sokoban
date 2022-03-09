using UnityEngine.Events;
using UnityEngine;

namespace BlockPuzzle
{
    public class Switch : TileBound, IUpdate
    {
        public UnityEvent OnSwitchDown;
        public UnityEvent OnSwitchUp;
        [SerializeField] private bool _activated;

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
                OnSwitchUp?.Invoke();
                _activated = false;
            }
            else if(!_activated && ObjectOnSwitch()){
                OnSwitchDown?.Invoke();
                _activated = true;
            }
        }
    }
}
