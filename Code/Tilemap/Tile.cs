using UnityEngine;

namespace Sokoban.Grid
{
    public class Tile : MonoBehaviour
    {
        public bool ground;
        public TileObject Object = null;
        public TileCover Cover = null;

        public void AddTileObject(TileObject to){
            if(Cover){
                Cover.StepOnEvent(to);
            }
            Object = to;
        }

        public void RemoveTileObject(TileObject to){
            if(Cover){
                Cover.StepOffEvent(to);
            }
            Object = null;
        }

        public void AddCover(TileCover tc){
            Cover = tc;
            if(Object){
                Cover.StepOnEvent(Object);
            }
        }
    }
}