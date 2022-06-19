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
    // カプセル化：他ファイルから値の取得はできるが変更はできない
    public int MaxHP { get => maxHP; }
    public int Attack { get => attack; }
    public int Defense { get => defense; }
    public int SpAttack { get => spAttack; }
    public int SpDefense { get => spDefense; }
    public int Speed { get => speed; }
}

// タイプの定数設定
public enum MonsterType
{
    None,
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