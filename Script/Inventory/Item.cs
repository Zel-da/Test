using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{

    public string itemName; // 아이템의 이름
    [TextArea]
    public string itemDesc; //아이템의 설명
    public ItemType itemType; // 아이템의 유형
    public Sprite itemImage; // 아이템의 이미지
    public GameObject itemPrefab; // 아이템의 프리팹


    public enum ItemType
    {
        QizeItem, //퀴즈 풀 때 쓰는 아니템( 평소에는 사용 못함)
        Used, // 몬스터용 소비 아이템
    }

}