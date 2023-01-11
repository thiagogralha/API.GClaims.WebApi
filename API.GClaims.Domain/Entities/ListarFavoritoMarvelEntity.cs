namespace API.GClaims.Domain.Entities
{
    public class ListarFavoritoMarvelEntity
    {
        public OrdernacaoEntity Ordenacao { get; set; }

        public enum OrdernacaoEntity : int
        {
            Asc = 1,
            Desc = 2
        }  
    }
}
