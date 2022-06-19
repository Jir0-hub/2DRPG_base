using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MoveBase : ScriptableObject
{
    // 技のマスターデータ

    // 名前
    [SerializeField] new string name;
    // 詳細
    [TextArea]
    [SerializeField] string description;
    // タイプ
    [SerializeField] MonsterType type;
    // 威力
    [SerializeField] int power;
    // 命中率
    [SerializeField] int accuracy;
    // PP
    [SerializeField] int pp;

    // カプセル化：他ファイル（Move.cs）から参照するためにプロパティを使う
    public string Name { get => name; }
    public string Description { get => description; }
    public MonsterType Type { get => type; }
    public int Power { get => power; }
    public int Accuracy { get => accuracy; }
    public int PP { get => pp; }
}
