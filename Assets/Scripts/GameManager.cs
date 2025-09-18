using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject meteorPrefab;
    public GameObject bigMeteorPrefab;
    public bool gameOver = false;

    public int meteorCount = 0;
    PlayerInputActions playerInputActions;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        InvokeRepeating("SpawnMeteor", 1f, 4f);
        InvokeRepeating("BigMeteor", 15f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            CancelInvoke();
        }

/*        if (meteorCount == 5)
        {
            BigMeteor();
        }*/
    }

    private void OnEnable()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.LoadWeek5Lab.performed += LoadWeek5LabScene;
    }

    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }


    void SpawnMeteor()
    {
        Instantiate(meteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }

    void BigMeteor()
    {
        meteorCount = 0;
        Instantiate(bigMeteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }

    void LoadWeek5LabScene(InputAction.CallbackContext context)
    {
        if (gameOver)
        {
            SceneManager.LoadScene("Week5Lab");
        }
    }
}
