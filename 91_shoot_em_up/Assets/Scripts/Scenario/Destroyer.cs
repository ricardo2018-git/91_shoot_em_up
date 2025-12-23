using UnityEngine;

public class Destroyer : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)  // Quando sair da colisão dele. Obs ele toma a tela inteira do jogo
    {
        Destroy(other.gameObject);  // Detroi obj
    }
}
