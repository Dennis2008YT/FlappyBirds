using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Flappy : MonoBehaviour
{
    private float jumpForce = 5f;
    [SerializeField] private InputActionAsset Input;
    [SerializeField] private GameObject GameOverObj, StartObj, PointsObj;
    [SerializeField] private AudioSource flappyAudioSource;
    [SerializeField] private AudioClip jumpSound, gameOverSound, pointSound;
    public static bool playing = false;
    public static int points = 0;
    private bool canJump = true;
    private InputAction jump;
    
    private Vector2 startPos;

    void Start()
    {
        jump = Input.FindActionMap("Bird").FindAction("Jump");
        jump.performed += Jump;
        jump.canceled += enableJumping;
        startPos = transform.position;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        flappyAudioSource = gameObject.GetComponent<AudioSource>();
        flappyAudioSource.clip = jumpSound;
    }

    void Update()
    {
        PointsObj.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = points.ToString();
    }

    void Jump(InputAction.CallbackContext obj)
    {
        if(canJump == true && playing)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            flappyAudioSource.Play();
            canJump = false;
        }
    }

    void enableJumping(InputAction.CallbackContext obj)
    {
        canJump = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        playing = false;
        GameOverObj.SetActive(true);
    }

    public void Restart(string mode)
    {
        if(mode == "start") 
        {
            StartObj.SetActive(false);
            Points.SetActive(true);
        }
        else 
        {
            GameOverObj.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("Tubi"));
            points = 0;
        }
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        transform.position = startPos;
        playing = true;
    }
}
