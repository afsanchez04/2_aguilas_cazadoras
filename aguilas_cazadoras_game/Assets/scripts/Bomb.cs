using UnityEngine;
using TMPro;

public class Bomb : MonoBehaviour
{
    // tiempo de la bomba
    public float timer = 15f;

    // jugador que tiene la bomba
    public GameObject currentHolder;

    // texto del contador en pantalla
    public TextMeshProUGUI timerText;

    void Update()
    {
        // seguir al jugador que tiene la bomba
        if (currentHolder != null)
        {
            transform.position = currentHolder.transform.position + Vector3.up * 2f;
        }

        // disminuir tiempo
        timer -= Time.deltaTime;

        // actualizar texto en pantalla
        timerText.text = "Time: " + Mathf.Ceil(timer).ToString();

        // explotar cuando llegue a 0
        if (timer <= 0)
        {
            Explode();
        }
    }

    // pasar bomba a otro jugador
    public void PassBomb(GameObject newHolder)
    {
        currentHolder = newHolder;
    }

    void Explode()
    {
        Debug.Log("BOOM! perdió: " + currentHolder.name);
        Destroy(gameObject);
    }
}