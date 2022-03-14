using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockPuzzle
{
    public class Gun : Physical, IUpdate
    {
        public char rotationChar = '<';
        private Vector3Int dir;
        [SerializeField] private GameObject b;
        [SerializeField] private int UpdatesPerShot = 3;
        private int timer = 0;

        private void Awake(){
            switch (rotationChar){
                case '<':
                    transform.rotation = Quaternion.identity;
                    dir = new Vector3Int(-1,0,0);
                    break;
                case '>':
                    transform.rotation = Quaternion.identity;
                    dir = new Vector3Int(1,0,0);
                    break;
                case '^':
                    transform.rotation = Quaternion.Euler(0,0,90);
                    dir = new Vector3Int(0,-1,0);
                    break;
                case 'v':
                    transform.rotation = Quaternion.Euler(0,0,90);
                    dir = new Vector3Int(0,1,0);
                    break;
                default:
                    transform.rotation = Quaternion.identity;
                    break;
            }
        }

        public void UpdateAction()
        {
            if(timer != 0){
                timer -= 1;
                return;
            }
            Bullet tmp = Instantiate<GameObject>(b, SetPos(GridPosition+dir), transform.rotation).GetComponent<Bullet>();
            tmp.direction = dir;
            timer = UpdatesPerShot;
        }
    }
}
