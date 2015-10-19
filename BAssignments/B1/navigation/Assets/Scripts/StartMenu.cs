using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenu : MonoBehaviour {
	public Button Part1;
	public Button Part2;
	public Button Part3;		

	void Start () {
		Part1 = Part1.GetComponent<Button>();
		Part2 = Part2.GetComponent<Button>();
		Part3 = Part3.GetComponent<Button>();
	}
	
	public void Part1Start() {
		Application.LoadLevel(1);
	}

	public void Part2Start() {
		Application.LoadLevel(2);
	}

	public void Part3Start() {
		Application.LoadLevel(3);
	}
}
