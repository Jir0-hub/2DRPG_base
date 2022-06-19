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
    public int HP { get; set; }
    // 使える技
    public List<Move> Moves { get; set; }

    // コンストラクター：生成時の初期設定
    public Monster(MonsterBase pBase, int pLevel)
    {
        _base = pBase;
        level = pLevel;
        HP = pBase.MaxHP;

        // 使える技の設定：覚える技のレベル以上なら、Movesに追加
        foreach (LearnableMove learnableMove in pBase.LearnableMoves)
        {
            if (level >= learnableMove.Level)
            {
                //技を覚える：覚える技に設定した技ベースを取得
                Moves.Add(new Move(learnableMove.Base));
            }

            // 4つ以上の技は使えない
            if (Moves.Count >=4)
            {
                break;
            }
        }
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
