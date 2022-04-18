using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDraw : MonoBehaviour
{
    LineRenderer lineRenderer;
    List<Vector2> mousePositions;
	[SerializeField] GameObject linePrefab;
    [SerializeField] float deltaDiscretize = .1f;
    
    [SerializeField] GameObject screenCenter;
    private bool isDrawing = false;
	private GameObject currentLine;

    private EdgeCollider2D edgeCollider;


    [Header("Tint")]
    [SerializeField] private float maxShieldTint = 20f;
    private float currentShieldTint;
    [SerializeField] private float rateOfUseTint = 1f;
    [SerializeField] private float rateOfReplenishTint = 1f;


    void Start()
    {
        mousePositions = new List<Vector2>();
        currentShieldTint = maxShieldTint;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("TINT: " + currentShieldTint);

        // Reestablecer tinta
        if(!isDrawing)
        {
            currentShieldTint += rateOfReplenishTint;
            if(currentShieldTint >= maxShieldTint)
                currentShieldTint = maxShieldTint;
        }

        // Se deja de dibujar
        if(Input.GetMouseButtonUp(1) && isDrawing == true){
            currentLine.tag = "Shield"; //para que colisionen solo cuando salga disparado
            currentLine.layer = 9;
            
            isDrawing = false;
            
            Vector2 middlePoint = lineRenderer.GetPosition((int)(lineRenderer.positionCount/2));

            Vector2 dirShield = new Vector2(middlePoint.x-screenCenter.transform.position.x, middlePoint.y-screenCenter.transform.position.y);
            currentLine.GetComponent<ShieldController>().setDirection(dirShield.normalized);
            currentLine.GetComponent<ShieldController>().setMoving(true);
        }

        // Se comienza a dibujar
        if (Input.GetMouseButtonDown(1) && currentShieldTint>0f){
            isDrawing = true;
			CreateLine();
		}

        // Se está dibujando
		if (Input.GetMouseButton(1) && currentShieldTint>0f){
			Vector2 tempMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (Vector2.Distance(tempMousePosition, mousePositions[mousePositions.Count - 1]) > deltaDiscretize){
				UpdateLine(tempMousePosition);

                // Gastar tinta
                currentShieldTint -= rateOfUseTint;
			}
		}

        UIController.instance.UpdateShieldTint(currentShieldTint, maxShieldTint);
    }
    void CreateLine(){
        // Llamamos a CreateLine una sola vez cuando empezamos a dibujar para crear currentLine. currentLine se visualizará porque tendrán un lineRenderer 
        //y tendrá colisión porque tendrá un edgeCollider
		currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
		lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
		mousePositions.Clear();
		// Como lineRenderer es una línea, necesitamos añadir dos puntos a fingerPositions para poder dibujarla sin errores
		mousePositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		mousePositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		// Dibujamos una línea compuesta de dos puntos

        lineRenderer.SetPosition(0, mousePositions[0]);
		lineRenderer.SetPosition(1, mousePositions[1]);

        edgeCollider.points = mousePositions.ToArray();
        
    }

    void UpdateLine(Vector2 newMousePos){
        mousePositions.Add(newMousePos);
		lineRenderer.positionCount++;
		// Convertimos el List de posiciones por las que ha ido pasando el dedo en la línea que vamos a ver
		lineRenderer.SetPosition(lineRenderer.positionCount - 1, newMousePos);

        edgeCollider.points = mousePositions.ToArray();
    }

}
