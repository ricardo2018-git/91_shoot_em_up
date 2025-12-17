using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public ItemEffect effect;       // Item

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();   // Cria e acessa script player
        if(player != null)  // Verifica se é o player mesmo
        {
            player.SetItemEffect(effect);   // Acessa metodo q arma player e passa o efeito
            Destroy(gameObject);            // Destroi obj da cena
        }
    }
}
