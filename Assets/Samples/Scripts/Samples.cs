using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Samples : MonoBehaviour
{
    [SerializeField]
    private GameObject MainUI;

    private GameObject MainUIRoot;

    private bool MainUIIsOpen {
        get {
            if (null == MainUIRoot) {
                MainUIRoot = MainUI.transform.Find("Root").gameObject;
            }
            return MainUIRoot.activeSelf;
        }
    }

    private void OnGUI() {
        if (GUI.Button(new Rect(20, 40, 200, 50), MainUIIsOpen ? "关闭Main" : "打开Main")) {
            if (MainUIIsOpen) {
                CloseMainUI();
            }
            else {
                OpenMainUI();
            }
        }
    }

    private void OpenMainUI() {
        MainUI.GetComponent<Animator>().Play("MainIn");
    }

    private void CloseMainUI() {
        MainUI.GetComponent<Animator>().Play("MainOut");
    }
}
