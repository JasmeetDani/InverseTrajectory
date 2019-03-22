using UnityEngine;

public class BouncePointController : MonoBehaviour
{
    public Vector3 Pos
    {
        get { return transform.position; }

        private set { }
    }


    public void UpdatePosition(Vector2 pos)
    {
        transform.position = new Vector3(pos.x, 0.1f, pos.y);
    }


    public void MoveLeft(float delta)
    {
        transform.position = new Vector3(transform.position.x - delta, 0.1f, transform.position.z);
    }

    public void MoveRight(float delta)
    {
        transform.position = new Vector3(transform.position.x + delta, 0.1f, transform.position.z);
    }

    public void MoveForward(float delta)
    {
        transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z + delta);
    }

    public void MoveBackward(float delta)
    {
        transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z - delta);
    }
}