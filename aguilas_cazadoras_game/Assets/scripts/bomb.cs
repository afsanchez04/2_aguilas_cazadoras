using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float timer = 15f; // tiempo de la bomba
    public GameObject currentHolder; // quien tiene la bomba

    void Update()
    {
        // seguir al jugador que tiene la bomba
        if (currentHolder != null)
        {
            transform.position = currentHolder.transform.position + Vector3.up * 2f;
        }

        // contar tiempo
        timer -= Time.deltaTime;

        // explotar
        if (timer <= 0)
        {
            Explode();
        }
    }

    // pasar la bomba a otro jugador
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