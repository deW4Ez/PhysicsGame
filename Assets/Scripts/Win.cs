using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public Image Border;
    public Text text;
    public GameObject ButtonRetry;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Check(bool win)
    {
        if (win)
        {
            text.text = "ОТВЕТ ВЕРНЫЙ!";
            Border.color = new Color32(0, 255, 47, 255);
        }
        else
        {
            text.text = "ПОПРОБУЙ ЕЩЕ РАЗ";
            Border.color = new Color32(231, 35, 12, 255);
            ButtonRetry.SetActive(true);
        }
    }

    public void Retry()
    {
        var currScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currScene.name);
    }
}
