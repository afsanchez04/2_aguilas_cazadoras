using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public Bomb bomb;

    public GameObject luigi;
    public GameObject peach;
    public GameObject yoshi;

    void Update()
    {
        // Check if the pump exists
        if (bomb == null) return;

        // only if the player has the bomb
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
