using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;       // Prefab do tiro
    public float fireRate;          // 
    public Transform[] shotSpawns;  // Posição de onde vai sair os tiros

    void Start()
    {
        InvokeRepeating("Fire", fireRate, fireRate);    // Chama "Fire" após x segundos e repete a cada y segundos

    }

    void Update()
    {
        
    }

    void Fire()     // Tiros
    {
        for(int i = 0; i < shotSpawns.Length; i++)  // Loop roda a quantidade de posição de tiros
        {
            Instantiate(bullet, shotSpawns[i].position, shotSpawns[i].rotation);    // Instancia tiro
        }
    }
}
