using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    private int hitCount = 0;

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
