using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileInfoStar : TileInfo
{
    private int _starValue;
    public int StarValue
    {
        get
        {
            return _starValue;
        }
        set
        {
            _starValue = value;
            if (_starValueText != null)
            {
                _starValueText.text = _starValue.ToString();
            }
            _starValueText.text = _starValue.ToString();
        }

    }
    [SerializeField] private TMP_Text _starValueText;

    public override void OnTile()
    {
        base.OnTile();
        StarValue++;
    }


    protected override void Awake()  //protected : 자식객체만 참조를 할 수 있는 함수. (TileInfo (부모)- TileInfoStar(자식))
    {
        base.Awake();
        StarValue = Constants.STAR_VALUE_INIT;
        _starValueText = transform.GetComponentInChildren<TMP_Text>();
    }
}
