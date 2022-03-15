using UnityEngine;

namespace BlockPuzzle
{
    public class Laser : TileBound, IUpdate
    {
        public void UpdateAction()
        {
            if(PlayerOnTileOrNextTile()){
                GameManager.Instance.ResetScene();
            }
        }

        private bool PlayerOnTileOrNextTile(){
            foreach(PlayerController p in ObjectStore.OfTypeInList<PlayerController>()){
                if(p.GridPosition == GridPosition){
                    return true;
                }
            }
            return false;
        }
    }
}
