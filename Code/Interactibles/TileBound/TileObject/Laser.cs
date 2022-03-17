namespace BlockPuzzle
{
    public class Laser : TileObject, IUpdate
    {
        public TileObject BlockerOnTile(){
            foreach(TileObject to in ObjectStore.OfTypeInList<TileObject>()){
                if(to.GridPosition == GridPosition) return to;
            }
            return null;
        }

        public void UpdateAction()
        {
            foreach(PlayerController pc in ObjectStore.OfTypeInList<PlayerController>()){
                if(pc.GridPosition == GridPosition)
                    GameManager.Instance.ResetScene();
            }
        }
    }
}
