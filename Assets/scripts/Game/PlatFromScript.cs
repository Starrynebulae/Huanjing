using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFromScript : MonoBehaviour
{
    public SpriteRenderer[] spriteRenderers;
    public GameObject obstacle;
   public void Init(Sprite sprite,int Obstacledir)
    {
        for(int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].sprite = sprite;
        }
        if (Obstacledir==0)//障碍朝右
        {
            if (obstacle != null)
            {
                obstacle.transform.localPosition = new Vector3(-obstacle.transform.localPosition.x, obstacle.transform.localPosition.y,0);
            }    
        }
    }
}
