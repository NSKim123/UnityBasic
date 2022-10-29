using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopUpAsset : MonoBehaviour
{
    private static DamagePopUpAsset _instance;
    public static DamagePopUpAsset Instance
    {
        get
        {
            if (_instance == null)
                _instance = Instantiate<DamagePopUpAsset>(Resources.Load<DamagePopUpAsset>("DamagePopUpAsset"));
            return _instance;
        }
    }

    [SerializeField] private List<DamagePopUp> _damagePopUps;
    private Dictionary<LayerMask, DamagePopUp> _damagePopUpDictionary = new Dictionary<LayerMask, DamagePopUp>();

    public DamagePopUp GetDamagePopUp(LayerMask layer) => _damagePopUpDictionary[layer];

    private void Awake()
    {
        foreach(DamagePopUp item in _damagePopUps)
        {
            _damagePopUpDictionary.Add(item.Layer, item);
        }
    }

}
