package br.com.innovationgroup.herupu.network

import br.com.innovationgroup.herupu.model.FeedbackAtividade
import br.com.innovationgroup.herupu.model.FeedbackAtividadeItem
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST

interface FeedbackApi {

    @GET("api/Atividade/GetAll")
    suspend fun getFeedbacks():List<FeedbackAtividade>

    @POST("api/Atividade")
    suspend fun gravarFeedback(@Body feedbackAtividade: FeedbackAtividade)

    @GET("api/AtividadeItem/GetAll/1")
    suspend fun getAtividadesItens():List<FeedbackAtividadeItem>

}