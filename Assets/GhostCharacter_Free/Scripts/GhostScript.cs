using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sample {
public class GhostScript : MonoBehaviour
{
     private Animator Anim;
        public bool ghostWonder = false;
        private RectTransform canvasRect;

        // moving speed
        [SerializeField] private float Speed = 4;

        void Start()
    {
        Anim = this.GetComponent<Animator>();
            Canvas canvas = GetComponentInParent<Canvas>();
            if (canvas != null)
            {
                canvasRect = canvas.GetComponent<RectTransform>();
            }
        }

    void Update()
    {
            if (!ghostWonder)
            {
                Anim.Play("move");
            }
            else
            {
                if(canvasRect != null)
                {
                    MoveAcrossScreen();
                }
            }
        }

        void MoveAcrossScreen()
        {
            if (canvasRect == null)
                return;

            // Get the corners of the canvas
            Vector3[] canvasCorners = new Vector3[4];
            canvasRect.GetWorldCorners(canvasCorners);

            // Set the target position to the opposite corner of the canvas
            Vector3 targetPosition = new Vector3(
                canvasCorners[2].x, // Use the top right corner x-coordinate
                canvasCorners[2].y, // Use the top right corner y-coordinate
                transform.position.z // Maintain the original z-coordinate
            );

            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);

            // Play animation when moving
            Anim.Play("move");
        }
    }

}