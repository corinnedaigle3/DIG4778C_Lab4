using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Shooting : MonoBehaviour
{
    [SerializeField]private GameObject laserPrefab;
    Player playerScript;
    private bool canShoot = true;

    private void OnEnable()
    {
        playerScript = GetComponent<Player>();
        playerScript.playerInputActions.Player.Shoot.performed += OnShooting;

    }

    void OnShooting(InputAction.CallbackContext context)
    {
        if (canShoot)
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            canShoot = false;
            StartCoroutine("Cooldown");
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}
