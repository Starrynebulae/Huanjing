using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    private bool isMoveLeft = false;
    private Vector3 nextPlatformLeft, nextPlatformRight;
    private ManageVars Vars;
    private bool isJumping = false;

    private void Awake()
    {
        Vars = ManageVars.GetManageVars();
    }
    private void Update()
    {
        if (GameManager.Instance.IsGameStarted == false || GameManager.Instance.IsGameOver)
            return;
       
        if (Input.GetMouseButtonDown(0)&&isJumping==false)
        {
            EventCenter.Broadcast(EventDefine.DecidePath);
            isJumping = true;
            Vector3 mousePos = Input.mousePosition;
            if (mousePos.x <= Screen.width / 2)
            {
                isMoveLeft = true;
            }
            else
            {
                isMoveLeft = false;
            }
            Jump();
        }
    }
    private void Jump()
    {
        if (isMoveLeft)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.DOMoveX(nextPlatformLeft.x, 0.2f);
            transform.DOMoveY(nextPlatformLeft.y+0.8f , 0.15f);
        }
        else
        {
            transform.DOMoveX(nextPlatformRight.x, 0.2f);
            transform.DOMoveY(nextPlatformRight.y+0.8f , 0.15f);
            transform.localScale = Vector3.one;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "platform")
        {
            isJumping = false;
            Vector3 currentPlatformPos = collision.gameObject.transform.position;
            nextPlatformLeft = new Vector3(currentPlatformPos.x - Vars.nextXpos, currentPlatformPos.y + Vars.nextYpos);
            nextPlatformRight = new Vector3(currentPlatformPos.x + Vars.nextXpos, currentPlatformPos.y + Vars.nextYpos);
        }
    }
}
