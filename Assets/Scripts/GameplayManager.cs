using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour {

    public Animator state;
    public static int setting;

	
	// Update is called once per frame
	void Update () {

        setting = SceneChanger.gameplaySetting;
        StateManager(setting);
	}

    public void StateManager (int gp)
    {
        if(gp == 0)
        {
            state.SetBool("switch", true);
        }
        else
        {
            state.SetBool("switch", false);
        }
    }
}
