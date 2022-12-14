//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OborydovanieOtkaz.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class TechnicalInspection
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> ProductionSiteId { get; set; }
        public Nullable<int> EquipmentId { get; set; }
        public Nullable<int> WorkerId { get; set; }
        public string Result { get; set; }
        public string Reason { get; set; }
    
        public virtual Equipment Equipment { get; set; }
        public virtual ProductionSite ProductionSite { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
