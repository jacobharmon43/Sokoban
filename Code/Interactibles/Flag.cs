using UnityEngine.Events;

namespace BlockPuzzle
{
    public class Flag : TileBound, IUpdate
    {
        public UnityEvent contactEvent;

        public void UpdateAction(){
            foreach(PlayerController pc in (ObjectStore.OfTypeInList<PlayerController>())){
                if(pc.GridPosition == GridPosition)
                    contactEvent?.Invoke();
            }
        }
    }
}
