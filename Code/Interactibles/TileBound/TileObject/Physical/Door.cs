namespace BlockPuzzle
{
    public class Door : Physical
    {
        public override void ContactEvent(TileBound caller)
        {
            if(caller.GetType() == typeof(Key)){
                Destroy(caller.gameObject);
                Unlock();
            }
        }

        public void Unlock(){
            Destroy(gameObject);
        }
    }
}
