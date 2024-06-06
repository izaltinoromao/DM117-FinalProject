using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    
    public void OnClickButton()
    {
        SceneManager.LoadScene("TerrainScene_01");
    }

    public void OnClickButton2()
    {
        SceneManager.LoadScene("Map_v1");
    }
}
