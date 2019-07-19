using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    public int initCreateCount=5;
    private ManageVars vars; 

    private List<GameObject> nomalPlatFormList = new List<GameObject>();
    private List<GameObject> comPlatFormList = new List<GameObject>();
    private List<GameObject> grassPlatFormList = new List<GameObject>();
    private List<GameObject> winterPlatFormList = new List<GameObject>();
    private List<GameObject> spikePlatFormListLeft = new List<GameObject>();
    private List<GameObject> spikePlatFormListRight = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
        vars = ManageVars.GetManageVars();
        Init();
    }
    private void Init()
    {
        for (int i = 0; i < initCreateCount; i++)///普通平台
        {
            AddPlatFromList(vars.nomalPlatFormPre,ref nomalPlatFormList);
        }
        for (int i = 0; i < initCreateCount; i++)///通用组合平台
        {
            for(int g = 0; g < vars.comPlatformGroup.Count; g++)
            {
                AddPlatFromList(vars.comPlatformGroup[g], ref comPlatFormList);
            }
        }
        for (int i = 0; i < initCreateCount; i++)///草地组合平台
        {
            for (int g = 0; g < vars.grassPlatformGroup.Count; g++)
            {
                AddPlatFromList(vars.grassPlatformGroup[g], ref grassPlatFormList);
            }
        }
        for (int i = 0; i < initCreateCount; i++)///冬季组合平台
        {
            for (int g = 0; g < vars.winterPlatformGroup.Count; g++)
            {
                AddPlatFromList(vars.winterPlatformGroup[g], ref winterPlatFormList);
            }
        }
        for (int i = 0; i < initCreateCount; i++)///钉子组合平台(左)
        {
            AddPlatFromList(vars.spikePlatFormLeft, ref spikePlatFormListLeft);
        }
        for (int i = 0; i < initCreateCount; i++)///钉子组合平台(右)
        {
            AddPlatFromList(vars.spikePlatFormRight, ref spikePlatFormListRight);
        }
    }
    private GameObject AddPlatFromList(GameObject prefab, ref List<GameObject> addList)
    {
        GameObject go = Instantiate(prefab, transform);
        go.SetActive(false);
        addList.Add(go);
        return go;
    }
    /// <summary>
    /// 获取单个普通平台
    /// </summary>
    public GameObject GetnomalPlatForm()
    {
        for(int i = 0; i < nomalPlatFormList.Count; i++)
        {
            if (nomalPlatFormList[i].activeInHierarchy == false)
            {
                return nomalPlatFormList[i];
            }
        }
        return AddPlatFromList(vars.nomalPlatFormPre, ref nomalPlatFormList);
    }
    /// <summary>
    /// 生成通用组合平台
    /// </summary>
    public GameObject GetcomPlatFormGroup()
    {
        for (int i = 0; i < comPlatFormList.Count; i++)
        {
            if (comPlatFormList[i].activeInHierarchy == false)
            {
                return comPlatFormList[i];
            }
        }
        int ran = Random.Range(0, vars.comPlatformGroup.Count);
        return AddPlatFromList(vars.comPlatformGroup[ran], ref comPlatFormList);
    }
    /// <summary>
    /// 生成草地组合平台
    /// </summary>
    public GameObject GetgrassPlatFormGroup()
    {
        for (int i = 0; i < grassPlatFormList.Count; i++)
        {
            if (grassPlatFormList[i].activeInHierarchy == false)
            {
                return grassPlatFormList[i];
            }
        }
        int ran = Random.Range(0, vars.grassPlatformGroup.Count);
        return AddPlatFromList(vars.grassPlatformGroup[ran], ref grassPlatFormList);
    }
    /// <summary>
    /// 生成冬季组合平台
    /// </summary>
    public GameObject GetwinterPlatFormGroup()
    {
        for (int i = 0; i < winterPlatFormList.Count; i++)
        {
            if (winterPlatFormList[i].activeInHierarchy == false)
            {
                return winterPlatFormList[i];
            }
        }
        int ran = Random.Range(0, vars.winterPlatformGroup.Count);
        return AddPlatFromList(vars.winterPlatformGroup[ran], ref winterPlatFormList);
    }
    /// <summary>
    /// 获取钉子平台左
    /// </summary>
    public GameObject GetspikePlatFormLeft()
    {
        for (int i = 0; i < spikePlatFormListLeft.Count; i++)
        {
            if (spikePlatFormListLeft[i].activeInHierarchy == false)
            {
                return spikePlatFormListLeft[i];
            }
        }
        return AddPlatFromList(vars.spikePlatFormLeft, ref spikePlatFormListLeft);
    }
    /// <summary>
    /// 获取钉子平台右
    /// </summary>
    public GameObject GetspikePlatFormRight()
    {
        for (int i = 0; i < spikePlatFormListRight.Count; i++)
        {
            if (spikePlatFormListRight[i].activeInHierarchy == false)
            {
                return spikePlatFormListRight[i];
            }
        }
        return AddPlatFromList(vars.spikePlatFormRight, ref spikePlatFormListRight);
    }
}
