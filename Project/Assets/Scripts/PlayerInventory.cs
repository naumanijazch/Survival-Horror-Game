using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update
    public int numKeys {get; private set;}

    public UnityEvent<PlayerInventory> OnKeyCollected;

    public void KeyCollected()
    {
        numKeys++;
        OnKeyCollected.Invoke(this);
        if (numKeys == 5)
        {
            SceneManager.LoadScene(3);

        }
    }
}
