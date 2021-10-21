using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3 respawnPosition;

    public int currentGold;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        respawnPosition = PlayerController.instance.transform.position;

        AddGold(0);
    }

    
    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine(RespawnWaiter());
    }

    public IEnumerator RespawnWaiter()
    {
        PlayerController.instance.gameObject.SetActive(false);

        UIManager.instance.fadeToBlack = true;

        yield return new WaitForSeconds(2f);

        UIManager.instance.fadeFromBlack = true;

        PlayerController.instance.transform.position = respawnPosition;
        PlayerController.instance.gameObject.SetActive(true);

        HealthManager.instance.ResetHealth();
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        respawnPosition = newSpawnPoint;
        Debug.Log("Spawn Set");
    }

    public void AddGold(int goldToAdd)
    {
        currentGold += goldToAdd;
        UIManager.instance.goldText.text = "" + currentGold;
    }
}
