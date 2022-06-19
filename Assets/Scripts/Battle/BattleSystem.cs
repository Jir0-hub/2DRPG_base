using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    // 戦かうモンスターの設定
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;

    private void Start()
    {
        SetupBattle();
    }

    void SetupBattle()
    {
        playerUnit.Setup();
        enemyUnit.Setup();

        playerHud.SetData(playerUnit.Monster);
        enemyHud.SetData(enemyUnit.Monster);
    }
}
