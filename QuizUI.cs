using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private Text timerText;
    [SerializeField] private List<Image> lifeImageList;
    [SerializeField] private List<Button> options;
    [SerializeField] private Button tutorialButton, beginGameButton;
    [SerializeField] private Color correctCol, wrongCol, normalCol;

    public List<GameObject> panels;

    public Text TimerText { get { return timerText; } }

    public List<int> CaveAnswerList = new List<int> { 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 1 };
    public List<int> ForestAnswerList = new List<int> { 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 0 };
    public List<int> CastleAnswerList = new List<int> { 1, 2, 0, 1, 0, 1, 2, 1, 0, 1, 2, 0, 1, 1, 2 };

    public List<int> CavSuccessValueList = new List<int> { 2, 0, 0, 2, 3, 2, 0, 4, 4, 4, 0, 3, 4, 4, 4 };
    public List<int> ForSuccessValueList = new List<int> { 0, 1, 2, 4, 2, 2, 0, 2, 2, 4, 3, 4, 1, 2, 2 };
    public List<int> CasSuccessValueList = new List<int> { 1, 0, 4, 0, 0, 3, 0, 0, 4, 0, 0, 0, 3, 3, 3 };

    public int panelNo = 0;

    private List<int> CurrentAnswerList;
    private List<int> CurrentSuccesslist;
    private Scene currScene;

    public Animator Anim;
    public List<Animation> Enemyanim;
    public Animator Success;


    private void Start()
    {
        //checks what scene is currently loaded so it knows which answer list to look at
        currScene = SceneManager.GetActiveScene();
        if (currScene.buildIndex == 1)
        {
            CurrentAnswerList = CaveAnswerList;
            CurrentSuccesslist = CavSuccessValueList;
        } else if (currScene.buildIndex == 2)
        {
            CurrentAnswerList = ForestAnswerList;
            CurrentSuccesslist = ForSuccessValueList;
        } else if (currScene.buildIndex == 3)
        {
            CurrentAnswerList = CastleAnswerList;
            CurrentSuccesslist = CasSuccessValueList;
        }

    }

    public void ButtonCheck(Button btn)
    {
        if (btn.name == "Answer 0")
        {
            OnClick(0);
        }
        else if (btn.name == "Answer 1")
        {
            OnClick(1);
        } else if (btn.name == "Answer 2")
        {
            OnClick(2);
        }


    }
    private void OnClick(int val)
    {

        if (val != CurrentAnswerList[panelNo])
        {
            quizManager.Answer(false);
            StartCoroutine(wait(0));
        }
        else
        {
            StartCoroutine(wait(1));
        }


        IEnumerator wait(int i)
        {
            if (i == 0)
            {
                Enemyanim[panelNo].Play("enemy attack");
                yield return new WaitForSeconds(1);
                NextPanel(panelNo);
                panelNo++;
            }
            else if (i == 1)
            {
                successful(CurrentSuccesslist[panelNo]);
                Enemyanim[panelNo].Play("Enemy die");
                yield return new WaitForSeconds(1);
                NextPanel(panelNo);
                SoundManagerScript.PlaySound("ding");
                panelNo++;
            }

        }
    }
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void ReduceLife(int index)
    {
        lifeImageList[index].color = wrongCol;
    }

    void successful(int val)
    {
        if (val == 0)
        {
            Success.Play("Magdefend");
        }
        if (val == 1)
        {
            Success.Play("Magattack");
        }
        if (val == 2)
        {
            Success.Play("Meldefend");
        }
        if (val == 3)
        {
            Success.Play("Misattack");
        }
        if (val == 4)
        {
            Success.Play("Misdefend");
        }

    }

    public void NextPanel(int panelIndex)
    {
        if (panelIndex != 14)
        {
            panels[panelIndex].SetActive(false);
            Enemyanim[panelIndex + 1].Play("moving in anim");
        }
        else
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        Anim.SetTrigger("start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(levelIndex);
    }
}


