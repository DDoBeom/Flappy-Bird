using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionBg : MonoBehaviour
{
    BoxCollider2D bc;
    float length;       //백그라운드 길이

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponentInChildren<BoxCollider2D>();       //자식 오브젝트에 있는 박스 콜라이더를 가져와 담음 

        length = bc.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -length)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        Vector2 offset = new Vector2(length * 2f, 0);

        transform.position = (Vector2)transform.position + offset;
    }
}
