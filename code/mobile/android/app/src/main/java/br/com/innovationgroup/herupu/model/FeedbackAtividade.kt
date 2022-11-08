package br.com.innovationgroup.herupu.model

data class FeedbackAtividade
    ( val idAtividade: Int = 0,
      val nome: String = "",
      val descricao: String = "",
      val instrucao: String = "",
      val idadeSugerida: Int = 0 )