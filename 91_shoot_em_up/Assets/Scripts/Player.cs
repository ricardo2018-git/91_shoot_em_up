using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;   // Interagir com UI

[System.Serializable]   // Para conseguir editar pelo editor da unity
public class Boundary   // São os limites que player pode ir pela tela
{
    public float xMin, xMax;    // Limite minimo e maximo horizontal
    public float yMin, yMax;    // Limite minimo e maximo vertical
}

public class Player : MonoBehaviour
{
    public Joystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;

    public Boundary boundary;   // Classe que foi criada a cima

    public GameObject bullet;   // Tiro do player

    public int fireLevel = 1;   // Controla lovel dos tiros

    // Controla quantidade de tiros
    public float fireRate;      // Tempo fixo para liberar o proximo tiro
    private float nextFire;     // Vai receber tempo atual do jogo + o tempo fixo

    // UI botão de tiro
    public Button shootButton;      // referência ao botão
    public GameObject bulletPrefab; // prefab da bala
    public Transform[] shotSpawns;  // ponto de saída da bala

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootButton.onClick.AddListener(Shoot); // Vincula a função Shoot ao clique do botão
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(movementJoystick.Direction.y != 0)   // Verifica se joystick esta sendo precionado para algum eixo
        {
            rb.linearVelocity = new Vector2(movementJoystick.Direction.x * playerSpeed, movementJoystick.Direction.y * playerSpeed);    // Faz player se mover
        }
        else
        {
            rb.linearVelocity = Vector2.zero;   // Para player
        }

        rb.position = new Vector2(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));  // Limita movimentação do player pela tela nos eixos x e y

    }

    void Shoot()    // Efetua o tiro
    {
        if(Time.time > nextFire)    // Verifica se passou o tempo para liberar o proximo tiro
        {
            if(fireLevel >= 1)  // Verifica se esta no level 1
            {
                Instantiate(bulletPrefab, shotSpawns[0].position, shotSpawns[0].rotation);  // Instancia a bala no ponto de tiro
            }
            if(fireLevel >= 2) // Verifica se esta no level 2
            {
                Instantiate(bulletPrefab, shotSpawns[1].position, shotSpawns[1].rotation);  // Instancia a bala no ponto de tiro
                Instantiate(bulletPrefab, shotSpawns[2].position, shotSpawns[2].rotation);  // Instancia a bala no ponto de tiro
            }
            if(fireLevel >= 3)
            {
                Instantiate(bulletPrefab, shotSpawns[3].position, shotSpawns[3].rotation);  // Instancia a bala no ponto de tiro
                Instantiate(bulletPrefab, shotSpawns[4].position, shotSpawns[4].rotation);  // Instancia a bala no ponto de tiro
            }
            nextFire = Time.time + fireRate;                                            // Atualiza o tempo do proximo tiro
        }
    }

}
