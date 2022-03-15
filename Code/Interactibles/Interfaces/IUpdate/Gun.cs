using UnityEngine;
using System.Collections.Generic;

namespace BlockPuzzle
{
    public class Gun : Physical, IUpdate
    {
        [SerializeField] private char rotationChar = '<';
        [SerializeField] private GameObject laser;

        private Vector3Int dir;
        private List<Laser> lasers = new List<Laser>();

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
            foreach(Laser l in lasers){
                Destroy(l.gameObject);
            }
            lasers.Clear();
            Physical[] blockingObjects = ObjectStore.OfTypeInList<Physical>().ToArray();
            Vector3Int nextPos = GridPosition + dir;
            while(!BlockerOnNextPos(blockingObjects,nextPos)){
                Laser tmp = Instantiate<GameObject>(laser, SetPos(nextPos), transform.rotation).GetComponent<Laser>();
                nextPos += dir;
                lasers.Add(tmp);
            }
        }

        private bool BlockerOnNextPos(Physical[] p, Vector3Int nextPos){
            if(!_groundTiles.HasTile(nextPos)) return true;
            foreach(Physical blocker in p){
                if(blocker.GridPosition == nextPos && blocker.active){
                    if(blocker.GetComponent<PlayerController>()) GameManager.Instance.ResetScene();
                    return true;
                }
            }
            return false;
        }
    }
}
