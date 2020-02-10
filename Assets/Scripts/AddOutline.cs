using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddOutline : MonoBehaviour
{
    public static UnityAction OutlineAction { get; set; }
    public static UnityAction OutlineAction2 { get; set; }
    public GameObject Knife;
    public GameObject Axe;
    public Color32 newColor;
    public float LineStrenght;

    // Start is called before the first frame update

    private void Awake()
    {
        OutlineAction += outlineFunction;
        OutlineAction2 += outlineFunction2;
    }
    void Start()
    {
        OutlineAction.Invoke();
        
    }
    private Outline SetUpOutline(GameObject target, Color32 color, float line)
    {
        Outline result = target.AddComponent<Outline>();
        result.OutlineMode = Outline.Mode.OutlineAll;
        result.OutlineColor = color;
        result.OutlineWidth = line;

        //var outline = gameObject.AddComponent<Outline>();



        Debug.Log("OutlineConfigured");
        return result;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            OutlineAction.Invoke();
        }
        if (Input.GetKeyDown("t"))
        {
            OutlineAction2.Invoke();
        }
    }

    private void outlineFunction()
    {
        Destroy(Axe.GetComponent<Outline>());
        newColor = new Color32(255, 0, 0, 255);
        LineStrenght = 10f;
        SetUpOutline(Knife, newColor, LineStrenght);
    }
    private void outlineFunction2()
    {
        Destroy(Knife.GetComponent<Outline>());
        newColor = new Color32(0, 0, 255, 255);
        LineStrenght = 10f;
        SetUpOutline(Axe, newColor, LineStrenght);
    }
}
