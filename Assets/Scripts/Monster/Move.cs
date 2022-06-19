using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    // Monsterが実際に使うときのわざデータ

    public MoveBase Base { get; set; }
    public int PP {get; set; }

    // コンストラクター：生成時の初期設定
    public Move(MoveBase pBase)
    {
        Base = pBase;
        PP = pBase.PP;
    }
}