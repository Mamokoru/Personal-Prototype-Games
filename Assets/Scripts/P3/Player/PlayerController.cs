using UnityEngine;
using UnityEngine.InputSystem;

namespace bhudev.p3
{
    public class PlayerController : MonoBehaviour
    {
        public InputActionReference jumpAction;
        public float jumpForce = 10;
        public float gravityModifier;
        public bool isOnGround = true;
        public bool gameOver = false;
        public ParticleSystem explosionParticle;
        public ParticleSystem dirtParticle;
        public AudioClip jumpSound;
        public AudioClip crashSound;

        private Rigidbody playerRb;
        private Animator playerAnim;
        private AudioSource playerAudio;

        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            jumpAction.action.Enable();
            Physics.gravity *= gravityModifier;
            playerAnim = GetComponent<Animator>();
            playerAudio = GetComponent<AudioSource>();
        }

        void Update()
        {
            if (jumpAction.action.triggered && isOnGround && !gameOver)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                playerAnim.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound, 1.0f);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
                dirtParticle.Play();
            }
            else if (collision.gameObject.CompareTag("Obstacle"))
            {
                gameOver = true;
                Debug.Log("Game Over!");
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                explosionParticle.Play();
                dirtParticle.Stop();
                playerAudio.PlayOneShot(crashSound, 1.0f);
            }
        }
    }
}