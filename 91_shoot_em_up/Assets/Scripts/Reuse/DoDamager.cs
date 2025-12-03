using UnityEngine;

public class DoDamager : MonoBehaviour
{
    public int damage = 1;  // Dano que vai ser aplicado

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterLife character = other.GetComponent<CharacterLife>();  // Outra forma de acessa script do obj que se colidiu
        if(character != null)   // Verifica se NÃO é null
        {
            character.TakeDamage(damage);   // Acessa função que aplica dano do game obj
            Destroy(gameObject);            // Destroi game object
        }
    }
}
