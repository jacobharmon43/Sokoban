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
        [SerializeField] private List<TileObject> _spawned = new List<TileObject>();
        private Dictionary<char, Vector2> d = new Dictionary<char, Vector2>(){
            {'<', new Vector2(-1,0)},
            {'^', new Vector2(0,-1)},
            {'>', new Vector2(1,0)},
            {'v', new Vector2(0,1)}
        };
        private Vector2Int dir;

        protected override void Start(){
            base.Start();
            RotateToChar(dirChar);
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
            base.CheckFunc();
            if(_spawned.Count > 0)
                ClearList();
            if(_firing)
                Fire();
        }

        private void Fire(){
            Vector2Int p = GridPosition + dir;
            Tile t = _tiles.GetTile(p);
            if(t && t.Object && t.Object.GetType() == typeof(PlayerController))
                GameManager.Instance.ReloadScene();
            int count = 0;
            while(t && t.ground && count < 10){
                count++;
                TileObject to = t.Object;
                if(to && to.blocking && !to.glass) break;
                _spawned.Add(Instantiate<TileObject>(_laserPrefab, t.transform.position, transform.rotation));
                p += dir;
                t = _tiles.GetTile(p);
                if(t.Object && t.Object.GetType() == typeof(PlayerController))
                    GameManager.Instance.ReloadScene();
            }
        }

        private void RotateToChar(char c){
            transform.rotation = Quaternion.Euler(new Vector3(0,0,180 * d[c].x + 90 * d[c].y));
            dir = new Vector2Int((int)d[c].x, (int)d[c].y);
        }

        private void ClearList(){
            foreach(TileObject obj in _spawned){
                Destroy(obj.gameObject);
            }
            _spawned.Clear();
        }
    }
}
