using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float h;    // 실수값을 저장할 수 있는 변수 선언
    private float v;

    // 접근제한자 
    // public / private
    // 전역변수
    public float moveSpeed = 8.0f;
    private Animation anim;

    void Start()
    {
        anim = this.gameObject.GetComponent<Animation>();
        anim.Play("Idle");
    }

    // 화면을 랜더링하는 주기
    void Update()
    {
        h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
        Debug.Log("h=" + h);
        Debug.Log("v=" + v);

        /*
        정규화 벡터(Normalized Vector) , 단위벡터(Unit Vector)
        : 벡터의 크기가 1인 벡터를 의미한다.

        Vector3.forward = Vector3(0, 0, 1)
        Vector3.up      = Vector3(0, 1, 0)
        Vector3.right   = Vector3(1, 0, 0)

        Vector3.one     = Vector3(1, 1, 1)
        Vector3.zero    = Vector3(0, 0, 0)        
        */

        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);

        PlayerAnim();
    }

    void PlayerAnim()
    {
        if (v >= 0.1f) //전진
        {
            anim.CrossFade("RunF", 0.3f);
        }
        else if (v <= -0.1f) //후진
        {
            anim.CrossFade("RunB", 0.3f);
        }
        else if (h >= 0.1f) //오른쪽 이동
        {
            anim.CrossFade("RunR", 0.3f);
        }
        else if (h <= -0.1f) //왼쪽 이동
        {
            anim.CrossFade("RunL", 0.3f);
        }
        else
        {
            anim.CrossFade("Idle", 0.3f);
        }
    }
}
