using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game {
    #region Important Variables
    public static InputActions Input { get; private set; } = new _InputActions();

    #endregion


    #region Managers
    public static GameManager Manager { get; private set; }

    #endregion




    // Static Constructor
    static Game() {
        Manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Modified controls class to enable on construction
    private class _InputActions : InputActions {
        public _InputActions() : base() {
            Enable();
        }
    }
}
