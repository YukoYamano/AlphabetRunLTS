using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingMechanic : MonoBehaviour
{
    [SerializeField] private string[] Questions = {"ok", "hi","up","in"};
    //[SerializeField] private string[] middleQuestions = { "hello", "game" };
    public Text displayQuestionText;
    private int questionNumber;
    private string stringQuestion;
    private int indexOfString;  //how many number of string.
    private string correctString;


    // Start is called before the first frame update
    void Start()
    {
        //Finiding gameObject named questionText and inside the component get Text.
        displayQuestionText = GameObject.Find("QuestionText").GetComponent<Text>();
        displayQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
        //checking the firstletter
        if (Input.GetKeyDown(stringQuestion[indexOfString].ToString()))
        {     
            Debug.Log(stringQuestion[indexOfString].ToString());
            indexOfString++;
        }
           
        if (indexOfString >= stringQuestion.Length)
         {
            //display other question
           displayQuestion();
         }
        else if (Input.anyKeyDown)
        {
            Wrong();
        }
      
        
       

       
    }

    private void displayQuestion()
    {
        displayQuestionText.text = "";
        indexOfString = 0;
        questionNumber = Random.Range(0, Questions.Length);  //get random number through 0~3
        stringQuestion = Questions[questionNumber];   // 0~3  = 4questions
        displayQuestionText.text = stringQuestion;
    }


    void Wrong()
    {
        //Debug.Log("Wrong");
    }
}
