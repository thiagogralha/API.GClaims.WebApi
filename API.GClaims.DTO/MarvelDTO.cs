using API.GClaims.Domain.Entities;

namespace API.GClaims.DTO
{
    public class MarvelDTO
    {
        public string name { get; set; }
        public string orderBy { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        
        public static implicit operator MarvelEntity(MarvelDTO dto)
        {
            if (dto == null)
                return null;

            return new MarvelEntity
            {
                name = dto.name,
                orderBy = dto.orderBy,
                limit = dto.limit,
                offset = dto.offset
            };
        }
    }
}
