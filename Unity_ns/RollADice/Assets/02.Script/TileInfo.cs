using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public int Id;

    protected virtual void Awake()  //오버라이드를 하기 위해서 virtual을 쓴다.
    {
        Id = transform.GetSiblingIndex() + 1;
    }
    public virtual void OnTile()
    {
        Debug.Log($"{Id} 칸에 도착했습니다.");
    }

    public int CompaterTo(TileInfo other)
    {
        return this.Id - other.Id;
    }

    //연산자 오버로딩
    public static bool operator > (TileInfo op1, TileInfo op2)
    {
        return op1.Id > op2.Id;
    }
    public static bool operator <(TileInfo op1, TileInfo op2)
    {
        return op1.Id < op2.Id;
    }

}
