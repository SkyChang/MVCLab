namespace MVCLab.Domain.CRM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public long LastTimestamp { get; set; }

        public string State { get; set; }

        public string LastMessage { get; set; }

        public string ConnectionID { get; set; }
    }
}
