// Ignore Spelling: Gizmos Behaviour
// Ignore Spelling: Gizmo
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("---Gizmo---")]
    public float rangeValue;

    [Header("---Player---")]
    public GameObject player;

    public Rigidbody rigidBody;

    [Header("---Enemy---")]
    public Transform enemy;

    public float moveSpeed;

    [Header("---Game Over UI---")]
    private bool isEnd = false;

    public GameObject gameOver;

    private void Start()
    {
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (rigidBody == null)
        {
            GameStatus(isEnd);
            Time.timeScale = 0;
        }
    }

    public void OnDrawGizmos()
    {
        //just checks if the player is still alive
        if (rigidBody == true)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(player.transform.position, rangeValue);
        }
    }

    public void GameStatus(bool status)
    {
        isEnd = status;
        gameOver.SetActive(true);
    }
}