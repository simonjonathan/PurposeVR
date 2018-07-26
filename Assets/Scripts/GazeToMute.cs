// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;

using System.Collections;


[RequireComponent(typeof(Collider))]
public class GazeToMute : MonoBehaviour {
    //Timeline Agent Controller
    private Vector3 startingPosition;

    public GameManager gameManager;

    public Vector3 camDirection;
    public Camera mainCamera;

    public GameObject tutorialDisplay;

    void Start() {
        startingPosition = transform.localPosition;
        SetGazedAt(false);
    }

    void Update(){

    }

    //Setting boolean gazedAt for EventTrigger
    public void SetGazedAt(bool gazedAt) {
        return;
    }

    public void Reset() {
        transform.localPosition = startingPosition;
    }

    public void Recenter() {
    #if !UNITY_EDITOR
        GvrCardboardHelpers.Recenter();
    #else
        GvrEditorEmulator emulator = FindObjectOfType<GvrEditorEmulator>();
        if (emulator == null) {
            return;
        }
    emulator.Recenter();
    #endif  // !UNITY_EDITOR
    }
    
    //DefeatAgent for "Tutorial" before Game
    public void DefeatAgent() {
        if (tutorialDisplay.activeSelf == true)
        {
            camDirection = mainCamera.transform.forward;
            GetComponent<Rigidbody>().AddForce(camDirection * 200, ForceMode.Impulse);
            gameManager.defeatedAgents += 1;
        }

    }
}

