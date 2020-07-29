using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovementController : MonoBehaviour
{
    public float alpha;
    public float beta;
    public float speed;
    public bool isHorizontal;
    


    private void Update()
    {
        if (isHorizontal)
        {
            horizontalMove();
        }else if (isHorizontal == false)
        {
            verticalMove();
        }
    }

    private void horizontalMove()
    {
        Vector3 pos = transform.localPosition;
        pos.x = Mathf.PingPong(alpha, beta);
        alpha += speed;
        transform.localPosition = pos;
    }

    private void verticalMove()
    {
        Vector3 pos = transform.localPosition;
        pos.y = Mathf.PingPong(alpha, beta);
        alpha += speed;
        transform.localPosition = pos;
    }
}
