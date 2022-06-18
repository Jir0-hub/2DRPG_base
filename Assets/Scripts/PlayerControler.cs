using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Playerの１マス移動
    [SerializeField] float moveSpeed;

    bool isMoving;
    Vector2 input;
    void Update()
    {
        // 移動中は入力を受け付けたくない
        if (!isMoving)
        {
            // キーボードの入力を取得
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // 入力があったら
            if (input != Vector2.zero)
            {
                // 目的地に入力分を追加
                Vector2 targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;
                // コルーチンを使って徐々に目的地に近づける
                StartCoroutine(Move(targetPos));
            }
        }
    }
    
    IEnumerator Move(Vector3 targetPos)
    {
        // 移動中のフラグを立てる
        isMoving = true;

        // targetPosと現在のpositionに差がある間は、MoveTowardsでtargetPosに近づく
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            // targetPosに近づける
            transform.position = Vector3.MoveTowards(
                transform.position, // 現在の場所
                targetPos, // 目的地
                moveSpeed*Time.deltaTime
                );
            yield return null;
        }

        transform.position = targetPos;

        // 移動中のフラグを下す
        isMoving = false;
    }
}

