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
    public Text UII;


    // Start is called before the first frame update
    void Start()
    {
        //Finiding gameObject named questionText and inside the component get Text.
        displayQuestionText = GameObject.Find("QuestionText").GetComponent<Text>();
        UII = GameObject.Find("InputText").GetComponent<Text>();
        DisplayQuestion();
    }

    // Update is called once per frame
    void Update()
    {

        Typing();

       
    }

    public void Typing()
    {
        //checking the firstletter
        if (Input.GetKeyDown(stringQuestion[indexOfString].ToString()))
        {
            Correct();
           // Debug.Log(stringQuestion[indexOfString].ToString());
           // indexOfString++;


            if (indexOfString >= stringQuestion.Length)
            {
                //display other question
                DisplayQuestion();
                //Enable question text
                Debug.Log("Pass");
            }

        }else if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Spacekey igonered");
            }
            else
            {
                Wrong();
            }
           
        }
   
        
    }

    private void DisplayQuestion()
    {
        displayQuestionText.text = "";
        UII.text = "";
        correctString = "";

        indexOfString = 0;
        questionNumber = Random.Range(0, Questions.Length);  //get random number through 0~3
        stringQuestion = Questions[questionNumber];   // 0~3  = 4questions
        displayQuestionText.text = stringQuestion;
    }

    void Correct()
    {
        //　正解した文字を表示
        correctString += stringQuestion[indexOfString].ToString();
        UII.text = correctString;
        //　次の文字を指す
        indexOfString++;
    }
    void Wrong()
    {
        Debug.Log("Wrong");
    }
}
