using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockPuzzle
{
    public class Conveyor : TileMaterial, IUpdate
    {
        [SerializeField] private char rotationChar = '<';
        private Vector3Int _dir;
        protected override void Awake()
        {
            base.Awake();
            switch (rotationChar){
                case '<':
                    transform.rotation = Quaternion.identity;
                    _dir = new Vector3Int(-1,0,0);
                    break;
                case '>':
                    transform.rotation = Quaternion.Euler(0,0,180);
                    _dir = new Vector3Int(1,0,0);
                    break;
                case '^':
                    transform.rotation = Quaternion.Euler(0,0,-90);
                    _dir = new Vector3Int(0,1,0);
                    break;
                case 'v':
                    transform.rotation = Quaternion.Euler(0,0,90);
                    _dir = new Vector3Int(0,-1,0);
                    break;
                default:
                    transform.rotation = Quaternion.identity;
                    break;
            }
        }
        public override void OnTopEvent(TileBound caller, Vector3Int entranceDirection)
        {
            //Nothing
        }

        public void UpdateAction()
        {
            TileObject to = ObjectOnTile(GridPosition);
            if(to && to.GetType() != typeof(PlayerController)){
                Pushable p = GetComponent<Pushable>();
                if(p)
                    p.Move(_dir);
            }
        }
    }
}
