using UnityEngine;
using System.Collections;
using Rewired;

public class BGscroller : MonoBehaviour
{

    public GameObject target;
    public float scrollspeed;
    public float parralax = 2f;

    public int rewiredPlayerId = 0;
    private Player rewiredPlayer;
    private Vector3 moveVector;
    private float rotate;
    private Vector3 rightTrigger;
    private Vector3 LeftTrigger;

    private Vector2 velocity = Vector2.zero;

    private void FixedUpdate()
    {
        if (rewiredPlayer == null)
        {
            rewiredPlayer = ReInput.players.GetPlayer(rewiredPlayerId);
        }

        if (moveVector.x > 0.001f || moveVector.z > 0.001f)
        {

            //transform.position = new Vector3();
            //tr.transform.Rotate(new Vector3(0, moveVector.z, 0) * Time.deltaTime * engineTurnSpeed);
            //tr.transform.Rotate(new Vector3(0, moveVector.x, 0) * Time.deltaTime * engineTurnSpeed);

            
            Vector2 goalPosV2 = new Vector2(target.transform.position.x, target.transform.position.z);

          //  goalPos.y = 690;


            MeshRenderer mr = GetComponent<MeshRenderer>();

            Material mat = mr.material;
            float step = scrollspeed * Time.deltaTime;
            Vector2 offset = mat.mainTextureOffset;

            // offset = transform.position / transform.localScale;
            offset = Vector2.SmoothDamp(offset, goalPosV2, ref velocity, step, 0.0f, Time.deltaTime) / parralax;
            //offset.z = transform.position.x / scrollspeed / parralax;
            //offset.x = transform.position.z / scrollspeed / parralax;
            mat.mainTextureOffset = offset;
        }
    }
}
