using API.GClaims.Domain.Entities;

namespace API.GClaims.DTO
{
    public class ListarFavoritoMarvelDTO
    {
        public OrdernacaoDTO Ordenacao { get; set; }

        public enum OrdernacaoDTO : int
        {
            Asc = 1,
            Desc = 2
        }       
        
        public static implicit operator ListarFavoritoMarvelEntity(ListarFavoritoMarvelDTO dto)
        {
            if (dto == null)
                return null;

            return new ListarFavoritoMarvelEntity
            {
                Ordenacao = (ListarFavoritoMarvelEntity.OrdernacaoEntity)dto.Ordenacao,
            };
        }
    }
}
