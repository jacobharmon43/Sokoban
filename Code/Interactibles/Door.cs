namespace BlockPuzzle
{
    public class Door : TileBound
    {
        public void Unlock(){
            Destroy(gameObject);
        }
    }
}
