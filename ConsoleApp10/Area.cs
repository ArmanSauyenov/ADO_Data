using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace ConsoleApp10
{
    [Table]
    public class Area
    {
        [Column(IsPrimaryKey = true)]
        public int AreaId { get; set; }
        [Column]
        public int? TypeArea { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public int? ParentId { get; set; }
        [Column]
        public bool? NoSplit { get; set; }
        [Column]
        public bool? AssemblyArea { get; set; }
        [Column]
        public string FullName { get; set; }
        [Column]
        public bool? MultipleOrders { get; set; }
        [Column]
        public bool? HiddenArea { get; set; }
        [Column]
        public string IP { get; set; }
        [Column]
        public int PavilionId { get; set; }
        [Column]
        public int TypeId { get; set; }
        [Column]
        public int? OrderExecution { get; set; }
        [Column]
        public int? Dependence { get; set; }
        [Column]
        public int? WorkingPeople { get; set; }
        [Column]
        public int? ComponentTypeId { get; set; }
        [Column]
        public int? GroupId { get; set; }
        [Column]
        public int? Segment { get; set; }
    }
}
