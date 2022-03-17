namespace BlockPuzzle
{
    public class Laser : TileObject, IUpdate
    {
        public Physical BlockerOnTile(){
            foreach(Physical p in ObjectStore.OfTypeInList<Physical>()){
                if(p.GridPosition == GridPosition) return p;
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
