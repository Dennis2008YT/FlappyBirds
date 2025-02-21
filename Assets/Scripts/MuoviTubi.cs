using UnityEngine;

public class MuoviTubi : MonoBehaviour
{
    private float speed = 3f;
    private bool counted = false;

    void Update()
    {
        if(Flappy.playing)
        {
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            if(transform.position.x <= -3.5f)
            {
                Destroy(gameObject);
            }
            if(transform.position.x <= 0f && !counted)
            {
                Flappy.points++;
                counted = true;
            }
        }
    }
}
