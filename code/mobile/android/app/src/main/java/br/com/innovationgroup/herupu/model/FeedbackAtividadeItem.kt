package br.com.innovationgroup.herupu.model

data class FeedbackAtividadeItem
    ( val idAtividadeItem: Int = 0,
      val pergunta: String = "",
      val resposta: String = "",
      val detalhe: String = "",
      val idAtividade: Int = 0 )