using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamepanel : MonoBehaviour
{
    private Button btn_pause;
    private Button btn_start;
    private Text txt_score;
    private Text txt_diamondscore;
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        EventCenter.AddListener(EventDefine.ShowGamePanel, Show);
        btn_pause = transform.Find("btns/btn_pause").GetComponent<Button>();
        btn_pause.onClick.AddListener(PauseButtonOnclick);
        btn_start = transform.Find("btns/btn_start").GetComponent<Button>();
        btn_start.onClick.AddListener(StartButtonOnclick);
        txt_score = transform.Find("txt_score").GetComponent<Text>();
        txt_diamondscore = transform.Find("diamond/txt_diamondscore").GetComponent<Text>();
        btn_start.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventDefine.ShowGamePanel, Show);
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void StartButtonOnclick()
    {
        btn_start.gameObject.SetActive(false);
        btn_pause.gameObject.SetActive(true);
    }
    private void PauseButtonOnclick()
    {
        btn_start.gameObject.SetActive(true);
        btn_pause.gameObject.SetActive(false);
    }
}
