using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgtheme : MonoBehaviour
{
    private SpriteRenderer m_SpriteRenderer;
    private ManageVars Vars;
    private void Awake()
    {
        Debug.Log("Awake is called");
        Vars = ManageVars.GetManageVars();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        int RanValue = Random.Range(0, Vars.bgTheme.Count);
        m_SpriteRenderer.sprite = Vars.bgTheme[RanValue];
    }
}
