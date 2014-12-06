using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterControl : MonoBehaviour 
{
	private Character character;
    private bool jump;


	void Awake()
	{
		character = GetComponent<Character>();
	}

    void Update ()
    {
        if (Input.GetKey (KeyCode.Space)) jump = true;
    }

	void FixedUpdate()
	{
		float h = Input.GetAxis ("Horizontal");
		character.Move(h, jump );
        
	    jump = false;
	}
}
