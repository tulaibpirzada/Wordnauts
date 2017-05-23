using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterButtonReferences : MonoBehaviour {

    public Text letterButtonLabel;

	public string Letter { get; set; }

	public int Column { get; set; }
	public int Row { get; set; }
    public float Size { get; set; }
    public int Index { get; set; }

	void Start () {
        gameObject.transform.localScale = new Vector3(1f, 1f);
		letterButtonLabel.text = Letter.ToUpper();
		letterButtonLabel.fontSize = (int)Size / 2;
	}
}
