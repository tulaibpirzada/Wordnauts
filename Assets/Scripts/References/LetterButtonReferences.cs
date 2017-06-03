using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterButtonReferences : MonoBehaviour {

    public Text letterButtonLabel;
    public Image letterButtonImage;
    public Color selectedColor;
    public Color deselectedColor;
    public Color errorColor;
    public Color correctlySelectedColor;


	public string Letter { get; set; }

	public int Column { get; set; }
	public int Row { get; set; }
    public float Size { get; set; }
    public int Index { get; set; }

    enum State { Selected, Deselected, CorrectlySelected, Error };
    private State state = State.Deselected;

	void Start () {
        state = State.Deselected;
        gameObject.transform.localScale = new Vector3(1f, 1f);
		letterButtonLabel.text = Letter.ToUpper();
		letterButtonLabel.fontSize = (int)Size / 2;
        BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>();
        boxCollider.offset = new Vector2(0.0f, 8.0f);
        boxCollider.size = new Vector2(Size - 20.0f, Size - 20.0f);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (state != State.Selected) {
	        state = State.Selected;
	        letterButtonImage.color = selectedColor;
	        GamePlayScreenController.Instance.CreateWord(Letter);
		}
    }

    public void DeselectLetter() {
        state = State.Deselected;
        letterButtonImage.color = deselectedColor;
    }

	public void CorrectlySelectLetter()
	{
        state = State.CorrectlySelected;
        letterButtonImage.color = correctlySelectedColor;
	}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    letterButtonImage.color = selectedColor;
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    letterButtonImage.color = deselectedColor;
    //}
}
