using UnityEngine;
using UnityEngine.UI;

public class ShoppingHandler : MonoBehaviour
{
    [Header("Handlers")]
    public CurrencyHandler CurrencyHandler;
    [Header("Objetos")]
    public GameObject Items;    
    public GameObject GPUItems;
    public GameObject CPUItems;
    public GameObject FonteItems;
    public GameObject RAMItems;

    private int GPUItemCounter;
    private int CPUItemCounter;
    private int FonteItemCounter;
    private int RAMItemCounter;

    private float[] GPUPrices = { 1000.0000F, 2000.0000F, 4000.0000F, 100000000.0000F };
    private float[] CPUPrices = { 500.0000F, 1000.0000F, 1500.0000F, 100000000.0000F };
    private float[] RAMPrices = { 30.0000F, 60.0000F, 120.0000F, 100000000.0000F };
    private float[] FontePrices = { 05.0000F, 10.0000F, 20.0000F, 100000000.0000F };

    // Start is called before the first frame update
    void Start()
    {
        Items.SetActive(false);

        //Settar variáveis
        GPUItemCounter = 0;
        CPUItemCounter = 0;
        FonteItemCounter = 0;
        RAMItemCounter = 0;

        SelectActiveItems();
    }

    void OnDisable()
    {
        CloseItems();
    }

// #######################################################################
// #################### ITEMS SPECIFIC FUNCTIONS #########################
// #######################################################################

    void SelectActiveItems()
    {
        //GPU
        if (GPUItemCounter < GPUItems.transform.childCount) {
            CloseChildren(GPUItems, GPUItemCounter);
            GPUItems.transform.GetChild(GPUItemCounter).gameObject.SetActive(true);
        }
        //CPU
        if (CPUItemCounter < CPUItems.transform.childCount) {
            CloseChildren(CPUItems, CPUItemCounter);
            CPUItems.transform.GetChild(CPUItemCounter).gameObject.SetActive(true);
        }
        //FONTE
        if (FonteItemCounter < FonteItems.transform.childCount) {
            CloseChildren(FonteItems, FonteItemCounter);
            FonteItems.transform.GetChild(FonteItemCounter).gameObject.SetActive(true);          
        }
        //RAM
        if (RAMItemCounter < RAMItems.transform.childCount) {
            CloseChildren(RAMItems, RAMItemCounter);
            RAMItems.transform.GetChild(RAMItemCounter).gameObject.SetActive(true);
        }
    }

    void SelectActiveItem(GameObject item, int counter) 
    {
        if (counter < item.transform.childCount) {
            CloseChildren(item, counter);
            item.transform.GetChild(counter).gameObject.SetActive(true);
        }
    }

    void BuyItem(Button button)
    {
        button.interactable = false;
    }

    public void BuyGPU(Button button)
    {
        if (CurrencyHandler.GetDoletasValue() >= GPUPrices[GPUItemCounter]) {
            CurrencyHandler.DeacreseCurrency(GPUPrices[GPUItemCounter]);
            CurrencyHandler.IncreaseByClick += 00.5400f;
            BuyItem(button);
            GPUItemCounter++;

            SelectActiveItem(GPUItems, GPUItemCounter);
        } else {
            Debug.Log("MONEY!");
        }
    }

    public void BuyCPU(Button button)
    {
        if (CurrencyHandler.GetDoletasValue() >= CPUPrices[CPUItemCounter]) {
            CurrencyHandler.DeacreseCurrency(CPUPrices[CPUItemCounter]);
            CurrencyHandler.IncreaseByClick += 00.3800f;
            BuyItem(button);
            CPUItemCounter++;

            SelectActiveItem(CPUItems, CPUItemCounter);
        } else {
            Debug.Log("MONEY!");
        }
    }

    public void BuyFonte(Button button)
    {
        if (CurrencyHandler.GetDoletasValue() >= FontePrices[FonteItemCounter]) {
            CurrencyHandler.DeacreseCurrency(FontePrices[FonteItemCounter]);
            CurrencyHandler.IncreaseByClick += 00.0400f;
            BuyItem(button);
            FonteItemCounter++;

            SelectActiveItem(FonteItems, FonteItemCounter);
        } else {
            Debug.Log("MONEY!");
        }
    }

    public void BuyRAM(Button button)
    {
        if (CurrencyHandler.GetDoletasValue() >= RAMPrices[RAMItemCounter]) {
            CurrencyHandler.DeacreseCurrency(RAMPrices[RAMItemCounter]);
            CurrencyHandler.IncreaseByClick += 00.1600f;
            BuyItem(button);        
            RAMItemCounter++;

            SelectActiveItem(RAMItems, RAMItemCounter);
        } else {
            Debug.Log("MONEY!");
        }
    }

// #######################################################################
// #################### START AND CLOSE FUNCTIONS ########################
// #######################################################################

    public void StartGPU() 
    {
        CloseItems();
        GPUItems.SetActive(true);
    }

    public void StartCPU() 
    {
        CloseItems();
        CPUItems.SetActive(true);
    }

    public void StartFonte() 
    {
        CloseItems();
        FonteItems.SetActive(true);
    }

    public void StartRAM() 
    {
        CloseItems();
        RAMItems.SetActive(true);
    }

    void CloseItems()
    {
        Items.SetActive(true);
        CloseChildren(Items);
    }

    void CloseChildren(GameObject parent, int j = 0)
    {
        Transform parentTransform = parent.transform;

        if (j != 0) {
            for (int i = 0; i < j; ++i)
            {
                parentTransform.GetChild(i).gameObject.SetActive(false);
            }
        } else {
            for (int i = 0; i < parentTransform.childCount; ++i)
            {
                parentTransform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
