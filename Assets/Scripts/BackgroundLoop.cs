using UnityEngine;

public class BackgroundLoop : MonoBehaviour{
    public GameObject[] levels;
    private Camera _mainCamera;
    private Vector2 _screenBounds;
    public float choke;
    public float scrollSpeed;

    private void Start(){
        _mainCamera = gameObject.GetComponent<Camera>();
        _screenBounds = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _mainCamera.transform.position.z));
        foreach(var obj in levels){
            LoadChildObjects(obj);
        }
    }

    private void LoadChildObjects(GameObject obj){
        var objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - choke;
        var childsNeeded = (int)Mathf.Ceil(_screenBounds.x * 2 / objectWidth);
        var clone = Instantiate(obj);
        for(var i = 0; i <= childsNeeded; i++){
            var c = Instantiate(clone, obj.transform, true);
            var position = obj.transform.position;
            c.transform.position = new Vector3(objectWidth * i, position.y, position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

    private void RepositionChildObjects(GameObject obj){
        var children = obj.GetComponentsInChildren<Transform>();
        if (children.Length <= 1) return;
        
        var firstChild = children[1].gameObject;
        var lastChild = children[^1].gameObject;
        var halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;
        if(transform.position.x + _screenBounds.x > lastChild.transform.position.x + halfObjectWidth){
            firstChild.transform.SetAsLastSibling();
            var position = lastChild.transform.position;
            firstChild.transform.position = new Vector3(position.x + halfObjectWidth * 2, position.y, position.z);
        }else if(transform.position.x - _screenBounds.x < firstChild.transform.position.x - halfObjectWidth){
            lastChild.transform.SetAsFirstSibling();
            var position = firstChild.transform.position;
            lastChild.transform.position = new Vector3(position.x - halfObjectWidth * 2, position.y, position.z);
        }
    }

    private void Update() {
        var velocity = Vector3.zero;
        var transform1 = transform;
        var position = transform1.position;
        var desiredPosition = position + new Vector3(scrollSpeed, 0, 0);
        var smoothPosition = Vector3.SmoothDamp(position, desiredPosition, ref velocity, 0.3f);
        transform.position = smoothPosition;

    }

    private void LateUpdate(){
        foreach(var obj in levels){
            RepositionChildObjects(obj);
        }
    }
}