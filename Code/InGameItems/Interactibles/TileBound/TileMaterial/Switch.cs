using UnityEngine;

namespace BlockPuzzle
{
    public class Switch : TileMaterial, IUpdate
    {
        public GameObject switchedObject;
        private ISwitchable toSwitch;
        public bool Activated = false;

        protected override void Awake(){
            base.Awake();
            toSwitch = switchedObject.GetComponent<ISwitchable>();
            Activated = ObjectOnTile(GridPosition);
        }

        public void UpdateAction(){
            if(Activated && !ObjectOnTile(GridPosition)){
                toSwitch.SwitchUp();
                Activated = false;
            }
            else if(!Activated && ObjectOnTile(GridPosition)){
                toSwitch.SwitchDown();
                Activated = true;
            }
        }

        public override void OnTopEvent(TileBound caller, Vector3Int entranceDirection)
        {
            //Will put something here eventually, just can't really figure out how to figure out ExitTopEvents
        }
    }
}
