using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateMin, rotateMax;  // Vai receber valore minimo e maximo da rotação
    private float rotateSpeed;          // Valor da todação

    void Start()
    {
        rotateSpeed = Random.Range(rotateMin, rotateMax);   // Gera um valor aleatório enter min e max
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);   // Faz rodar no eixo z   
    }
}
