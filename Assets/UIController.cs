using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    
    public void OnClickButton()
    {
        SceneManager.LoadScene("TerrainScene_01");
    }
}
