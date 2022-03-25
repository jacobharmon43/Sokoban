namespace Sokoban
{
    public class PlayerKill : TileObject, ICheck
    {
        public void Check()
        {
            if(_tiles.GetTile(GridPosition).Object.GetType() == typeof(PlayerController))
                GameManager.Instance.ReloadScene();
        }

        protected override void Start(){
            blocking = false;
            base.Start();
        }
    }
}
