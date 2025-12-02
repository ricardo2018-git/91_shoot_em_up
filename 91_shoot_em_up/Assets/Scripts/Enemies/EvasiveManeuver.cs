using System.Collections;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour
{
    public float dodge;
    public float speed;
    public Boundary boundary;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;

    private Rigidbody2D rb;
    private float target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Evade());
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards(rb.linearVelocity.x, target, speed);  // 
        rb.linearVelocity = new Vector2(newManeuver, rb.linearVelocity.y);          // 
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));  // Limita movimentação do player pela tela nos eixos x e y
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));    // Espera um tempo
        while (true)
        {
            target = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);     // 
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));  // 
            target = 0; // Para
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));  // 
        }
    }
}
