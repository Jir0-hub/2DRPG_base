using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] Color highlightColor;
    // dialogのTextを取得して、変更する
    [SerializeField] int letterPerSecond; //1文字当たりの表示速度
    [SerializeField] Text dialogText;

    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetails;

    [SerializeField] List<Text> actionTexts;
    [SerializeField] List<Text> moveTexts;

    [SerializeField] Text ppText;
    [SerializeField] Text typeText;

    // Textを変更するための関数
    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    // タイプ形式で文字を表示する
    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach (char letter in dialog)
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f/letterPerSecond);
        }
    }

    // UIの表示/非表示

    // dialogTextの表示管理
    public void EnableDialogText(bool enabled)
    {
        dialogText.enabled = enabled;
    }

    // actionSelectorの表示管理
    public void EnableActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }

    // moveSelectorの表示管理
    public void EnableMoveSelector(bool enabled)
    {
        moveSelector.SetActive(enabled);
        moveDetails.SetActive(enabled);
    }

    // 選択中のアクションの色を変える
    public void UpdateActionSelection(int selectAction)
    {
        // selectActionが0の時はactionTexts[0]の色を青。それ以外を黒
        // selectActionが1の時はactionTexts[1]の色を青。それ以外を黒
        for (int i=0; i<actionTexts.Count; i++)
        {
            if (selectAction == i)
            {
                actionTexts[i].color = highlightColor;
            }
            else
            {
                actionTexts[i].color = Color.black;
            }
        }
    }

    // モンスターの技の反映
    public void SetMoveNames(List<Move> moves)
    {
        for (int i=0; i<moveTexts.Count; i++)
        {
            // 覚えている技の数だけ反映
            if (i < moves.Count)
            {
                moveTexts[i].text = moves[i].Base.Name;
            }
            else{
                moveTexts[i].text = ".";
            }
        }
    }
    // 選択中のMoveの色を変える
    public void UpdateMoveSelection(int selectMove, Move move)
    {
        // selectMoveが0の時はmoveTexts[0]の色を青。それ以外を黒
        // selectMoveが1の時はmoveTexts[1]の色を青。それ以外を黒
        for (int i=0; i<moveTexts.Count; i++)
        {
            if (selectMove == i)
            {
                moveTexts[i].color = highlightColor;
            }
            else
            {
                moveTexts[i].color = Color.black;
            }
        }
        ppText.text = $"PP {move.PP}/{move.Base.PP}";
        typeText.text = move.Base.Type.ToString();
    }
}
