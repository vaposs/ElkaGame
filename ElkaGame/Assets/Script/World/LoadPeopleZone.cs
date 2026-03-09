using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  ElkaGame.Men
{
    public class LoadPeopleZone : MonoBehaviour
    {
        private LoadPeopl _tempLoadPeopl;

        public bool IsFreePlace {get; private set;} = true;

        public void TakeParking()
        {
            IsFreePlace = false;
        }

        public void SetFree()
        {
            IsFreePlace = true;
        }
    }
}

