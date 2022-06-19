using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// レベルに応じたステータスを反映したモンスターを生成するクラス
// 注意：データのみ扱う純粋C#のクラス（例：Vector3とか）
public class Monster
{
    // ベースとなるデータ
    MonsterBase _base;
    int level;

    // コンストラクター：生成時の初期設定
    public Monster(MonsterBase pBase, int pLevel)
    {
        _base = pBase;
        level = pLevel;
    }

    // levelに応じたステータスを返すもの：プロパティ
    public int MaxHP
    {
        get { return Mathf.FloorToInt((_base.MaxHP * level) / 100f) + 10; }
    }
    public int Attack
    {
        get { return Mathf.FloorToInt((_base.Attack * level) / 100f) + 5; }
    }
    public int Defense
    {
        get { return Mathf.FloorToInt((_base.Defense * level) / 100f) + 5; }
    }
    public int SpAttack
    {
        get { return Mathf.FloorToInt((_base.SpAttack * level) / 100f) + 5; }
    }
    public int SpDefense
    {
        get { return Mathf.FloorToInt((_base.SpDefense * level) / 100f) + 5; }
    }
    public int Speed
    {
        get { return Mathf.FloorToInt((_base.Speed * level) / 100f) + 5; }
    }
}
