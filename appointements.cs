namespace ClientLourd_Agenda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class appointements
    {
        [Key]
        public int idAppointement { get; set; }

        public DateTime dateHour { get; set; }

        public int idCustomer { get; set; }

        public int idBroker { get; set; }

        public virtual brokers brokers { get; set; }

        public virtual customers customers { get; set; }
    }
}
