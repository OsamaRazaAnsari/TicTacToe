using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using System;

public class Manager : MonoBehaviour 
{
	public Sprite oImage;
    public Sprite xImage;
    public  Image winImage;
    private Image image;
	public Text p1WinCounterIndicator;
	public Text p2WinCounterIndicator;
	string player1name;
	string player2name;
	int p1WinCounter = 0;
	int p2WinCounter = 0;
	int init = 0;
	int xTurnCounter = 0;
	int oTurnCounter = 0;
	int winCounter = 0;
	private bool xTurn = true;
	public Text turnIndicator;
	int[,] com = new int[8,3];
    private List <int> ximgsetpos=new List<int>(9);
    private List<int> oimgsetpos = new List<int>(9);
	int[] values = new int[] { 0, 1, 2, 0, 3, 6, 0, 4, 8, 1, 4, 7, 2, 5, 8, 2, 4, 6, 3, 4, 5, 6, 7, 8 };
	public Image[] squares = new Image[9];

	void Start () 
	{
	//	xTurn = true;
		//required variable for scene not to destroy
		player1name= PlayerPrefs.GetString ("player1name");
		player2name= PlayerPrefs.GetString ("player2name");
		p1WinCounter= PlayerPrefs.GetInt ("key1");
		p2WinCounter= PlayerPrefs.GetInt ("key2");

		//Insert Value in Combination array for Wining game
		for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 3;j++ )
			{
             com[i,j]=values[init];
	  		 init=init+1;
            }
        }
       
        /// ALL References 
		p1WinCounterIndicator.GetComponent<Text> ();    
		p2WinCounterIndicator.GetComponent<Text> ();
        winImage.GetComponent<Image>();

		//Set image on all the squares
		foreach (Image image in squares)
        {
           image.GetComponent<Image>();

           image.name = "notSetImage";
		//	Debug.Log (image.name);
        }
		///still here:

		//indicate turns of both players 
		turnIndicator.text = player1name + " Turn";

		//indicate Winner of the game
		p1WinCounterIndicator.text = player1name + " Win:" + p1WinCounter;
		p2WinCounterIndicator.text = player2name + " Win:" + p2WinCounter;

       	}

	void Update()
	{
		int result=xTurnCounter + oTurnCounter;

		//foreach(Image obj in squares)
		//{
		    if (result==9) 
			{
				turnIndicator.text="Draw Game";
				winImage.gameObject.SetActive (true);

			}
		//}

	}
	public void OnButtonClick(int squareValue) 
	{
	    if (squares[squareValue].name == "notSetImage")
		{
			//Debug.Log (true);
            SetImage(squareValue);

        }

    }
    void SetImage(int squareValue)
	{
     	if (xTurn) 
		{
			xTurn = false;
			xTurnCounter = xTurnCounter + 1;   
			ximgsetpos.Add (squareValue);
			squares [squareValue].GetComponent<Image> ().sprite = xImage;
			squares [squareValue].name = "setXImage";
			turnIndicator.text = player2name + " turn";

			if (xTurnCounter >= 3)
			{
				CheckWinner (ximgsetpos, squares [squareValue].name);
			}
		}
        else
        {
            xTurn = true;
			oTurnCounter = oTurnCounter + 1;
            oimgsetpos.Add(squareValue);
            squares[squareValue].GetComponent<Image>().sprite = oImage;
            squares[squareValue].name = "setOImage";
			turnIndicator.text = player1name + " turn";

			if (oTurnCounter >= 3)
			{
				CheckWinner (oimgsetpos, squares [squareValue].name);
			}
        }
    
    } 
  
    void CheckWinner(List<int> imgsetpos,string imgname) 
    {
	  if(imgname=="setOImage")
		{
			for (int i = 0; i < 8; i++) 
			{
				for (int j = 0; j < 3; j++) 
				{
					foreach (int obj in imgsetpos) 
					{
						if (com [i, j] == obj) 
						{
					    	winCounter = winCounter + 1;
						}
                   	}
                 }
				if (winCounter == 3) 
				{
					turnIndicator.text = player2name + " Win";
					winImage.gameObject.SetActive (true);
					p2WinCounterIndicator.text = player2name + " Win: " + p2WinCounter;
					p2WinCounter = p2WinCounter + 1;
					PlayerPrefs.SetInt ("key2",p2WinCounter);
				} 
				else
				{
					winCounter = 0;
				}
			}
		
		}
        else
        {
           	for (int i = 0;i<8 ;i++ )
			{
				for (int j = 0;j<3 ;j++ )
				{
					foreach(int obj in imgsetpos)
					{
	     				if (com[i, j] == obj)
						{
								winCounter = winCounter + 1;
						}

					}

	   			}
				if (winCounter == 3)
				{
					turnIndicator.text = player1name +" Win";
					winImage.gameObject.SetActive (true);
					p1WinCounterIndicator.text = player1name + " Win:" + p1WinCounter;
					p1WinCounter = p1WinCounter + 1;
					PlayerPrefs.SetInt ("key1",p1WinCounter);
				}
				else
				{
					winCounter = 0;
				}
			}
        }

    }
}
