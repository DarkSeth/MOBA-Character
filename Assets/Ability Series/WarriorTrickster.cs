using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarriorTrickster : MonoBehaviour
{
    //In Script Stuff
    Animator anim;
    Movement moveScript;

    [Header("Warrior Trickster Ability")]
    public Image cloneImage;
    public float cooldown = 10;
    bool isCooldown = false;
    bool canSpawnClone = true;
    public KeyCode ability;

    [Space(5)]
    public bool inInvisMode = false;
    public Transform cloneSpawnPoint;
    public GameObject cloneObj;
    public GameObject invisCanvasObj;

    [Header("Body for Material Change")]
    public Material transparentMaterial;
    public SkinnedMeshRenderer skinMeshBod1;
    public SkinnedMeshRenderer skinMeshBod2;
    public Material bod1Material;
    public Material bod2Material;
    

    void Start()
    {
        cloneImage.fillAmount = 0;

        moveScript = GetComponent<Movement>();
        anim = GetComponent<Animator>();

        skinMeshBod1.material = bod1Material;
        skinMeshBod2.material = bod2Material;

        invisCanvasObj.SetActive(false);
    }

    void Update()
    {
        CloneAbility();
    }

    public void CloneAbility()
    {
        //Press the ability
        if (Input.GetKey(ability))
        {
            if (canSpawnClone && isCooldown == false)
            {
                isCooldown = true;
                cloneImage.fillAmount = 1;
                inInvisMode = true;

                StartCoroutine(SpawnClone());
            }

        }

        //Turn invislbe
        if(inInvisMode)
        {
            invisCanvasObj.SetActive(true);
            skinMeshBod1.material = transparentMaterial;
            skinMeshBod2.material = transparentMaterial;
        }
        else
        {
            skinMeshBod1.material = bod1Material;
            skinMeshBod2.material = bod2Material;
            invisCanvasObj.SetActive(false);
        }

        //Icon ability goes on cooldown
        if (isCooldown)
        {
            Debug.Log("YEEEP");
            cloneImage.fillAmount -= 1 / cooldown * Time.deltaTime;

            if (cloneImage.fillAmount <= 0)
            {
                cloneImage.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

    IEnumerator SpawnClone()
    {
        canSpawnClone = false;
        Instantiate(cloneObj, cloneSpawnPoint.transform.position, cloneSpawnPoint.transform.rotation);
        yield return new WaitForSeconds(cooldown);
        canSpawnClone = true;
    }
}
