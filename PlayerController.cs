using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rbPlayer;

    public float speed = 10f;
    public float jumpForce;
    public float climbForce;

    public Animator anim;

    public LayerMask ground;
    public LayerMask ladder;

    public Collider2D collPlayer;
    public Collider2D DisColl;
    public Collider2D collladder;

    public Transform CellingCheck,GroundCheck;

    public int Cherry;
    public int Gam;
    public Text CherryNum;
    public Text GamNum;
   
    private bool isGround;
    private int extraJump;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        newJump();
        


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        SwitchAnim();
        Crouch();
        Climb();
        isGround = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, ground);
    }

    //��ɫ�ƶ�
    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float faceDirection = Input.GetAxisRaw("Horizontal");

        if (horizontalMove != 0)
        {
            rbPlayer.velocity = new Vector2(horizontalMove * speed * Time.deltaTime, rbPlayer.velocity.y);
            anim.SetFloat("running", Mathf.Abs(faceDirection));
        }

        if (faceDirection != 0)
        {
            transform.localScale = new Vector3(faceDirection, 1, 1);
        }

        //��ɫ��Ծ
        /*if (Input.GetButtonDown("Jump")&& collPlayer.IsTouchingLayers(ground))
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jumpForce * Time.deltaTime);
            anim.SetBool("jumping", true);
        }*/
    }
    //��ɫ��Ծ������������
    void newJump()
    {
        if (Cherry < 18)//��ͨ��Ծ
        {
            if (Input.GetButtonDown("Jump") && collPlayer.IsTouchingLayers(ground))
            {
                rbPlayer.velocity = Vector2.up * jumpForce;
                anim.SetBool("jumping", true);
            }
        }
        else
        {

            if (isGround)
            {
                extraJump = 1;
            }
            if (Input.GetButtonDown("Jump") && extraJump > 0)
            {
                rbPlayer.velocity = Vector2.up * jumpForce;
                extraJump--;
                anim.SetBool("jumping", true);
            }
            if (Input.GetButtonDown("Jump") && extraJump == 0 && isGround)
            {
                rbPlayer.velocity = Vector2.up * jumpForce;
                anim.SetBool("jumping", true);
            }
        }      
    }

    //�����л�
    void SwitchAnim()
    {
        anim.SetBool("idling", false);

        if (anim.GetBool("jumping"))//ǰ��Ϊ�Ƿ�����
        {
            if (rbPlayer.velocity.y < 0)//��������
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        
        else if (collPlayer.IsTouchingLayers(ground))//����������棬�ص�վ��״̬
        {
            anim.SetBool("falling", false);
            anim.SetBool("idling", true);
        }
    }

    //��ײ������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //��Ʒ�ռ�
        if (collision.tag == "Cherry")
        {
            Destroy(collision.gameObject);
            Cherry += 1;
            CherryNum.text = Cherry.ToString();
        }

        if (collision.tag == "Gam")
        {
            Destroy(collision.gameObject);
            Gam += 1;
            GamNum.text = Gam.ToString();
        }

        if (collision.tag == "DeadLine")
        {
            Invoke("Restart", 2f);
        }      

    }

    void Crouch()//ſ��Ч��
    {
        if (!Physics2D.OverlapCircle(CellingCheck.position,0.2f,ground))
        {
            if (Input.GetButton("Crouch"))
            {
                anim.SetBool("crouching", true);
                DisColl.enabled = false;//����ʱ�����÷�����ײ��
            }
            else
            {
                anim.SetBool("crouching", false);
                DisColl.enabled = true;
            }
        }
        
    }

    void Climb()
    {
        if (Input.GetButtonDown("Climb") && collPlayer.IsTouchingLayers(ladder))
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, climbForce * Time.deltaTime);
            anim.SetBool("climbing", true);
        }
    }

    void Restart()//���¼��ص�ǰ������������ͼ��
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

 
}
