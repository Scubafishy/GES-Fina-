using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour {

    [SerializeField]
    string nameText;

    [SerializeField]
    GameObject endingCrystal;

    [Tooltip("If you set a key, the door will be locked.")]
    [SerializeField]
    InventoryObject key;


    private Animator animator;
    private bool isLocked, isOpen;
    private List<InventoryObject> playerInventory;

    public string NameText
    {
        get
        {
            string toReturn = nameText;

            if (isOpen)
                toReturn = ""; // So it doesn't look like you can open the door anymore.
            else if (isLocked && !HasKey)
                toReturn += " (Missing Crystal)";
            else if (isLocked && HasKey)
                toReturn += string.Format(" (use {0})", key.NameText);

            return toReturn;
        }
    }

    private bool HasKey
    {
        get
        {
            return playerInventory.Contains(key);
        }
    }

    public void DoActivate()
    {
        if (!isOpen)
        {
            if (!isLocked || HasKey)
            {
                isOpen = true;
                endingCrystal.SetActive(true);
                SceneManager.LoadScene("WinScene");
            }
        }

    }

    // Use this for initialization
    void Start()
    {

        playerInventory = FindObjectOfType<InventoryMenu>().PlayerInventory;
        isLocked = key != null;
    }
}
