using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Josephus : MonoBehaviour {

    public InputField input;
    public Text output;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AcceptInput()
    {
        JosephusAlgorithm(input.text);
    }

    //parses input string then sets output to the Josephus answer for the given number
    //will output an empty string for non-numeric input
    public void JosephusAlgorithm(string input)
    {
        int noOfknights;
        bool valid = int.TryParse(input, out noOfknights);
        valid = valid && noOfknights > 0;
        if (valid){
            output.text = fastJosephus(noOfknights);
        }
        else
        {
            output.text = "";
        }
    }

    public string slowJosephus(int numOfKnights)
    {
        //actual algorithm goes here
        Knight[] knights = new Knight[numOfKnights];
        knights[0] = new Knight();
        knights[0].Position = 1;
        for (int i = 1; i < knights.Length; i++)
        {
            knights[i] = new Knight();
            knights[i].Position = i + 1;
            knights[i - 1].NextKnight = knights[i];
        }
        knights[knights.Length - 1].NextKnight = knights[0];
        Knight myKnight = knights[0];
        while (myKnight.NextKnight != myKnight)
        {
            myKnight.NextKnight = myKnight.NextKnight.NextKnight;
            myKnight = myKnight.NextKnight;
        }
        return myKnight.Position + "";
    }

    public string fastJosephus(int numOfKnights)
    {
        string binaryForm = System.Convert.ToString(numOfKnights, 2);
        string answer = binaryForm.Substring(1, binaryForm.Length - 1) + binaryForm.Substring(0, 1);
        return System.Convert.ToInt32(answer, 2) + "";
    }

    private class Knight
    {
        private int position;
        private Knight nextKnight;

        public Knight NextKnight
        {
            get
            {
                return nextKnight;
            }

            set
            {
                nextKnight = value;
            }
        }

        public int Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public Knight(int position, Knight nextKnight)
        {
            this.Position = position;
            this.NextKnight = nextKnight;
        }

        public Knight()
        {
        }
    }

}


