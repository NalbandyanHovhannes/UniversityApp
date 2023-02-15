using Microsoft.EntityFrameworkCore;

namespace UniversityApp
{
    public class BaseRepository 
    {
      
        public BaseRepository(DbContext dentalContext)
        {
            //DentalContext = dentalContext;
        }
    }
}
