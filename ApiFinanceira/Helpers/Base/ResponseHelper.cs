using ApiFinanceira.DTO.Base;

namespace ApiFinanceira.Helpers.Base
{
    public static class ResponseHelper
    {
        public static BaseResponseDTO<T> Ok<T>(T dados, string mensagem = "OK")
            => BaseResponseDTO<T>.Ok(dados, mensagem);

        public static BaseResponseDTO<T> Falha<T>(string mensagem, string? codigo = null)
            => BaseResponseDTO<T>.Falha(mensagem, codigo);
    }
}
