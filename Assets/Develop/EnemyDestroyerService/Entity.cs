using UnityEngine;

public class Entity : MonoBehaviour
{
    public bool IsDead { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            Kill();
    }

    public void Kill()
    {
        if (IsDead == true)
            return;

        IsDead = true;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
