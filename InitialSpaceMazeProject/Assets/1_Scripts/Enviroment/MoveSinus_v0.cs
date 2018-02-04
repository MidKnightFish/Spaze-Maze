// @author: J-D Vbk
// Have fun with math!
// possible (next to others):
// line, circle, eight, arrowhead(>)

using UnityEngine;

public class MoveSinus : MonoBehaviour
{
    [Header("Transition")]
    public float xPosAmplitude = 0;
    public float xPosPeriodLength = 3;
    [Range(0.0f, 1.0f)]
    public float xPosShift;
    float xPosElapsed;

    public float yPosAmplitude = 0;
    public float yPosPeriodLength = 3;
    [Range(0.0f, 1.0f)]
    public float yPosShift;
    float yPosElapsed;

    public float zPosAmplitude = 0;
    public float zPosPeriodLength = 3;
    [Range(0.0f, 1.0f)]
    public float zPosShift;
    float zPosElapsed;

    [Header("Rotation")]
    public float xRotAmplitude = 0;
    public float xRotPeriodLength = 3;
    [Range(0.0f, 1.0f)]
    public float xRotShift;
    float xRotElapsed;

    public float yRotAmplitude = 0;
    public float yRotPeriodLength = 3;
    [Range(0.0f, 1.0f)]
    public float yRotShift;
    float yRotElapsed;

    public float zRotAmplitude = 0;
    public float zRotPeriodLength = 3;
    [Range(0.0f, 1.0f)]
    public float zRotShift;
    float zRotElapsed;

    Vector3 basePosition;
    Vector3 nextPosition;
    Vector3 baseRotation;
    Vector3 nextRotation;

    void Start()
    {
        yPosElapsed = yPosShift * yPosPeriodLength;
        xPosElapsed = xPosShift * xPosPeriodLength;
        zPosElapsed = zPosShift * zPosPeriodLength;

        xRotElapsed = xRotShift * xRotPeriodLength;
        yRotElapsed = yRotShift * yRotPeriodLength;
        zRotElapsed = zRotShift * zRotPeriodLength;

        basePosition = transform.position;
        nextPosition = basePosition;
        baseRotation = transform.rotation.eulerAngles;
        nextRotation = baseRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Transition
        if (xPosAmplitude > 0)
        {
            xPosElapsed += Time.deltaTime;
            if (xPosElapsed > xPosPeriodLength) xPosElapsed = 0;

            nextPosition.x = basePosition.x + Mathf.Sin(xPosElapsed / xPosPeriodLength * 2 * Mathf.PI) * xPosAmplitude;
        }
        if (yPosAmplitude > 0)
        {
            yPosElapsed += Time.deltaTime;
            if (yPosElapsed > yPosPeriodLength) yPosElapsed = 0;
            nextPosition.y = basePosition.y + Mathf.Sin(yPosElapsed / yPosPeriodLength * 2 * Mathf.PI) * yPosAmplitude;
        }
        if (zPosAmplitude > 0)
        {
            zPosElapsed += Time.deltaTime;
            if (zPosElapsed > zPosPeriodLength) zPosElapsed = 0;
            nextPosition.z = basePosition.z + Mathf.Sin(zPosElapsed / zPosPeriodLength * 2 * Mathf.PI) * zPosAmplitude;
        }
        transform.position = nextPosition;

        //Rotation
        if (xRotAmplitude > 0)
        {
            xRotElapsed += Time.deltaTime;
            if (xRotElapsed > xRotPeriodLength) xRotElapsed = 0;
            nextRotation.x = baseRotation.x + Mathf.Sin(xRotElapsed / xRotPeriodLength * 2 * Mathf.PI) * xRotAmplitude;
        }
        if (yRotAmplitude > 0)
        {
            yRotElapsed += Time.deltaTime;
            if (yRotElapsed > yRotPeriodLength) yRotElapsed = 0;
            nextRotation.y = baseRotation.y + Mathf.Sin(yRotElapsed / yRotPeriodLength * 2 * Mathf.PI) * yRotAmplitude;
        }
        if (zRotAmplitude > 0)
        {
            zRotElapsed += Time.deltaTime;
            if (zRotElapsed > zRotPeriodLength) zRotElapsed = 0;
            nextRotation.z = baseRotation.z + Mathf.Sin(zRotElapsed / zRotPeriodLength * 2 * Mathf.PI) * zRotAmplitude;
        }
        transform.eulerAngles = nextRotation;
    }
}
