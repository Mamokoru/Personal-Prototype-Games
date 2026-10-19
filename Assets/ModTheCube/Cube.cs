using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    [SerializeField] private Color32 colorToBe;
    [SerializeField] private Vector3 postionToBe;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private Slider Red, Blue, Green, Alpha;
    [SerializeField] private Button RandomPositon, RandomRotationSpeed, RandomRotationAxis;

    private int RotationAxis;

    private void Awake()
    {
        Red.onValueChanged.AddListener((t) => colorToBe.r = (byte)t);
        Blue.onValueChanged.AddListener((t) => colorToBe.b = (byte)t);
        Green.onValueChanged.AddListener((t) => colorToBe.g = (byte)t);
        Alpha.onValueChanged.AddListener((t) => colorToBe.a = (byte)t);
        RandomPositon.onClick.AddListener(() => postionToBe = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5)));
        RandomRotationSpeed.onClick.AddListener(() => RotationSpeed = (Random.Range(-500, 500)));
        RandomRotationAxis.onClick.AddListener(() => RotationAxis = (RotationAxis + 1) % 3);
    }
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        Material material = Renderer.material;

        material.color = colorToBe;
    }

    void Update()
    {
        transform.Rotate(RotationAxis switch { 0 => Vector3.right, 1 => Vector3.up, 2 => Vector3.forward, _ => Vector3.one } * RotationSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, postionToBe, 0.1f);
        Renderer.material.color = Color32.Lerp(Renderer.material.color, colorToBe, 0.1f);
    }

}
