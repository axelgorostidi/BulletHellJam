using System.Collections;
using UnityEngine;

public class DrawLimit : MonoBehaviour
{
        public static DrawLimit instance = null;

        [SerializeField] private float initialScale = 150;
        private float currentScale;

        [SerializeField] private float rateOfDecrease = 1f;
        [SerializeField] private float rateOfIncrease = 3f;
        [SerializeField] private GameObject measurePoint;
        private float currentDistanceToBase;

        private void Awake() 
        {
            if(instance==null)
                instance=this;
            else
                Destroy(this.gameObject);
        }

        private void Start() 
        {
            currentScale = initialScale;
            transform.localScale = new Vector3(initialScale, initialScale, 1f);
            currentDistanceToBase = Vector3.Distance(measurePoint.transform.position, Base.instance.transform.position);
        }

        private void Update() 
        {
            StartCoroutine(DecreaseScale());

            if(currentScale <= 0f)
            {
                Base.instance.Damage(99999999, null);
                Destroy(this.gameObject);
            }
        }

        IEnumerator DecreaseScale()
        {
            currentScale -= rateOfDecrease;
            transform.localScale = new Vector3(currentScale, currentScale, 1f);
            yield return new WaitForSeconds(1f);
        }

        public void IncreaseScale()
        {
            currentScale += rateOfIncrease;
            if(currentScale > initialScale)
                currentScale = initialScale;
            //transform.localScale = new Vector3(currentScale, currentScale, 1f);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(currentScale, currentScale, 1f), .5f);
        }

        public float GetCurrentDistanceToBase()
        {
            return Vector3.Distance(measurePoint.transform.position, Base.instance.transform.position);
        }
}
