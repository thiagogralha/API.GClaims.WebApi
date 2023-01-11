using API.GClaims.Domain.Entities;

namespace API.GClaims.DTO
{
    public class FavoritoMarvelDTO
    {
        public string name { get; set; }     
        
        public bool Validate()
        {
            return
                !string.IsNullOrWhiteSpace(this.name);
        }
        
        public static implicit operator FavoritoMarvelEntity(FavoritoMarvelDTO dto)
        {
            if (dto == null)
                return null;

            return new FavoritoMarvelEntity
            {
                name = dto.name,
            };
        }
    }
}
