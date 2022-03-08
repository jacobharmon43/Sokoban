namespace BlockPuzzle
{
    public class Door : Physical
    {
        public void Unlock(){
            Destroy(gameObject);
        }
    }
}
