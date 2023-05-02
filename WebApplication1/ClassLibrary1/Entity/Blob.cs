using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Sql.Entity.Entity
{
    public class Blob
    {
        public Guid BlobId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string MIME { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; }

        public List<Cinema> Cinemas { get; set; } = new List<Cinema>();
    }
}
