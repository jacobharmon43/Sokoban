using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockPuzzle
{
    public class Gun : Physical, IUpdate
    {
        public char rotationChar = '<';

        private void Start(){
            switch (rotationChar){
                case '<':
                    transform.rotation = Quaternion.identity;
                    break;
                case '>':
                    transform.rotation = Quaternion.identity;
                    break;
                case '^':
                    transform.rotation = Quaternion.Euler(0,0,90);
                    break;
                case 'v':
                    transform.rotation = Quaternion.Euler(0,0,90);
                    break;
                default:
                    transform.rotation = Quaternion.identity;
                    break;
            }
        }

        public void UpdateAction()
        {
            Debug.Log("yes");
        }
    }
}
