using Sokoban.Grid;

namespace Sokoban
{
    public class PlayerKill : TileObject, ICheck
    {
        protected override void Start(){
            base.Start();
            blocking = false;
        }

        public void Check()
        {
            Tile t = _tiles.GetTile(GridPosition);
            if(!t) return;
            TileObject to = t.Object;
            if(!to || to.GetType() != typeof(PlayerController)) return;
            GameManager.Instance.ReloadScene();
        }
    }
}
