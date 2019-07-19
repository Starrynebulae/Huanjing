using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormCreate : MonoBehaviour
{
    public Vector3 startCreatePos;//平台初始创建位置
    public enum PlatFormGroupType
    {
        Grass,
        Winter
    }

    private int platFormCreateCount;//平台创建数量
    private ManageVars Vars;
    private Vector3 platFormCreatePos;//平台创建位置
    private bool isLeft=false;//平台是否向左创建
    private Sprite selectPlatformSprite;//选中的平台图
    private PlatFormGroupType platFormGroupType;//组合平台的类型
    private bool spikeIsLeft = false;//钉子平台的方向
    private Vector3 afterSpikePos;
    private int afterSpikePlatformCount;
    private bool isSpikeCreate;

    private void Awake()
    {
        EventCenter.AddListener(EventDefine.DecidePath, DecidePath);
        Vars = ManageVars.GetManageVars();
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventDefine.DecidePath, DecidePath);
    }

    private void Start()
    {
        PlatFormRandomTheme();
        platFormCreatePos = startCreatePos;
        
        for(int i = 0; i < 5; i++)
        {
            platFormCreateCount = 5;
            DecidePath();
        }

        ///生成人物
        GameObject go = Instantiate(Vars.characterPre);
        go.transform.position = new Vector3(0, -1.8f, 0);
    }
    private void DecidePath()//确定创建路径
    {
        if (isSpikeCreate)
        {
            AfterCreateSpike();
            return;
        }
        if (platFormCreateCount >0)
        {
            platFormCreateCount--;
            CreatePlatForm();
        }
        else
        {
            isLeft = !isLeft;
            platFormCreateCount = Random.Range(1, 4);
            CreatePlatForm();
        }
    }
    private void CreatePlatForm()//创建平台
    {
        int ranObstacleDir = Random.Range(0,2);
        if (platFormCreateCount >=1)
        {
            CreateNomalPlatform(ranObstacleDir);///生成单个平台
        }
        else if (platFormCreateCount == 0)
        {
            int ran = Random.Range(0, 3);
            if (ran == 0)///生成通用组合平台
            {
                CreateComPlatform(ranObstacleDir);
            }
            else if (ran == 1)///生成主题组合平台
            {
                switch (platFormGroupType)
                {
                    case PlatFormGroupType.Winter:
                        CreateWinterPlatform(ranObstacleDir);
                        break;
                    case PlatFormGroupType.Grass:
                        CreateGrassPlatform(ranObstacleDir);
                        break;
                    default:
                        break;
                }
            }
            else///生成钉子组合平台
            {
                int value = -1;
                if (isLeft)
                {
                    value = 0;//向右生成钉子
                }
                else
                {
                    value = 1;//向左生成钉子
                }
                afterSpikePlatformCount = 4;
                CreateSpikePlatform(value);
                isSpikeCreate = true;
                if (spikeIsLeft)
                {
                    afterSpikePos = new Vector3(platFormCreatePos.x - 1.65f, platFormCreatePos.y + Vars.nextYpos, 0);
                }
                else
                {
                    afterSpikePos = new Vector3(platFormCreatePos.x + 1.65f, platFormCreatePos.y + Vars.nextYpos, 0);
                }
            }
        }
        if (isLeft)
        {
            platFormCreatePos = new Vector3(platFormCreatePos.x - Vars.nextXpos, platFormCreatePos.y + Vars.nextYpos,0);
        }
        else
        {
            platFormCreatePos = new Vector3(platFormCreatePos.x + Vars.nextXpos, platFormCreatePos.y + Vars.nextYpos,0);
        }
    }

    private void PlatFormRandomTheme()//随机平台主题
    {
        int ran = Random.Range(0, Vars.platformTheme.Count);
        selectPlatformSprite = Vars.platformTheme[ran];
        if (ran == 2)
        {
            platFormGroupType = PlatFormGroupType.Winter;
        }
        else
        {
            platFormGroupType = PlatFormGroupType.Grass;
        }
    }
    /// <summary>
    ///生成普通平台
    /// </summary>
    private void CreateNomalPlatform(int ranObstacleDir)
    {
        GameObject go = ObjectPool.Instance.GetnomalPlatForm(); //实例化平台对象
        go.transform.position = platFormCreatePos;
        go.GetComponent<PlatFromScript>().Init(selectPlatformSprite, ranObstacleDir);//获取被选择的平台图
        go.SetActive(true);
    }

    /// <summary>
    /// 生成通用组合平台
    /// </summary>
    private void CreateComPlatform(int ranObstacleDir)
    {
        GameObject go = ObjectPool.Instance.GetcomPlatFormGroup();
        go.transform.position = platFormCreatePos;
        go.GetComponent<PlatFromScript>().Init(selectPlatformSprite, ranObstacleDir);
        go.SetActive(true);
    }
    /// <summary>
    /// 生成草地组合平台
    /// </summary>
    private void CreateGrassPlatform(int ranObstacleDir)
    {
        GameObject go = ObjectPool.Instance.GetgrassPlatFormGroup();
        go.transform.position = platFormCreatePos;
        go.GetComponent<PlatFromScript>().Init(selectPlatformSprite, ranObstacleDir);
        go.SetActive(true);
    }
    /// <summary>
    /// 生成冬季组合平台
    /// </summary>
    private void CreateWinterPlatform(int ranObstacleDir)
    {
        GameObject go = ObjectPool.Instance.GetwinterPlatFormGroup();
        go.transform.position = platFormCreatePos;
        go.GetComponent<PlatFromScript>().Init(selectPlatformSprite, ranObstacleDir);
        go.SetActive(true);
    }
   
    /// <summary>
    /// 生成钉子平台
    /// </summary> 
    private void CreateSpikePlatform(int dir)
    {
        GameObject temp;
        if (dir ==0)
        {
            spikeIsLeft = false;
            temp = ObjectPool.Instance.GetspikePlatFormRight();
        }
        else
        {
            spikeIsLeft = true;
            temp = ObjectPool.Instance.GetspikePlatFormLeft();
        }
        temp.transform.position = platFormCreatePos;
        temp.GetComponent<PlatFromScript>().Init(selectPlatformSprite, dir);
        temp.SetActive(true);
    }
    /// <summary>
    /// 在钉子平台旁边接着生成普通平台
    /// 钉子方向和主方向同时生成平台
    /// </summary>
    private void AfterCreateSpike()
    {
        if (afterSpikePlatformCount > 0)
        {
            afterSpikePlatformCount--;
            for(int i = 0; i < 2; i++)
            {
                GameObject temp = ObjectPool.Instance.GetnomalPlatForm();
                if (i == 0)//往原先路线生成平台
                {
                    temp.transform.position = platFormCreatePos;
                    if (spikeIsLeft)//钉子在左，平台往右
                    {
                        platFormCreatePos = new Vector3(platFormCreatePos.x + Vars.nextXpos, platFormCreatePos.y + Vars.nextYpos, 0);
                    }
                    else
                    {
                        platFormCreatePos = new Vector3(platFormCreatePos.x - Vars.nextXpos, platFormCreatePos.y + Vars.nextYpos, 0);
                    }
                }
                else//往钉子方向生成平台
                {
                    temp.transform.position = afterSpikePos;
                    if (spikeIsLeft)
                    {
                        afterSpikePos = new Vector3(afterSpikePos.x - Vars.nextXpos, afterSpikePos.y + Vars.nextYpos, 0);
                    }
                    else
                    {
                        afterSpikePos = new Vector3(afterSpikePos.x + Vars.nextXpos, afterSpikePos.y + Vars.nextYpos, 0);
                    }
                }
                temp.GetComponent<PlatFromScript>().Init(selectPlatformSprite, 1);
                temp.SetActive(true);
            }
        }
        else
        {
            isSpikeCreate = false;
            DecidePath();
        }
    }
}