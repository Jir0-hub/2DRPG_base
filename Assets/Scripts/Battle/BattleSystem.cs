using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    Start,
    PlayerAction, // 行動選択
    PlayerMove, // 技選択
    EnemyMove,
    Busy,
}

public class BattleSystem : MonoBehaviour
{
    // 戦かうモンスターの設定
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] BattleDialogBox dialogBox;

    BattleState state;
    int currentAction; // 0:Fight, 1:Run
    int currentMove; // 0:左上, 1:右上, 3:左下, 4:右下

    // ・メッセージが出て一秒後にActionSelectorを表示する
    // ・Zボタンを押すとMoveSelectorとMoveDetailsを表示する

    private void Start()
    {
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        state = BattleState.Start;
        
        // モンスターの生成
        playerUnit.Setup();
        enemyUnit.Setup();

        // HUDの描画
        playerHud.SetData(playerUnit.Monster);
        enemyHud.SetData(enemyUnit.Monster);

        // モンスターの技の反映
        dialogBox.SetMoveNames(playerUnit.Monster.Moves);

        yield return StartCoroutine(dialogBox.TypeDialog($"野生の {enemyUnit.Monster.Base.Name} があらわれた."));
        yield return new WaitForSeconds(1);
        PlayerAction();
    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        dialogBox.EnableActionSelector(true);
        StartCoroutine(dialogBox.TypeDialog("どうする？"));
    }

    void PlayerMove()
    {
        state = BattleState.PlayerMove;
        dialogBox.EnableDialogText(false);
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableMoveSelector(true);
    }
    
    private void Update()
    {
        if (state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
        else if (state == BattleState.PlayerMove)
        {
            HandleMoveSelection();
        }
    }

    // PlayerActionでの行動を処理する
    void HandleActionSelection()
    {
        // 下を入力するとRun, 上を入力するとFightになる
        // 0:Fight, 1:Run
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < 1)
            {
                currentAction++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 0)
            {
                currentAction--;
            }
        }

        // 色をつけて現在の選択Actionを分かるようにする
        dialogBox.UpdateActionSelection(currentAction);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Fightを選択
            if (currentAction == 0)
            {
                PlayerMove();
            }
        }
    }

        void HandleMoveSelection()
    {
        // 0:左上, 1:右上, 3:左下, 4:右下
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentMove < playerUnit.Monster.Moves.Count - 1)
            {
                currentMove++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentMove > 0)
            {
                currentMove--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentMove < playerUnit.Monster.Moves.Count - 2)
            {
                currentMove += 2;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentMove > 1)
            {
                currentMove -= 2;
            }
        }
        // 色をつけて現在の選択Moveを分かるようにする
        dialogBox.UpdateMoveSelection(currentMove, playerUnit.Monster.Moves[currentMove]);
    }
}
