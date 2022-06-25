using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleDialogBox : MonoBehaviour
{
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
}
