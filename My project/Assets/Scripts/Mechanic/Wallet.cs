using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for opening and closing (enable and disable) wallet canvas button.
public class Wallet : MonoBehaviour
{
    public GameObject WalletCanvas;
    public bool WalletIsOpen;
    
    void Start()
    {
        WalletCanvas.SetActive(false);
        WalletIsOpen = false;
    }


    //open and close wallet with UI button
    public void AOpenWallet()
    {
        if (!WalletIsOpen)
        {
            WalletCanvas.SetActive(true);
            WalletIsOpen = true;
        }
        else
        {
            WalletCanvas.SetActive(false);
            WalletIsOpen = false;
        }
    }

    //open and close wallet with keyboard
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (!WalletIsOpen)
            {
                WalletCanvas.SetActive(true);
                WalletIsOpen = true;
            }
            else
            {
                WalletCanvas.SetActive(false);
                WalletIsOpen = false;
            }
        }
    }
}
