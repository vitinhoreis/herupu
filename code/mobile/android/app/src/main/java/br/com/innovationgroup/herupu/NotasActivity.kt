package br.com.innovationgroup.herupu

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.ImageView

class NotasActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_notas)

        val setaVolta = findViewById<ImageView>(R.id.img_seta_volta_hist)

        setaVolta.setOnClickListener{
            val i = Intent(this, HomeActivity::class.java)
            startActivity(i)
        }
    }
}