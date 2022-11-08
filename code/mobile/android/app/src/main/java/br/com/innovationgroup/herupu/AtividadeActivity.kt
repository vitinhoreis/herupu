package br.com.innovationgroup.herupu

import android.content.Intent
import android.graphics.Color
import android.icu.lang.UCharacter.GraphemeClusterBreak.T
import android.os.Bundle
import android.util.Log
import android.view.Gravity
import android.widget.*
import androidx.appcompat.app.AppCompatActivity
import br.com.innovationgroup.herupu.model.FeedbackAtividadeItem
import br.com.innovationgroup.herupu.network.FeedbackApi
import br.com.innovationgroup.herupu.network.RetrofitHelper
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext

class AtividadeActivity : AppCompatActivity() {
    private lateinit var listaFeedbacks: MutableList<FeedbackAtividadeItem>
    private lateinit var listaAtividadeItem: MutableList<FeedbackAtividadeItem>
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_atividade)
        carregarListaDaApi()

        val imgSeta = findViewById<ImageView>(R.id.img_seta_volta)

        imgSeta.setOnClickListener{
            val i = Intent(this, HomeActivity::class.java)
            startActivity(i)
        }

        val bntCorrigir = findViewById<TextView>(R.id.btn_corrigir)

        bntCorrigir.setOnClickListener {
            CorrigirAtividade()
        }
    }

    private fun CorrigirAtividade() {

        listaFeedbacks.forEach {
            val uri = "@+id/" + it.idAtividadeItem
//            val imageResource = resources.getIdentifier(uri, null, packageName)

           // val idResource = this.getResources().getIdentifier( it.idAtividadeItem.toString(), "id", this.getPackageName());

            val text1 = findViewById<EditText>(it.idAtividadeItem)

            if(text1.text.trim().toString().toLowerCase().equals(it.resposta.trim().toLowerCase()))
                text1.setBackgroundColor(Color.parseColor("#228b22"))
            else
                text1.setBackgroundColor(Color.parseColor("#ff4c4c"))
        }
    }

    fun CarregarGrid(){
        val gridbtns = findViewById<GridLayout>(R.id.grid_atividade_item);

        val layoutLinearParams = LinearLayout.LayoutParams(
            LinearLayout.LayoutParams.WRAP_CONTENT,
            LinearLayout.LayoutParams.WRAP_CONTENT,
            5f
        )
        layoutLinearParams.gravity = Gravity.START
        layoutLinearParams.width = 450

        val layoutImage = LinearLayout.LayoutParams(
            LinearLayout.LayoutParams.MATCH_PARENT,
            LinearLayout.LayoutParams.MATCH_PARENT
        )

        layoutImage.height=400
        layoutImage.width = 400
        layoutImage.gravity = Gravity.CENTER

        val layoutText = LinearLayout.LayoutParams(
            LinearLayout.LayoutParams.WRAP_CONTENT,
            LinearLayout.LayoutParams.WRAP_CONTENT
        )

        layoutText.height=400
        layoutText.width = 196
        layoutText.gravity = Gravity.CENTER

        listaFeedbacks.forEach {
//            if (it.idAtividadeItem > 4) return@lit
            val uri = "@drawable/" + it.pergunta
            val imageResource = resources.getIdentifier(uri, null, packageName)
            val res = resources.getDrawable(imageResource)

            val layout = LinearLayout(this);
            layout.layoutParams = layoutLinearParams
            layout.orientation = LinearLayout.VERTICAL
            val image = ImageView(this)
            image.layoutParams = layoutImage
            image.setImageDrawable(res)
            layout.addView(image)

            val textView = EditText(this)
            textView.id = it.idAtividadeItem
            textView.setTextSize(15F)
            textView.setTextColor(Color.parseColor("#44012c"))
            textView.setHintTextColor(Color.parseColor("#44012c"))
            textView.setHint("Digite aqui")
            textView.background.setTint(Color.parseColor("#44012c"))
            layout.addView(textView)

            gridbtns.addView(layout)
        }
    }

    private fun carregarListaDaApi() {
        CoroutineScope(Dispatchers.IO).launch() {
            try {
                val result =
                    RetrofitHelper.getInstance().create(FeedbackApi::class.java).getAtividadesItens()
                Log.i("EVENTO_API", "retornoApi: Sucesses: ${result.size} registros recuperados")
                listaFeedbacks = mutableListOf()
                result.forEach { listaFeedbacks.add((it)) }

                withContext(Dispatchers.Main){
                    CarregarGrid()
                }

            } catch (e: Exception) {
                Log.i("EVENTO_API", "retornoApi: + ${e.message}")
            }
        }
    }
}