using UnityEngine;

namespace BlockPuzzle
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Blocking : TileObject, ISwitchable
    {
        private SpriteRenderer _sr;

        private void Awake(){
            _sr = GetComponent<SpriteRenderer>();
        }

        public void SwitchDown()
        {
            blocking = false;
            _sr.color /= 2;
        }

        public void SwitchUp()
        {
            _sr.color *= 2;
            blocking = true;
            TileObject to = ObjectOnTile(GridPosition);
            if(to){
                if(to.GetType() == typeof(PlayerController)){
                    GameManager.Instance.ResetScene();
                    return;
                }
                Destroy(to.gameObject);
            }
        }
    }
}
