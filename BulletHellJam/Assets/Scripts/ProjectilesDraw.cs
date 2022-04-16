using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesDraw : MonoBehaviour
{
    LineRenderer lineRenderer;
    List<Vector2> mousePositions;
	[SerializeField] GameObject linePrefab;
    [SerializeField] float deltaDiscretize = .25f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject screenCenter;
    private bool isDrawing = false;
	private GameObject currentLine;

    void Start()
    {
        mousePositions = new List<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0) && isDrawing == true){
            isDrawing = false;
            CreateBullets();
        }

        if (Input.GetMouseButtonDown(0)){
            isDrawing = true;
			CreateLine();
		}

		if (Input.GetMouseButton(0)){
			Vector2 tempMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (Vector2.Distance(tempMousePosition, mousePositions[mousePositions.Count - 1]) > deltaDiscretize){
				UpdateLine(tempMousePosition);
			}
		}
    }

    void CreateLine(){
        // Llamamos a CreateLine una sola vez cuando empezamos a dibujar para crear currentLine. currentLine se visualizará porque tendrán un lineRenderer 
        //y tendrá colisión porque tendrá un edgeCollider
		currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
		lineRenderer = currentLine.GetComponent<LineRenderer>();
		mousePositions.Clear();
		// Como lineRenderer es una línea, necesitamos añadir dos puntos a fingerPositions para poder dibujarla sin errores
		mousePositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		mousePositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		// Dibujamos una línea compuesta de dos puntos

        lineRenderer.SetPosition(0, mousePositions[0]);
		lineRenderer.SetPosition(1, mousePositions[1]);
    }

    void UpdateLine(Vector2 newMousePos){
        mousePositions.Add(newMousePos);
		lineRenderer.positionCount++;
		// Convertimos el List de posiciones por las que ha ido pasando el dedo en la línea que vamos a ver
		lineRenderer.SetPosition(lineRenderer.positionCount - 1, newMousePos);
    }

    void CreateBullets(){
        Destroy(lineRenderer, 0f);
        //lineRenderer.material.color = new Color(0f,0f,0f,0f);

        for (int i = 0; i < lineRenderer.positionCount; i++){
            GameObject bullet = Instantiate(bulletPrefab, lineRenderer.GetPosition(i), Quaternion.identity);
            Vector2 dirBullet = new Vector2(lineRenderer.GetPosition(i).x-screenCenter.transform.position.x, lineRenderer.GetPosition(i).y-screenCenter.transform.position.y);
            bullet.GetComponent<bulletBasicController>().setDirection(dirBullet.normalized);
        }   
        
    }
}
