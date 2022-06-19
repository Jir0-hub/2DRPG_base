using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// モンスターのマスターデータ：外部から変更しない（Inspectorのみ変更可能）
[CreateAssetMenu]
public class MonsterBase : ScriptableObject
{
    // 名前
    [SerializeField] new string name;
    
    // 説明
    [TextArea]
    [SerializeField] string description;
    
    // 画像
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;
    
    // タイプ
    [SerializeField] MonsterType type1;
    [SerializeField] MonsterType type2;
    
    // ステータス:hp,at,df,sAT,sDF,sp
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;

    // 覚える技一覧
    [SerializeField] List<LearnableMove> learnableMoves;
    

    // カプセル化：他ファイル（Monster.cs）から参照するためにプロパティを使う
    public int MaxHP { get => maxHP; }
    public int Attack { get => attack; }
    public int Defense { get => defense; }
    public int SpAttack { get => spAttack; }
    public int SpDefense { get => spDefense; }
    public int Speed { get => speed; }
    public List<LearnableMove> LearnableMoves { get => learnableMoves;}
    public string Name { get => name; }
    public string Description { get => description; }
    public Sprite FrontSprite { get => frontSprite; }
    public Sprite BackSprite { get => backSprite; }
    public MonsterType Type1 { get => type1; }
    public MonsterType Type2 { get => type2; }
}

// 覚える技クラス：どのレベルで何を覚えるか
[Serializable]
public class LearnableMove
{
    // ヒエラルキーで設定する
    [SerializeField] MoveBase _base;
    [SerializeField] int level;

    public MoveBase Base { get => _base; }
    public int Level { get => level; }
}

// タイプの定数設定
public enum MonsterType
{
    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon,
}