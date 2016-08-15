using System.Runtime.Serialization;
using Items.Business.DAL.Entities;
using Utils.Web;

namespace Items.Web.ViewModels
{
    [DataContract]
    public class ItemViewModel : BaseValidatableViewModel<ItemViewModel, Item>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Place { get; set; }

        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string DateOfTravel { get; set; }

        [DataMember]
        public string FlightName { get; set; }
        [DataMember]
        public string FlightCost { get; set; }
        [DataMember]
        public string Website { get; set; }

        // [DataMember]
        // public virtual City MigratingTo { get; set; }
    }
}