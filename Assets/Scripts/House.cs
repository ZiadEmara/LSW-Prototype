using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Acts like a main menu. 
/// </summary>
public class House : MonoBehaviour
{
    [SerializeField] GameObject mainMenu = null;

    bool playerInRange = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player", System.StringComparison.Ordinal))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player", System.StringComparison.Ordinal))
            playerInRange = false;
    }

    private void Update()
    {
        // If the player is in range, wait for them to press interact to open the menu
        if (playerInRange)
        {
            if (Input.GetButtonDown("Interact"))
            {
                OpenMenu();
            }
        }
    }

    void OpenMenu()
    {
        mainMenu.SetActive(true);
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
