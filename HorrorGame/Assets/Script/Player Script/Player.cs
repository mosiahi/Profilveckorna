using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    walk, attack, interact, stagger, idle
}

public class Player : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    public Vector3 change;
    private Animator anim;
    public FloatValue currentHealth;
    public SignalManager PlayerHealthSignal;
    public VectorValue startingPos;
    public Inventory playerInventory;
    public SpriteRenderer receivedItemSprite;
    [SerializeField] bool IsResistingDMG = false;
    [SerializeField] float DamageRes;
    [SerializeField] FieldOfView myFlashLight;

    // Start is called before the first frame update
    void Start()
    {
        Scene myCurrentScene = SceneManager.GetActiveScene();
        currentState = PlayerState.walk;
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        //So box collisders for down is registered
        anim.SetFloat("moveX", 0);
        anim.SetFloat("moveY", -1);


        

        // Retrieve the name of this scene.
        string tempsceneName = myCurrentScene.name;

        //if (tempsceneName == "New Game")
        //{
            transform.position = startingPos.initialValue;
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        //myFlashLight.setOrgin(transform.position);

        //Is The Player In An Interaction
        GodMode();
        if (currentState == PlayerState.interact)
        {
            return;
        }

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimAndMove();
        }
    }

    private IEnumerator AttackCo()
    {
        anim.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        anim.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }
    public void GodMode()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            currentHealth.RuntimeValue = 100000000;

        }
    }

    public void RaiseIteam()
    {
        if (playerInventory.currentItem != null)
        {
            if (currentState != PlayerState.interact)
            {
                anim.SetBool("receive item", true);
                currentState = PlayerState.interact;
                receivedItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else
            {
                anim.SetBool("receive item", false);
                currentState = PlayerState.idle;
                receivedItemSprite.sprite = null;
                playerInventory.currentItem = null;
            }
        }
    }

    void UpdateAnimAndMove()
    {
        if (change != Vector3.zero)
        {
            MovePlayer((float)Time.deltaTime);
            anim.SetFloat("moveX", change.x);
            anim.SetFloat("moveY", change.y);
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }
    void MovePlayer(float aDeltaTime)
    {
        change.Normalize();
        myRigidbody.MovePosition(transform.position + change * speed * aDeltaTime);
    }

    public void Knock(float knockTime, float damage)
    {
        if (IsResistingDMG)
        {
            damage *= DamageRes;
        }
        currentHealth.RuntimeValue -= damage;
        PlayerHealthSignal.Raise();
        if (currentHealth.RuntimeValue > 0)
        {
            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            this.gameObject.SetActive(false);

            StartCoroutine(Timer());
            SceneManager.LoadScene("GameOver");
        }
        
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2);
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

    public void SetIsResistingDMG(bool aIsResistingDMG, float SomeDamageRes)
    {
        IsResistingDMG = aIsResistingDMG;
        DamageRes = SomeDamageRes;
    }
}
