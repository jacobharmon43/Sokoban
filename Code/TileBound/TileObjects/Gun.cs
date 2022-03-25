using UnityEngine;
using Sokoban.Grid;
using System.Collections.Generic;

namespace Sokoban
{
    public class Gun : Switchable
    {
        public char dirChar = '<';
        private bool _firing = false;
        [SerializeField] private TileObject _laserPrefab;
        private List<GameObject> _spawned;
        private Dictionary<char, Vector2> d = new Dictionary<char, Vector2>(){
            {'<', new Vector2(-1,0)},
            {'^', new Vector2(0,1)},
            {'>', new Vector2(1,0)},
            {'v', new Vector2(0,-1)}
        };
        private Vector2Int dir;

        protected override void Start(){
            base.Start();
            RotateToChar(dirChar);
            Fire();
        }

        public override void SwitchesDown()
        {
            _firing = false;
        }

        public override void SwitchesUp()
        {
            _firing = true;
        }

        public override void CheckFunc(){
            base.Check();
            if(_firing)
                Fire();
        }

        private void Fire(){
            foreach(GameObject obj in _spawned){
                _tiles.GetTile(GridPosition).Object = null;
                Destroy(obj);
            }
            _spawned.Clear();
            Vector2Int p = GridPosition;
            Tile t = _tiles.GetTile(p);
            int tc = 0;
            while(t && t.ground && !t.Object && tc < 5){
                t.Object = Instantiate<TileObject>(_laserPrefab, t.transform.position, transform.rotation);
                p += dir;
                t = _tiles.GetTile(p);
                tc++;
            }
        }

        private void RotateToChar(char c){
            transform.rotation = Quaternion.Euler(d[c]);
            dir = new Vector2Int((int)d[c].x, (int)d[c].y);
        }
    }
}
