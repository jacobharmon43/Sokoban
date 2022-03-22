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
            if(caller.GetType() == typeof(PlayerController)) return;
            Pushable p = caller.GetComponent<Pushable>();
            if(!p) return;
            p.Move(_dir);
        }

        public void UpdateAction()
        {
            TileObject to = ObjectOnTile(GridPosition);
            if(!to || to.GetType() == typeof(PlayerController)) return;
            Pushable p = to.GetComponent<Pushable>();
            if(!p) return;
            p.Move(_dir);
        }
    }
}
