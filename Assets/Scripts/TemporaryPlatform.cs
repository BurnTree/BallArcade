using Constants;
using UnityEngine;

public class TemporaryPlatform : MonoBehaviour
{
    public float delay = 1;
    private float spendTime;
    private float initialFade;
    
    private bool isFade;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.Player) && !isFade)
        {
            isFade = true;
            initialFade = this.GetComponent<Renderer>().material.color.a;
            spendTime = delay;
        }
    }

    private void Update()
    {
        if (isFade)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            spendTime -= Time.deltaTime;
            if (spendTime >= 0)
            {
                float fadeAmount = initialFade * (spendTime / delay);
                objectColor.a = fadeAmount;
                this.GetComponent<Renderer>().material.color = objectColor;
            }
            else
                Destroy(this.gameObject);
        }

    }
}
