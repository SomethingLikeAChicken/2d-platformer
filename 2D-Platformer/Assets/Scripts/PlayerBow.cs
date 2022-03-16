using UnityEngine;

public class PlayerBow : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] float launchForce;
    [SerializeField] Transform shotPoint;
    private Vector2 direction;

    [SerializeField] private GameObject point;
    [SerializeField] private int numberOfPoints;
    [SerializeField] float spaceBetweenPoints;
    [SerializeField] private Transform player;
    private float shotTimer = 1.5f;
    GameObject[] points;


    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[numberOfPoints];
        for(int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(player.localScale.x < 0)
        {
            direction = mousePosition - bowPosition;
            for (int i = 0; i < numberOfPoints; i++)
            {
                points[i].transform.position = PointPosition(i * spaceBetweenPoints);
            }
        }
        if(player.localScale.x > 0)
        {
            direction = bowPosition - mousePosition;
            for (int i = 0; i < numberOfPoints; i++)
            {
                points[i].transform.position = PointPosition(-i * spaceBetweenPoints);
            }
        }
        transform.right = direction;
        shotTimer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && shotTimer < 0)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Vector3 shootingPoint = shotPoint.position;
        if (player.localScale.x < 0)
        {
            GameObject newArrow = Instantiate(arrow, shootingPoint, shotPoint.rotation);
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), newArrow.GetComponent<Collider2D>());
            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        }
        if(player.localScale.x > 0)
        {
            GameObject newArrow = Instantiate(arrow, shootingPoint, shotPoint.rotation);
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), newArrow.GetComponent<Collider2D>());
            newArrow.GetComponent<Rigidbody2D>().velocity = -1 * launchForce * transform.right;
        }
        shotTimer = 1.5f;
    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (launchForce * t * direction.normalized) + (t * t) * 0.5f * Physics2D.gravity;
        return position;
    }
}
