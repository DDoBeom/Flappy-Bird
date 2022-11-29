using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;     //리지드 바디 컴포넌트를 담아둘 변수

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();       //같은 오브젝트 내에 있는 리지드 바디 컴포넌트를 가져와 변수에 담음

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gm.isGameStart || GameManager.gm.isGameOver)
        {
            if (rb.velocity.x != 0)         //리지드 바디의 속도 변수 벨로시티의 x축 값이 0이 아니라면
                MoveBg(0);                  //MoveBg함수 호출!       
        }
        else
        {
            if (rb.velocity.x == 0)         //리지드 바디의 속도 변수 벨로시티의 x축 값이 0이라면
                MoveBg(-1.5f);               //MoveBg함수 호출!
        }
    }

    void MoveBg(float speed)
    {
        rb.velocity = new Vector2(speed,0);     //리지드 바디 변수 중 속도에 속도값을 대입
    }


}
