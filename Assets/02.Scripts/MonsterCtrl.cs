using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    // 거리계산을 위한 주인공의 위치, 몬스터의 위치
    // 주인공 캐릭터의 Transform 저장할 변수 선언
    [SerializeField] private Transform playerTr;
    [SerializeField] private Transform monsterTr;

    void Start()
    {
        // PLAYER 태그로 지정된 게임오브젝트를 추출해서 playerObject에 저장
        GameObject playerObject = GameObject.FindGameObjectWithTag("PLAYER");

        // playerObject의 Transform 컴포넌트를 추출해서 playerTr 변수에 저장
        playerTr = playerObject.GetComponent<Transform>();

        //playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
