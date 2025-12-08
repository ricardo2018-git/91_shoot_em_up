using UnityEngine;
using TMPro;            // Texto no canvas
using UnityEngine.UI;   // Manipular elementos de UI

public class LevelController : MonoBehaviour
{
    public static LevelController levelController;  // 

    public TMP_Text livesText;      // 

    void Start()
    {
        levelController = this;
    }

    
    void Update()
    {
        
    }

    public void SetLivesText(int lives)     // Atualiza qts vidas no UI
    {
        livesText.text = lives.ToString();  // 
    }
}
