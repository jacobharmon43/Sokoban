using UnityEngine;

namespace Sokoban.Grid
{
    public class Tile : MonoBehaviour
    {
        public bool isGround;
        private TileObject Object = null;
        private TileCover Cover = null;

        public void SetObject(TileObject to){
            if(Cover){
                if(to)
                    Cover.StepOnEvent(to);
                else
                    Cover.StepOffEvent(to);
            }
            Object = to;
        }

        public void SetCover(TileCover tc){
            Cover = tc;
            if(Object){
                Cover.StepOnEvent(Object);
            }
        }

        public TileObject GetObject() => Object;
        public TileCover GetCover() => Cover;
    }

    public class Wall : Tile{
        private void Start(){
            isGround = false;
        }
    }

    public class Ground : Tile{
        private void Start(){
            isGround = true;
        }
    }
}
