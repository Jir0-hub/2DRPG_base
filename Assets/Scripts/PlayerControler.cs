using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Playerの移動
    // 

    [SerializeField] float moveSpeed;

    bool isMoving;
    Vector2 input;

    Animator animator;

    // 壁判定のレイヤー
    [SerializeField] LayerMask solidObjects;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 移動中は入力を受け付けたくない
        if (!isMoving)
        {
            // キーボードの入力を取得
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // 斜め移動の禁止
            if (input.x != 0)
            {
                input.y = 0;
            }

            // 入力があったら
            if (input != Vector2.zero)
            {
                // animatorの変数に代入して向きを変える
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                // 目的地に入力分を追加
                Vector2 targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;
                // 移動可否判定
                if (IsWalkable(targetPos))
                {
                    // コルーチンを使って徐々に目的地に近づける
                    StartCoroutine(Move(targetPos));
                }
                
            }
        }
        // 移動中のフラグで、アニメーションを変更：true→walk
        animator.SetBool("isMoving", isMoving);
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

        // 移動中のフラグをおろす
        isMoving = false;
    }

    // 目的地の移動可否判定
    bool IsWalkable(Vector2 targetPos)
    {
        // 目的地に半径0.2fの円のRayをとはして、solidObjectsにぶつかったらtrue
        return !Physics2D.OverlapCircle(targetPos, 0.2f, solidObjects);
    }
}

