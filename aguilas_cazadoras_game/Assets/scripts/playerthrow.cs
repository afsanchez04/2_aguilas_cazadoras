using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public Bomb bomb;

    public GameObject luigi;
    public GameObject peach;
    public GameObject yoshi;

    void Update()
    {
        // verificar si la bomba existe
        if (bomb == null) return;

        // solo si el jugador tiene la bomba
        if (bomb.currentHolder != gameObject) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bomb.PassBomb(luigi);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bomb.PassBomb(peach);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bomb.PassBomb(yoshi);
        }
    }
}