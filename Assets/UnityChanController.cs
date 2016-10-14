using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour {

    private Animator myAnimator;
    private AnimatorStateInfo animState;
    private Rigidbody myRigidbody;
    private float forwardForce = 800f;
    private float turnForce = 500f;
    private float upForce = 500.0f;
    private float movableRange = 3.4f;
    private float coefficient = 0.95f;
    private bool isEnd = false;
    private GameObject stateText;
    private GameObject scoreText;
    private int score = 0;
    private bool isLButtonDown = false;
    private bool isRButtonDown = false;

    // Use this for initialization
    void Start () {
        myAnimator = GetComponent<Animator>();
        myAnimator.SetFloat("Speed", 1);
        myRigidbody = GetComponent<Rigidbody>();
        stateText = GameObject.Find("GameResultText");
        scoreText = GameObject.Find("ScoreText");
	}

    // Update is called once per frame
    void Update()
    {
        if (this.isEnd)
        {
            this.forwardForce *= this.coefficient;
            this.turnForce *= this.coefficient;
            this.upForce *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }

        myRigidbody.AddForce(this.transform.forward * this.forwardForce);
        if ((Input.GetKey(KeyCode.LeftArrow)||isLButtonDown) && -movableRange < transform.position.x)
        {
            myRigidbody.AddForce(-this.turnForce, 0, 0);
        }
        else if ((Input.GetKey(KeyCode.RightArrow) || isRButtonDown) && movableRange > transform.position.x)
        {
            myRigidbody.AddForce(this.turnForce, 0, 0);
        }

        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f)
        {
            this.myAnimator.SetBool("Jump", true);
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "ConeTag")
        {
            this.isEnd = true;
            stateText.GetComponent<Text>().text = "GAME OVER";
        }
        if (other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
            stateText.GetComponent<Text>().text = "CLEAR!!";
        }

        if (other.gameObject.tag == "CoinTag")
        {
            GetComponent<ParticleSystem>().Play();
            score += 10;
            scoreText.GetComponent<Text>().text = "Score " + score + "pt";
            Destroy(other.gameObject);
        }
    }

    public void GetMyJumpButtonDown()
    {
        if (this.transform.position.y < 0.5f)
        {
            this.myAnimator.SetBool("Jump", true);
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }
    }

    //左ボタンを押し続けた場合の処理（追加）
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    //左ボタンを離した場合の処理（追加）
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }

    //右ボタンを押し続けた場合の処理（追加）
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    //右ボタンを離した場合の処理（追加）
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }
}
