using UnityEngine;

namespace FeedbackSystem
{
    public class Feedback : MonoBehaviour
    {
        [SerializeField] private GameObject feedbackObject;

        public void CreateFeedback()
        {
            Instantiate(feedbackObject, transform.position + new Vector3(0,0,-1), Quaternion.identity);
        }
    }
}