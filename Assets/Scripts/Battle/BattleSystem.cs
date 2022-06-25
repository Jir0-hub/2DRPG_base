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
    [SerializeField] BattleDialogBox dialogBox;


    // ・メッセージが出て一秒後にActionSelectorを表示する
    // ・Zボタンを押すとMoveSelectorとMoveDetailsを表示する

    private void Start()
    {
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        playerUnit.Setup();
        enemyUnit.Setup();

        playerHud.SetData(playerUnit.Monster);
        enemyHud.SetData(enemyUnit.Monster);

        yield return StartCoroutine(dialogBox.TypeDialog($"A wild {enemyUnit.Monster.Base.Name} apeared."));
        yield return new WaitForSeconds(1);
        dialogBox.EnableActionSelector(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            dialogBox.EnableDialogText(false);
            dialogBox.EnableActionSelector(false);
            dialogBox.EnableMoveSelector(true);  
        }
    }
}
