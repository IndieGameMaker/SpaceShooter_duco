using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float h;    // 실수값을 저장할 수 있는 변수 선언
    private float v;
    private float r;    // 좌위 회전값을 저장할 변수 선언

    // 접근제한자 
    // public / private
    // 전역변수
    public float moveSpeed = 8.0f;
    private Animation anim;

    private float hp = 100.0f;

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
        r = Input.GetAxis("Mouse X");

        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);
        transform.Rotate(Vector3.up * Time.deltaTime * 100.0f * r);

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

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("PUNCH"))
        {
            hp -= 10.0f;
            if (hp <= 0.0f)
            {
                PlayerDie();
            }
        }
    }

    void PlayerDie()
    {

    }


}
