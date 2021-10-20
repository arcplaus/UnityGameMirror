using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private string doorTag = "door";
    [SerializeField] private string goodMirrorTag = "goodMirror";
    [SerializeField] private string badMirrorTag = "badMirror";
    [SerializeField] private Animator myDoor;

    public CameraShake camShake;
    public IntensityController intensityController;

    public GameObject noteType;
    public GameObject enemy;
    public GameObject[] notes = new GameObject[3];
    [SerializeField] private Material highlightMat;
    [SerializeField] private Material DefaultMat;
    private Transform _selection;
    public Transform player;
    public InteractionObject curInterObjScript = null;
    public Inventory inventory;
    private bool highlighted = false;
    private bool first = false;
    private bool second = false;
    // Update is called once per frame
    void Update()
    {
        if (_selection != null) {
            if (highlighted)
            {
                var selectionRenderer = _selection.GetComponent<Renderer>();
                selectionRenderer.material = DefaultMat;
                highlighted = false;
            }
            _selection = null;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {

                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMat;
                    highlighted = true;
                }
                _selection = selection;
                if (Input.GetMouseButtonDown(0))
                {
                    curInterObjScript = selection.GetComponent<InteractionObject>();
                    inventory.addItem(selection.gameObject);
                    selection.gameObject.SetActive(false);
                }
            }
            if (selection.CompareTag(doorTag) && Input.GetKey(KeyCode.E))
            {

                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selection.gameObject.SetActive(false);
                }
                _selection = selection;
            }
            if (selection.CompareTag(goodMirrorTag))
            {
                Debug.Log("good");
                var selectionRenderer = selection.GetComponent<Renderer>();
                curInterObjScript = selection.GetComponent<InteractionObject>();
                if (selectionRenderer != null && Input.GetMouseButtonDown(0))
                {
                    for (int i = 0; i < 3; i++) {
                        if (notes[i].name == (curInterObjScript.noteName)) {
                            noteType = notes[i];
                        }
                    }
                    GameObject noteInstance = Instantiate(noteType, selection.position, selection.rotation);

                    selection.gameObject.SetActive(false);

                }
                _selection = selection;

            }
            if (selection.CompareTag(badMirrorTag))
            {
                Debug.Log("bad");
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null && Input.GetMouseButtonDown(0))
                {
                    GameObject enemyInstance = Instantiate(enemy, selection.position, selection.rotation);
                    selection.gameObject.SetActive(false);
                    Debug.Log("badCheck");
                    intensityController.intensity += 0.3f;
                    camShake.shakeFactor = 0.7f;

                }
                _selection = selection;

            }
        }
    }
}
