using UnityEngine;
using TMPro;            // Texto no canvas
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;   // Manipular elementos de UI

public class LevelController : MonoBehaviour
{
    public static LevelController levelController;  // 

    public TMP_Text livesText;      // 

    public float startWait;         // Tempo para inicio dos spwans
    private bool gameOver = false;  // Sinaliza se jogo acabou
    private int enemyCount = 1;     // 
    public int enemyCountMax = 10;  // Limita qts de inimigos
    public float spawnWaitMin;      // Limita o tempo minimo para spawn
    public float waveWait;          // Tempo para proxima onde de spawn
    public float waveWaitMin;       // Tempo minimo para onda de spawn

    public GameObject[] enemies;    // Prefab de todos enemies
    public Boundary boundary;       // Classe publia criada no script do player
    public Vector2 spawnWait;       // Tempo depois de spwanar enemy

    void Start()
    {
        levelController = this;
        StartCoroutine(SpawnWaves());   // Executa IEnumerator
    }

    
    void Update()
    {
        
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);  // Pera um pouco para iniciar a criação de inimigos  
        while(!gameOver)        // Loop enquanto não for fim do jogo ele roda
        {
            for(int i = 0; i < enemyCount; i++)
            {
                GameObject enemy = enemies[Random.Range(0, enemies.Length)];    // Sorteia um inimigo
                Vector3 spawnPosition = new Vector3(Random.Range(boundary.xMin, boundary.xMax), boundary.yMin, 0);  // Sorteia posição onde enemy vai ser instanciado
                Instantiate(enemy, spawnPosition, Quaternion.identity);     // Estancia inimigo na posição da tela
                yield return new WaitForSeconds(Random.Range(spawnWait.x, spawnWait.y));    // Tempo de espera 
            }
            enemyCount++;   // Contagem de enemy
            if(enemyCount >= enemyCountMax)     // 
            {
                enemyCount = enemyCountMax;     // 
            }
            spawnWait.x -= 0.1f;    // Deixa o tempo de spawn mais rapido, cria dificuldade
            spawnWait.y -= 0.1f;    // Deixa o tempo de spawn mais rapido, cria dificuldade
            
            if(spawnWait.x <= spawnWaitMin)
            {
                spawnWait.x = spawnWaitMin;     // Limita tempo
                spawnWait.y = spawnWaitMin;     // Limita tempo
            }
            yield return new WaitForSeconds(waveWait);  // Tempo para proxima onda de spawn
            waveWait -= 0.1f;   // Deixa mais rapido a proxima onda de spawn
            if(waveWait <= waveWaitMin)     // Verifica se ja chegou no menor valor possivel
            {
                waveWait = waveWaitMin;     // Limita no menor valor
            }
        }
    }

    public void SetLivesText(int lives)     // Atualiza qts vidas no UI
    {
        livesText.text = lives.ToString();  // 
    }
}
