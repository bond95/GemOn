using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CreatureGenerator : MonoBehaviour
{
	[Serializable]
	public struct ColoredSprites {
	    public int color;
	    public List <Sprite> sprites;
	}
	[Serializable]
	public struct BodyTypeColoredSprites {
	    public int bodyType;
	    public List <ColoredSprites> sprites;
	}
	public List <ColoredSprites> bodies = new List<ColoredSprites>();
	public List <Sprite> faces = new List<Sprite>();
	public List <ColoredSprites> ears = new List<ColoredSprites>();
	public List <BodyTypeColoredSprites> hairs = new List<BodyTypeColoredSprites>();

	public int[] state = new int[5];

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.GenerateCreature(this.state[0], this.state[1], this.state[2], this.state[3], this.state[4]);
    }

	public void SetState(int[] data)
	{
		this.state[data[0]] = data[1];
	}

    void GenerateCreature(int color, int body, int hair, int face, int ear) {
    	GameObject body_obj = gameObject.transform.Find("Body").gameObject;
		GameObject hair_obj = gameObject.transform.Find("Hair").gameObject;
		GameObject ear_obj = gameObject.transform.Find("Ear").gameObject;
		GameObject face_obj = gameObject.transform.Find("Face").gameObject;
    	body_obj.GetComponent<Image>().sprite = bodies.Find(x => x.color == color).sprites[body];
    	ear_obj.GetComponent<Image>().sprite = ears.Find(x => x.color == color).sprites[ear];
    	hair_obj.GetComponent<Image>().sprite = hairs.Find(x => x.bodyType == body).sprites.Find(x => x.color == color).sprites[hair];
    	face_obj.GetComponent<Image>().sprite = faces[face];
    }
}
