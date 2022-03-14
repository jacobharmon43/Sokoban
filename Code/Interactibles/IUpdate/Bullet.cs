using UnityEngine;

namespace BlockPuzzle
{
    public class Bullet : Pushable, IUpdate
    {
        public Vector3Int direction;

        private void Awake(){
            active = false;
        }

        public void UpdateAction()
        {
            if(PlayerOnTile()){
                GameManager.Instance.ResetScene();
            }
            if(!Move(direction)){
                Destroy(gameObject);
                return;
            }
            if(PlayerOnTile()){
                GameManager.Instance.ResetScene();
            }
        }

        private bool PlayerOnTile(){
            foreach(PlayerController p in ObjectStore.OfTypeInList<PlayerController>()){
                if(p.GridPosition == GridPosition){
                    return true;
                }
            }
            return false;
        }
    }
}
