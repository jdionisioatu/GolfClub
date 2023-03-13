using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfClub.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        [Required]
        public int PlayerOneId { get; set; }

        public int? PlayerTwoId { get; set; }
        public int? PlayerThreeId { get; set; }
        public int? PlayerFourId { get; set; }

        [ForeignKey("PlayerOneId")]
        public Member? PlayerOne { get; set; }
        [ForeignKey("PlayerTwoId")]
        public Member? PlayerTwo { get; set; }
        [ForeignKey("PlayerThreeId")]
        public Member? PlayerThree { get; set; }
        [ForeignKey("PlayerFourId")]
        public Member? PlayerFour {  get ;set; }
        

        [Required]
        [TimeIn15MinIntervals(ErrorMessage = "Bookings must start every 15 minutes from the hour")]
        [DataType(DataType.DateTime)]
        public DateTime TeeTime { get; set; }
    }

    public class TimeIn15MinIntervalsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime time = (DateTime)value;
            return time.Minute % 15 == 0;
        }
    }
}
