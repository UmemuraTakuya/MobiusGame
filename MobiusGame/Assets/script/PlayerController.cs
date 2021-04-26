using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float speed; // 動く速さ
    public Text scoreText; // スコアの UI
    public Text winText; // リザルトの UI
    public Text Plv;//レベル表記
    public Text Pexp;//現在の保有経験値

    private Rigidbody rb; // Rididbody
    private int score; // スコア
    private int m_exp=3;//必要経験値
    private int exp=0;//現在の保有経験値
  [SerializeField]  private int lv = 1;
   
    void Start()
    {
        // Rigidbody を取得
        rb = GetComponent<Rigidbody>();

        // UI を初期化
        score = 0;
        SetCountText();
        SetCountLV();
        winText.text = "";
    }

    void Update()
    {
        // カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        // カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Ridigbody に力を与えて玉を動かす
        rb.AddForce(movement * speed);
    }

    // 玉が他のオブジェクトにぶつかった時に呼び出される
    void OnTriggerEnter(Collider other)
    {
        // ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("Pick Up"))
        {
            // その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            // スコアを加算します
            score = score + 1;

            //expを加算
            exp = exp + 1;

            if (exp>=m_exp)
            {
                lv = lv + 1;
                exp = 0;
                m_exp =lv * 3;
            }

            // UI の表示を更新します
            SetCountText();
            SetCountLV();
        }
    }

    // UI の表示を更新する
    void SetCountText()
    {
        // スコアの表示を更新
        scoreText.text = "Count: " + score.ToString();

        // すべての収集アイテムを獲得した場合
        if (score >= 12)
        {
            // リザルトの表示を更新
            winText.text = "You Win!";
        }
    }
    void SetCountLV()
    {
        // スコアの表示を更新
        Plv.text = "Lv" + lv.ToString();
        Pexp.text = "exp：" + exp.ToString();

    }
}
