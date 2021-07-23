using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    public enum State
    {
        IDLE,   // 휴면상태
        TRACE,  // 추적상태
        ATTACK, // 공격상태
        DIE     // 사망상태
    }

    // 몬스터의 상태를 저장하는 변수
    public State state = State.IDLE;

    // 거리계산을 위한 주인공의 위치, 몬스터의 위치
    // 주인공 캐릭터의 Transform 저장할 변수 선언
    [SerializeField] private Transform playerTr;
    [SerializeField] private Transform monsterTr;

    // 공격 사정거리
    public float attackDist = 2.0f;
    // 추적 사정거리
    public float traceDist = 10.0f;

    void Start()
    {
        // PLAYER 태그로 지정된 게임오브젝트를 추출해서 playerObject에 저장
        GameObject playerObject = GameObject.FindGameObjectWithTag("PLAYER");

        // playerObject의 Transform 컴포넌트를 추출해서 playerTr 변수에 저장
        playerTr = playerObject.GetComponent<Transform>();

        monsterTr = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // 주인공과 몬스터간의 거리를 계산해서 변수 저장
        float distance = Vector3.Distance(playerTr.position, monsterTr.position);

        //1) 거리 <= 공격 사정거리 이면 몬스트의 상태를 ATTACK으로 변경
        if (distance <= attackDist)
        {
            state = State.ATTACK;
        } //2) 거리 <= 추적 사정거리 이면 몬스트의 상태를 TRACE으로 변경
        else if (distance <= traceDist)
        {
            state = State.TRACE;
        } //3) 몬스트의 상태를 IDEL으로 변경
        else
        {
            state = State.IDLE;
        }


    }
}
