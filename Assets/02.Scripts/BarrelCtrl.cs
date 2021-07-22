using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    private int hitCount = 0;
    // 배열 타입 (Array Type)
    public int[] monsterPower;
    public string[] monsterName;
    public float[] monsterDamage;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))  // O
        {
            if (++hitCount == 3)
            {
                ExpBarrel();
            }
        }
    }

    void ExpBarrel()
    {
        // Rigidbody 컴포넌트를 추가
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        // 수직의 힘을 가함
        rb.AddForce(Vector3.up * 2000.0f);
        // 3초후에 베럴을 삭제
        Destroy(this.gameObject, 3.0f);
    }
}
