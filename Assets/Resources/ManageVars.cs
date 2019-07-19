using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName ="CreateManageVarsContainer")]
public class ManageVars : ScriptableObject
{
    public static ManageVars GetManageVars()
    {
        return Resources.Load<ManageVars>("ManageContainer");
    }
    public List<Sprite> bgTheme = new List<Sprite>();

    public List<Sprite> platformTheme = new List<Sprite>();

    public float nextXpos = 0.554f, nextYpos = 0.645f;

    public GameObject nomalPlatFormPre;

    public GameObject characterPre;

    public GameObject spikePlatFormRight;

    public GameObject spikePlatFormLeft;

    public List<GameObject> comPlatformGroup = new List<GameObject>();

    public List<GameObject> grassPlatformGroup = new List<GameObject>();

    public List<GameObject> winterPlatformGroup = new List<GameObject>();
}
