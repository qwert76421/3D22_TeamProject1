using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TestingQuestionDialog : MonoBehaviour {

    public GameObject Gamecontrol;
    private void Update() {
        if (true) {
            QuestionDialogUI.Instance.ShowQuestion("Do you want to buy this property?", () => {
                Application.Quit();
#if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
#endif
            }, () => {
                // Do nothing on No
                //Gamecontrol.GetComponent<rollTheDice>().buyAllow=false;
            });
        }
    }

}