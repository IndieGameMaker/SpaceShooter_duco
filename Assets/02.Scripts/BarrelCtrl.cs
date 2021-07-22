using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    private int hitCount = 0;
    // 배열 타입 (Array Type)
    public int[] monsterPower;
    // monsterPower[2] --> 300
    public string[] monsterName;
    // monsterName[1] --> "Goblin"
    public float[] monsterDamage;

    // 텍스처(Texture)를 저장하기 위한 배열을 선언
    public Texture[] textures;
    // textures[0], textures[1], .... textures[99]

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
