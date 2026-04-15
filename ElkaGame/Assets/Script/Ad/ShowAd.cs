using ElkaGame.Men;
using UnityEngine;
using YG;

public class ShowAd : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    private LoadPeopleZone _parkingPlace;

    private SendParking _sendParking;
    private void Awake()
    {
        _sendParking = FindAnyObjectByType<SendParking>();
        _parkingPlace = GetComponent<LoadPeopleZone>();
        _parkingPlace.enabled = false;
        _meshRenderer.enabled = true;
        YG2.StickyAdActivity(true);
    }

    private void ActiveLoadZone()
    {
        _parkingPlace.enabled = true;
        _meshRenderer.enabled = false;
        _sendParking.AddLoadPeopleZone(_parkingPlace);   
    }
    public void StartShowAd()
    {
        string id = "loadPlace";
        YG2.RewardedAdvShow(id, ActiveLoadZone);
    }

    public void ShowAdNextLvl()
    {
        YG2.InterstitialAdvShow();
    }
}
