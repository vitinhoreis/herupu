package br.com.innovationgroup.herupu

import android.content.Intent
import android.graphics.Color
import android.graphics.Typeface
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.ContextThemeWrapper
import android.view.View
import android.widget.*
import br.com.innovationgroup.herupu.model.FeedbackAtividade
import br.com.innovationgroup.herupu.network.FeedbackApi
import br.com.innovationgroup.herupu.network.RetrofitHelper
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext

class HomeActivity : AppCompatActivity() {
    private lateinit var listaFeedbacks: MutableList<FeedbackAtividade>

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        carregarDados()
        setContentView(R.layout.activity_home)

        val btnNotas = findViewById<Button>(R.id.btn_notas)
        val viewNotas = findViewById<View>(R.id.view_notas)
        val btnHistorico = findViewById<Button>(R.id.btn_historico)
        val viewHistorico = findViewById<View>(R.id.view_historico)

        btnNotas.setOnClickListener {
            val i = Intent(this, NotasActivity::class.java)
            startActivity(i)
        }

        viewNotas.setOnClickListener {
            val i = Intent(this, NotasActivity::class.java)
            startActivity(i)
        }

        btnHistorico.setOnClickListener {
            val i = Intent(this, HistoricoActivity::class.java)
            startActivity(i)
        }

        viewHistorico.setOnClickListener {
            val i = Intent(this, HistoricoActivity::class.java)
            startActivity(i)
        }
    }

    private fun carregarAtividades() {

        val gridbtns = findViewById<GridLayout>(R.id.grid_atividades);

        val layoutParams = LinearLayout.LayoutParams(
            LinearLayout.LayoutParams.WRAP_CONTENT,
            LinearLayout.LayoutParams.WRAP_CONTENT
        )
        layoutParams.marginEnd = 10;
        layoutParams.marginStart = 10;
        layoutParams.topMargin = 10;
        layoutParams.bottomMargin = 10;
        layoutParams.height = 300;
        layoutParams.width = 300;

        listaFeedbacks.forEach {
            val newButton = Button(this)
            newButton.setText(it.nome)
            newButton.id = it.idAtividade
            newButton.setTextColor(Color.parseColor("#44012c"))
            newButton.setTextSize(13F)
            newButton.setTypeface(null, Typeface.BOLD)
            newButton.setBackgroundColor(Color.parseColor("#fdeefd"))

            if(it.idAtividade!=1){
                newButton.isEnabled = false
                Toast.makeText( this, "Atividade Indisponivel", Toast.LENGTH_SHORT).show()
            }

            newButton.setOnClickListener {
                val i = Intent(this, AtividadeActivity::class.java)
                startActivity(i)
            }
            gridbtns.addView(newButton, layoutParams)
        }
    }

    private fun carregarDados(){
        CoroutineScope(Dispatchers.IO).launch() {
            try {
                val result = RetrofitHelper.getInstance().create(FeedbackApi::class.java).getFeedbacks()
                Log.i("EVENTO_API", "retornoApi: Sucesses: ${result.size} registros recuperados")
                listaFeedbacks = mutableListOf()
                result.forEach{listaFeedbacks.add((it))}

                withContext(Dispatchers.Main){
                    carregarAtividades()
                }
            } catch (e: Exception) {
                Log.i("EVENTO_API", "retornoApi: + ${e.message}")
            }

        }
    }
}