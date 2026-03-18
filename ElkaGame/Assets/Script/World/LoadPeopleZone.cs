using UnityEngine;

namespace  ElkaGame.Men
{
    public class LoadPeopleZone : MonoBehaviour
    {
        public bool IsFreePlace {get; private set;} = true;

        public void SetFree()
        {
            IsFreePlace = true;
        }

        public void SetBusy()
        {
            IsFreePlace = false;
        }
    }
}

