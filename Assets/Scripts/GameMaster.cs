﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public Text InputText;

	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}

}
