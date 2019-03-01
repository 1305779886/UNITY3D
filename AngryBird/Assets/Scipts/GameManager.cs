using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Bird> birds;
    public List<Pig> pig;
    public static GameManager _instance;
    private Vector3 originPos;//初始的位置

    public GameObject win;
    public GameObject lose;
    public GameObject[] starts;

    private void Awake()
    {
        _instance = this;
        if (birds.Count > 0)
        {
            originPos = birds[0].transform.position;
        }
        originPos = birds[0].transform.position;
    }
    private void Start()
    {
        Initialized();
    }
    /// <summary>
    /// 初始化小鸟
    /// </summary>
    private void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0)//第一只小小鸟
            {
                birds[i].transform.position = originPos;
                birds[i].enabled = true;
                birds[i].sp.enabled = true;
            }
            else
            {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
            }
        }
    }
    /// <summary>
    /// 判断游戏逻辑
    /// </summary>
    public void NextBird()
    {
        if (pig.Count > 0)
        {
            if (birds.Count > 0)
            {
                //启动下一只小鸟
                Initialized();
            }
            else
            {
                //GG
                lose.SetActive(true);
            }
        }
        else
        {
            //赢了
            win.SetActive(true);
        }
    }
    public void ShowStars()
    {
        StartCoroutine("Show");
    }
    IEnumerator Show()
    {
        for(int i = 0; i < birds.Count +1; i++)
        {
            yield return new WaitForSeconds(0.2f);
            starts[i].SetActive(true);
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene(2);
    }
    public void Home()
    {
        SceneManager.LoadScene(1);
    }
}
