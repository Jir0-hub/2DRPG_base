using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    // バトルで使うモンスターを保持

    // 戦うモンスターをセットする
    [SerializeField] MonsterBase _base;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;

    // BattleSystemで使用するからカプセル化
    public Monster Monster { get; set; }

    public void Setup()
    {
        // _baseからレベルに応じたモンスターを生成する
        Monster = new Monster(_base, level);

        Image image = GetComponent<Image>();
        if (isPlayerUnit)
        {
            image.sprite = Monster.Base.BackSprite;
        }
        else
        {
            image.sprite = Monster.Base.FrontSprite;
        }
    }
}
