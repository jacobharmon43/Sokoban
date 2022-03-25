using UnityEngine;
using System.Collections.Generic;

namespace Sokoban
{
    public class Gun : Switchable
    {
        private bool _firing = false;
        [SerializeField] private GameObject _laserPrefab;
        [SerializeField] private List<GameObject> _spawned;

        public override void SwitchesDown()
        {
            _firing = false;
        }

        public override void SwitchesUp()
        {
            _firing = true;
        }

        public override void CheckFunc(){
            base.Check();
            if(_firing)
                Fire();
        }

        private void Fire(){
            _spawned.Clear();
        }


    }
}
