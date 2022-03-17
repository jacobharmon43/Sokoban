using UnityEngine;
using System.Collections.Generic;

namespace BlockPuzzle
{
    public class Gun : Physical, IUpdate
    {
        [SerializeField] private char rotationChar = '<';
        [SerializeField] private GameObject laser;

        private Vector3Int dir;
        private List<GameObject> lasers = new List<GameObject>();

        private void Awake(){
            switch (rotationChar){
                case '<':
                    transform.rotation = Quaternion.identity;
                    dir = new Vector3Int(-1,0,0);
                    break;
                case '>':
                    transform.rotation = Quaternion.Euler(0,0,180);
                    dir = new Vector3Int(1,0,0);
                    break;
                case '^':
                    transform.rotation = Quaternion.Euler(0,0,-90);
                    dir = new Vector3Int(0,1,0);
                    break;
                case 'v':
                    transform.rotation = Quaternion.Euler(0,0,90);
                    dir = new Vector3Int(0,-1,0);
                    break;
                default:
                    transform.rotation = Quaternion.identity;
                    break;
            }
        }

        public void UpdateAction()
        {
            foreach(GameObject l in lasers){
                Destroy(l);
            }
            lasers.Clear();    
            Vector3Int nextPos = GridPosition + dir;
            while(_groundTiles.HasTile(nextPos)){
                Laser tmp = Instantiate<GameObject>(laser, SetPos(nextPos), transform.rotation).GetComponent<Laser>();
                tmp.GridPosition = nextPos;
                nextPos += dir;
                lasers.Add(tmp.gameObject);
                Physical blocker = tmp.BlockerOnTile();
                if(blocker && blocker.active){
                    if(blocker.GetComponent<PlayerController>())
                        GameManager.Instance.ResetScene();
                    else{
                        lasers.Remove(tmp.gameObject);
                        Destroy(tmp.gameObject);
                        break;
                    }
                }
            }
        }

        public override void ContactEvent(TileBound caller)
        {
            if(caller.GetType() == typeof(PlayerController)) GameManager.Instance.ResetScene();
        }
    }
}
