using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RTOG.Data.Models.Field
{
    public class Edge
    {
        [Required]
        public int Id { get; set; }

        public Tile StartTile { get; set; }

        public Tile EndTile { get; set; }   


    }
}
