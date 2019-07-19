using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainpanel : MonoBehaviour
{
    private Button btn_start;
    private Button btn_shop;
    private Button btn_rank;
    private Button btn_voice;

    private void Awake()
    {
        btn_start = transform.Find("btn_start").GetComponent<Button>();
        btn_start.onClick.AddListener(StartButtonOnclick);
        btn_shop = transform.Find("btns/btn_shop").GetComponent<Button>();
        btn_shop.onClick.AddListener(ShopButtonOnclick);
        btn_rank = transform.Find("btns/btn_rank").GetComponent<Button>();
        btn_rank.onClick.AddListener(RankButtonOnclick);
        btn_voice = transform.Find("btns/btn_voice").GetComponent<Button>();
        btn_voice.onClick.AddListener(VoiceButtonOnclick);
    }
    private void StartButtonOnclick()
    {
        GameManager.Instance.IsGameStarted = true;
        EventCenter.Broadcast(EventDefine.ShowGamePanel);
        gameObject.SetActive(false);
    }
    private void ShopButtonOnclick()
    {

    }
    private void RankButtonOnclick()
    {

    }
    private void VoiceButtonOnclick()
    {

    }
}
